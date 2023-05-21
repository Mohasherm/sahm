using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Repository
{
    public class CenterAssetService : ICenterAssetService
    {
        DataContext db;
        public CenterAssetService(DataContext db)
        {
            this.db = db;
        }
        public async Task<bool> Delete(int id)
        {
            var data = await db.centerAssets.FindAsync(id);
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

        public async Task<List<CenterAssetDTO>> GetAll()
        {
            return await (
               from a in db.centerAssets
               select new CenterAssetDTO
               {
                   Id = a.Id,
                   Center_Id = a.Center_Id,
                   Asset_Id = a.Asset_Id,
                   QTY = a.QTY,
                   Barcode = a.Barcode
               }).ToListAsync();
        }

        public async Task<CenterAssetDTO?> GetById(int id)
        {
            return await (from a in db.centerAssets
                          where a.Id == id
                          select new CenterAssetDTO
                          {
                              Id = a.Id,
                              Center_Id = a.Center_Id,
                              Asset_Id = a.Asset_Id,
                              QTY = a.QTY,
                              Barcode = a.Barcode
                          }).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(CenterAssetDTO centerAssetDTO)
        {
            await db.centerAssets.AddAsync(new CenterAsset
            {
                Id = centerAssetDTO.Id,
                Center_Id = centerAssetDTO.Center_Id,
                Asset_Id = centerAssetDTO.Asset_Id,
                QTY = centerAssetDTO.QTY,
                Barcode = centerAssetDTO.Barcode
            });

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

        public async Task<bool> Update(CenterAssetDTO centerAssetDTO, int Id)
        {
            if (centerAssetDTO == null || centerAssetDTO.Id != Id)
                return false;
            var data = await db.centerAssets.FindAsync(Id);
            data.Center_Id = centerAssetDTO.Center_Id;
            data.Asset_Id = centerAssetDTO.Asset_Id;
            data.QTY = centerAssetDTO.QTY;
            data.Barcode = centerAssetDTO.Barcode;
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
