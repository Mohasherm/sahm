using System.ComponentModel.DataAnnotations;

namespace sahm.Server.Data
{
    public class Tank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Center_Id { get; set; }
        public double QTY { get; set; } = 0;
    }
}
