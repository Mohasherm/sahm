using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;
using sahm.Shared.Models;

namespace sahm.Server.Repository
{
    public class AssetService : IAssetService
    {
        DataContext db;
        public AssetService(DataContext db)
        {
            this.db = db;
        }
        public async Task<bool> Delete(int id)
        {
            var data = await db.Assets.FindAsync(id);
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

        public async Task<List<AssetDTO>> GetAll()
        {
            return await(
                from a in db.Assets
                select new AssetDTO
                {
                    Id = a.Id,
                    Name = a.Name
                }
                   ).ToListAsync();
        }

        public async Task<AssetDTO?> GetById(int id)
        {
            return await(from a in db.Assets
                         where a.Id == id
                         select new AssetDTO
                         {
                             Id = a.Id,
                             Name = a.Name
                         }).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(AssetDTO assetDTO)
        {
            await db.Assets.AddAsync(new Asset { Id = assetDTO.Id, Name = assetDTO.Name });

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

        public async Task<bool> Update(AssetDTO assetDTO, int Id)
        {
            if (assetDTO == null || assetDTO.Id != Id)
                return false;
            var data = await db.Assets.FindAsync(Id);
            data.Name = assetDTO.Name;
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
