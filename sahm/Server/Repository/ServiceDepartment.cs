using Microsoft.EntityFrameworkCore;
using sahm.Shared.Models;

namespace sahm.Server.Repository
{
    public class ServiceDepartment : IDepartment
    {
        DataContext db;
        public ServiceDepartment(DataContext db)
        {
            this.db = db;
        }



        public async Task<DepartmentDto?> GetById(int id)
        {
            return await (from a in db.Departments
                          where a.Id == id
                          select new DepartmentDto
                          {
                              id = a.Id,
                              Name = a.Name
                          }).FirstOrDefaultAsync();
        }


        public async Task<List<DepartmentDto>> GetAll()
        {
            return (
                from a in db.Departments
                select new DepartmentDto
                {
                    id = a.Id,
                    Name = a.Name
                }
                   ).ToList();
        }


        public async Task<bool> Insert(DepartmentDto departmentDto)
        {
            await db.Departments.AddAsync(new Department { Id = departmentDto.id, Name = departmentDto.Name });

            try
            {
                db.Entry(departmentDto).State = EntityState.Added;

                await db.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> Update(DepartmentDto departmentDto, int Id)
        {
            if (departmentDto == null || departmentDto.id != Id)
                return false;
            var data = await db.Departments.FindAsync(Id);
            data.Name = departmentDto.Name;
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
    }
}
