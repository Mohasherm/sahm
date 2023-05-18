using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Repository
{
    public class CenterService : ICenterService
    {
        DataContext db;
        public CenterService(DataContext db)
        {
            this.db = db;
        }
        public async Task<bool> Delete(int id)
        {
            var data = await db.Centers.FindAsync(id);
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

        public async Task<List<CenterDTO>> GetAll()
        {
            return await (
                from a in db.Centers
                select new CenterDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
                    User_Id = a.User_Id,
                    UserName = a.appUser.Name
                }
                   ).ToListAsync();
        }

        public async Task<CenterDTO?> GetById(int id)
        {
            return await (from a in db.Centers
                          where a.Id == id
                          select new CenterDTO
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Type = a.Type,
                              User_Id = a.User_Id,
                              UserName = a.appUser.Name
                          }).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(CenterDTO centerDTO)
        {
            await db.Centers.AddAsync(new Center { Id = centerDTO.Id, Name = centerDTO.Name ,
                Type = centerDTO.Type , User_Id = centerDTO.User_Id});

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

        public async Task<bool> Update(CenterDTO centerDTO, int Id)
        {
            if (centerDTO == null || centerDTO.Id != Id)
                return false;
            var data = await db.Centers.FindAsync(Id);
            data.Name = centerDTO.Name;
            data.Type = centerDTO.Type;
            data.User_Id = centerDTO.User_Id;
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
