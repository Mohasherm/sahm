using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class TankOperationDTO
    {
        public int Id { get; set; }
        public int? Tank_Id { get; set; }
        public double InQTY { get; set; } = 0;
        public double OutQTY { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
