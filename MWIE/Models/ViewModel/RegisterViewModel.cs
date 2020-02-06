using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class RegisterViewModel
    {   
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required] public string UserName { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be least 6 character long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage = "Password must be least 6 character long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string EnterPassWord { get; set; }
    }
}