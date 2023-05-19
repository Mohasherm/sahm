using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sahm.Shared.Models;

namespace sahm.Server.Repository
{
    public class DepartmentService : IDepartment
    {
        DataContext db;
        public DepartmentService(DataContext db)
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
            return await(
                from a in db.Departments
                select new DepartmentDto
                {
                    id = a.Id,
                    Name = a.Name
                }
                   ).ToListAsync();
        }


        public async Task<bool> Insert(DepartmentDto departmentDto)
        {
            await db.Departments.AddAsync(new Department { Id = departmentDto.id, Name = departmentDto.Name });

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

    
        public async Task<bool> Delete(int id)
        {
            var data = await db.Departments.FindAsync(id);
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
    }
}
