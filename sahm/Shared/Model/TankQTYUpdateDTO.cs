using System.ComponentModel.DataAnnotations;

namespace sahm.Shared.Model
{
    public class TankQTYUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public double QTY { get; set; }
        public string OperationType { get; set; } = string.Empty;
    }
}
