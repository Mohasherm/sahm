using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sahm.Server.Data
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Zone { get; set; } = string.Empty;
        public int Station_Id { get; set; }
        public string Note { get; set; } = string.Empty;

        [ForeignKey(nameof(Station_Id))]
        public Center Center { get; set; }
    }
}
