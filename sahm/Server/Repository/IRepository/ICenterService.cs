using sahm.Shared.Model;
using sahm.Shared.Models;

namespace sahm.Server.Repository.IRepository
{
    public interface ICenterService
    {
        Task<CenterDTO?> GetById(int id);
        Task<List<CenterDTO>> GetAll();
        Task<List<CenterDTO>> GetStation();
        Task<bool> Insert(CenterDTO centerDTO);

        Task<bool> Update(CenterDTO centerDTO, int Id);

        Task<bool> Delete(int id);
    }
}
