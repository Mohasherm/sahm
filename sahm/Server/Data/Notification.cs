using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sahm.Server.Data
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Msessage { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Guid User_Id { get; set; }

        [ForeignKey(nameof(User_Id))]
        public AppUser appUser { get; set; }
    }
}
