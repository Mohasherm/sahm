using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(Tank_Id))]
        public Tank Tank{ get; set; }
    }
}
