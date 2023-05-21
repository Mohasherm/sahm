using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Repository
{
    public class TankService : ITankService
    {
        DataContext db;
        public TankService(DataContext db)
        {
            this.db = db;
        }

        public async Task<bool> Insert(TankOperationDTO tankOperationDTO)
        {
            await db.TankOperations.AddAsync(new TankOperation { 
                Id = tankOperationDTO.Id, 
                Tank_Id = tankOperationDTO.Tank_Id,
                InQTY= tankOperationDTO.InQTY,
                OutQTY= tankOperationDTO.OutQTY,
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

            if(tankQTYUpdateDTO.OperationType == "in")
               data.QTY = data.QTY + tankQTYUpdateDTO.QTY;
            else if(tankQTYUpdateDTO.OperationType == "out")
                data.QTY = data.QTY - tankQTYUpdateDTO.QTY;

            db.Entry(data).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
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
            return await(from a in db.Tanks
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
