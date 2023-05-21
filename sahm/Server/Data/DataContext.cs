using Microsoft.AspNetCore.Identity;
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

      
    
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CenterAsset> centerAssets{ get; set; }
    }
}
