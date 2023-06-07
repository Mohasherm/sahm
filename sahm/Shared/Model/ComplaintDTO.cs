using System.ComponentModel.DataAnnotations;

namespace sahm.Shared.Model
{
    public class ComplaintDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Mobile { get; set; } = string.Empty;
        [Required]
        public string Zone { get; set; } = string.Empty;
        public int Station_Id { get; set; }
        [Required]
        public string Note { get; set; } = string.Empty;
        public string CenterName { get; set; } = string.Empty;

    }
}
