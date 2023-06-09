using sahm.Shared.Model;

namespace sahm.Server.Repository.IRepository
{
    public interface INotificationService
    {
        Task<List<NotificationDTO>> GetById(Guid id);
        Task<List<NotificationDTO>> GetAll();
        Task<bool> Insert(NotificationDTO notificationDTO);
        Task<bool> Delete(int id);
    }
}
