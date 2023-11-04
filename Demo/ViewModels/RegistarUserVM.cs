using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class RegistarUserVM
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }



    }
}
