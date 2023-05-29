using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sahm.Shared.Model
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password not match")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public int? JobTitle { get; set; }
        [Required]
        public string Mobile { get; set; } = string.Empty;
        public string PicURL { get; set; } = string.Empty;
      //  public MultipartFormDataContent content { get; set; } = new();
    }
}
