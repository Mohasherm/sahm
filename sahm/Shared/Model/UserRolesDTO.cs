using System.ComponentModel.DataAnnotations;

namespace sahm.Shared.Model
{
    public class UserRolesDTO
    {
        public Guid User_Id { get; set; }
        [Required]
        public string RoleName{ get; set; }
    }
}
