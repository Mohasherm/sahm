using System.ComponentModel.DataAnnotations;

namespace sahm.Server.Data
{
    public class TankOperation
    {
        [Key]
        public int Id { get; set; }
        public int? Tank_Id { get; set; }
        public double InQTY { get; set; } = 0;
        public double OutQTY { get; set; } = 0;
        public DateTime Date{ get; set; } = DateTime.Now;
    }
}
