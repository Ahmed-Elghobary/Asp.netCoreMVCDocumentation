using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModels
{
    public class RoleVM
    {
        [Required]
        public string RolrName { get; set; }
    }
}
