using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sahm.Server.Data
{
    public class Center
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid User_Id { get; set; }
        public string Type { get; set; } = string.Empty;

        [ForeignKey(nameof(User_Id))]
        public AppUser appUser { get; set; }
    }
}
