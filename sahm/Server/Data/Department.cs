using System.ComponentModel.DataAnnotations;

namespace sahm.Shared.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
