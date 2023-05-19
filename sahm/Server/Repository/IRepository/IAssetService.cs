using sahm.Shared.Model;
using sahm.Shared.Models;

namespace sahm.Server.Repository.IRepository
{
    public interface IAssetService
    {
        Task<AssetDTO?> GetById(int id);
        Task<List<AssetDTO>> GetAll();
        Task<bool> Insert(AssetDTO assetDTO);

        Task<bool> Update(AssetDTO assetDTO, int Id);

        Task<bool> Delete(int id);
    }
}
