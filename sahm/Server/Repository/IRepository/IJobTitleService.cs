using sahm.Shared.Model;
using sahm.Shared.Models;

namespace sahm.Server.Repository.IRepository
{
    public interface IJobTitleService
    {
        Task<JobTitleDTO?> GetById(int id);
        Task<List<JobTitleDTO>> GetAll();
        Task<bool> Insert(JobTitleDTO  jobTitleDTO);
        Task<bool> Update(JobTitleDTO  jobTitleDTO, int Id);
        Task<bool> Delete(int id);
    }
}
