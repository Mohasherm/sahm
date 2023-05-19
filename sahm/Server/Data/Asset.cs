using System.ComponentModel.DataAnnotations;

namespace sahm.Server.Data
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
