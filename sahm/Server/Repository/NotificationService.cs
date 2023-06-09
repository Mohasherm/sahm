using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Repository
{
    public class NotificationService : INotificationService
    {
        DataContext db;
        public NotificationService(DataContext db)
        {
            this.db = db;
        }
        public async Task<bool> Delete(int id)
        {
            var data = await db.Notifications.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            db.Remove(data);
            try
            {
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<NotificationDTO>> GetAll()
        {
            return await (
                from a in db.Notifications
                select new NotificationDTO
                {
                    Id = a.Id,
                    Title = a.Title,
                    Msessage = a.Msessage,
                    Date = a.Date,
                    User_Id = a.User_Id
                }
                   ).ToListAsync();
        }

        public async Task<List<NotificationDTO>> GetById(Guid id)
        {
            return await (
               from a in db.Notifications
               where a.User_Id == id
               select new NotificationDTO
               {
                   Id = a.Id,
                   Title = a.Title,
                   Msessage = a.Msessage,
                   Date = a.Date,
                   User_Id = a.User_Id
               }
                  ).ToListAsync();
        }

        public async Task<bool> Insert(NotificationDTO notificationDTO)
        {
            await db.Notifications.AddAsync(new Notification
            {
                Id = notificationDTO.Id,
                Title = notificationDTO.Title,
                Msessage= notificationDTO.Msessage,
                User_Id= notificationDTO.User_Id,
                Date= notificationDTO.Date
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

       
    }
}
