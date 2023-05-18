using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;
using sahm.Shared.Models;

namespace sahm.Server.Repository
{
    public class JobTitleService : IJobTitleService
    {
        DataContext db;
        public JobTitleService(DataContext db)
        {
            this.db = db;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await db.JobTitles.FindAsync(id);
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

        public async Task<List<JobTitleDTO>> GetAll()
        {
            return await(
               from a in db.JobTitles
               select new JobTitleDTO
               {
                   Id = a.Id,
                   Name = a.Name
               }
                  ).ToListAsync();
        }

        public async Task<JobTitleDTO?> GetById(int id)
        {
            return await(from a in db.JobTitles
                         where a.Id == id
                         select new JobTitleDTO
                         {
                             Id = a.Id,
                             Name = a.Name
                         }).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(JobTitleDTO jobTitleDTO)
        {
            await db.JobTitles.AddAsync(new JobTitle { Id = jobTitleDTO.Id, Name = jobTitleDTO.Name });

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

        public async Task<bool> Update(JobTitleDTO jobTitleDTO, int Id)
        {
            if (jobTitleDTO == null || jobTitleDTO.Id != Id)
                return false;
            var data = await db.JobTitles.FindAsync(Id);
            data.Name = jobTitleDTO.Name;
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
