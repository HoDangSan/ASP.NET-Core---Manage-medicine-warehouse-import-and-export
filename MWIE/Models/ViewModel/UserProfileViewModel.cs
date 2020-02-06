using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MWIE.Models.Entity;

namespace MWIE.Models.ViewModel
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        
        public string Address { get; set; }
        
        [EmailAddress] 
        public string Email { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }
        
        [DefaultValue("true")]
        public string IsActive { get; set; }
    }
    
    public class UserProfileViewModelEdit
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        [EmailAddress] 
        public string Email { get; set; }

        public string Sex { get; set; }

        public string Phone { get; set; }
        
        [DefaultValue("true")]
        public bool IsActive { get; set; }
    }
}