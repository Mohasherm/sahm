using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using sahm.Server.Hubs;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Repository
{
    public class TankService : ITankService
    {
        DataContext db;
        private readonly UserManager<AppUser> userManager;
        private readonly IHubContext<NotificationsHub> context;

        public TankService(DataContext db, UserManager<AppUser> userManager,
            IHubContext<NotificationsHub> context)
        {
            this.db = db;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<bool> Insert(TankOperationDTO tankOperationDTO)
        {
            await db.TankOperations.AddAsync(new TankOperation
            {
                Id = tankOperationDTO.Id,
                Tank_Id = tankOperationDTO.Tank_Id,
                InQTY = tankOperationDTO.InQTY,
                OutQTY = tankOperationDTO.OutQTY,
                Date = DateTime.Now
            });

            try
            {

                await db.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTankQTY(TankQTYUpdateDTO tankQTYUpdateDTO, int Id)
        {
            if (tankQTYUpdateDTO == null || tankQTYUpdateDTO.Id != Id)
                return false;
            var data = await db.Tanks.FindAsync(Id);

            if (tankQTYUpdateDTO.OperationType == "in")
                data.QTY += tankQTYUpdateDTO.QTY;
            else if (tankQTYUpdateDTO.OperationType == "out")
                data.QTY -= tankQTYUpdateDTO.QTY;

            db.Entry(data).State = EntityState.Modified;

            ///send notification
            ///
            if (data.QTY < 5000)
            {
                var users = await userManager.GetUsersInRoleAsync("MaintenanceAdmin");

                foreach (var user in users)
                {
                    Notification notification = new()
                    {
                        Title = "تنبيه",
                        Msessage = $"يوجد نقص في خزان {data.Name} في المحطة {data.Center.Name}",
                        Date = DateTime.Now,
                        User_Id = user.Id
                    };
                    await db.Notifications.AddAsync(notification);
                }
            }
            try
            {
                await db.SaveChangesAsync();
                await context.Clients.All.SendAsync("ReceiveMessage");
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        async Task<List<TankDTO>?> ITankService.GetById(int Center_Id)
        {
            return await (from a in db.Tanks
                          where a.Center_Id == Center_Id
                          select new TankDTO
                          {
                              Id = a.Id,
                              Name = a.Name,
                              QTY = a.QTY
                          }).ToListAsync();
        }
    }
}
