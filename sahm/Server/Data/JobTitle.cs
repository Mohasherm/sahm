using System.ComponentModel.DataAnnotations;

namespace sahm.Server.Data
{
    public class JobTitle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
