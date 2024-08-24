using System.ComponentModel.DataAnnotations;

namespace SmallEcommerceProject.ViewModel
{
    
    public class RegisterViewModel
    {
        
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        public string PasswordHash { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
