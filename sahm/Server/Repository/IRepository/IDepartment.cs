using sahm.Shared.Models;

namespace sahm.Server.Repository
{
    public interface IDepartment
    {

        Task<DepartmentDto?> GetById(int id);
        Task<List<DepartmentDto>> GetAll();
        Task<bool> Insert(DepartmentDto department);

        Task<bool> Update(DepartmentDto department , int Id);
    }
}
