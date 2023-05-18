using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class CenterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid User_Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
