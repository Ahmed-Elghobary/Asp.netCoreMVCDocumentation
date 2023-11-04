using Microsoft.AspNetCore.Identity;

namespace Demo.Models
{
    public class ApplicationUsers:IdentityUser
    {
        public string Address { get; set; }
    }
}
