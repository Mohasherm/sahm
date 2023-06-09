using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Msessage { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Guid User_Id { get; set; }

    }
}
