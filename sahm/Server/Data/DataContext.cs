using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sahm.Shared.Models;

namespace sahm.Server.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRole>().HasData(
                new AppRole("SuperAdmin"),
                new AppRole("MaintenanceAdmin"),
                new AppRole("QulityAdmin"),
                new AppRole("BuyAdmin"),
                new AppRole("SuperVisor"),
                new AppRole("User")                
                );
            base.OnModelCreating(builder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Center> Centers { get; set; }
    }
}
