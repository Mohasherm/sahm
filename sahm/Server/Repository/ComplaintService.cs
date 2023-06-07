using Microsoft.EntityFrameworkCore;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Repository
{
    public class ComplaintService : IComplaintService
    {
        DataContext db;
        public ComplaintService(DataContext db)
        {
            this.db = db;
        }

        public async Task<List<ComplaintDTO>> GetAll()
        {
            return await(
               from a in db.Complaints
               select new ComplaintDTO
               {
                   Id = a.Id,
                   Name = a.Name,
                   Email= a.Email,
                   Mobile= a.Mobile,
                   Note= a.Note,
                   Zone = a.Zone,
                   Station_Id = a.Station_Id,
                   CenterName = a.Center.Name
               }
                  ).ToListAsync();
        }

        public async Task<ComplaintDTO?> GetById(int id)
        {
            return await(from a in db.Complaints
                         where a.Id == id
                         select new ComplaintDTO
                         {
                             Id = a.Id,
                             Name = a.Name,
                             Email = a.Email,
                             Mobile = a.Mobile,
                             Note = a.Note,
                             Zone = a.Zone,
                             Station_Id = a.Station_Id,
                             CenterName = a.Center.Name
                         }).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(ComplaintDTO complaintDTO)
        {
            await db.Complaints.AddAsync(new Complaint
            {
                Id = complaintDTO.Id,
                Email = complaintDTO.Email,
                Mobile = complaintDTO.Mobile,
                Name = complaintDTO.Name,
                Zone = complaintDTO.Zone,
                Note = complaintDTO.Note,
                Station_Id = complaintDTO.Station_Id,
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
    }
}
