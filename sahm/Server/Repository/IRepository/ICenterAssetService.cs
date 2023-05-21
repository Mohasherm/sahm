using sahm.Shared.Model;

namespace sahm.Server.Repository.IRepository
{
    public interface ICenterAssetService
    {
        Task<List<CenterAssetDTO>> GetAll();
        Task<CenterAssetDTO?> GetById(int id);
        Task<bool> Insert(CenterAssetDTO centerAssetDTO);

        Task<bool> Update(CenterAssetDTO centerAssetDTO, int Id);

        Task<bool> Delete(int id);
    }
}
