using sahm.Shared.Model;

namespace sahm.Server.Repository.IRepository
{
    public interface IComplaintService
    {
        Task<ComplaintDTO?> GetById(int id);
        Task<List<ComplaintDTO>> GetAll();
        Task<bool> Insert(ComplaintDTO complaintDTO);
    }
}
