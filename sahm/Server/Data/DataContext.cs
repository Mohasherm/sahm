using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace sahm.Server.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CenterAsset> CenterAssets{ get; set; }
        public DbSet<Tank> Tanks{ get; set; }
        public DbSet<TankOperation> TankOperations { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Notification> Notifications{ get; set; }
    }
}
