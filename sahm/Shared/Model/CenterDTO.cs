using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class CenterDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid User_Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
    }
}
