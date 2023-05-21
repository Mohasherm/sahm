using sahm.Shared.Model;

namespace sahm.Server.Repository.IRepository
{
    public interface ITankService
    {
        Task<List<TankDTO>?> GetById(int Center_Id);
        Task<bool> Insert(TankOperationDTO tankOperationDTO);
        Task<bool> UpdateTankQTY(TankQTYUpdateDTO tankQTYUpdateDTO, int Id);
    }
}
