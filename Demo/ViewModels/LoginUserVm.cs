using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class LoginUserVm
    {
        [Required]
        public string UserName { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        public bool RemmberMe { get; set;}
    }
}
