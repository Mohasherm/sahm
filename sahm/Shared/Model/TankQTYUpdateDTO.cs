using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class TankQTYUpdateDTO
    {
        public int Id { get; set; }
        public double QTY { get; set; }
        public string OperationType { get; set; } = string.Empty;
    }
}
