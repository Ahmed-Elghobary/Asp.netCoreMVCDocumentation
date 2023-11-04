using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3),MaxLength(50)]
        [UniqueName(msg ="Ay haga")]
        public string Name { get; set; }
        [RegularExpression(@"[0-9]{4}",ErrorMessage ="Salary Must be 4 Numbers")]
        [Range(2000,6000)]
        [Remote("CheckSalary","Employee",ErrorMessage ="Salary Must Greater than 2000")]
        public int Salary { get; set; }
        [Required]
        [RegularExpression("(Alex|Menia|Sohag)",ErrorMessage ="Adress must be Alex or menia or sohag")]
        public string? Address { get; set; }
        [RegularExpression(@"[a-z]\.(jpg|png)" ,ErrorMessage =$"must be char and extension {"jpg"} {"png"} ")]
        public string Image { get; set; }
        [ForeignKey("department")]
        [Display(Name ="Department")]
        public int Dept_ID { get; set; }
        public virtual Department? department { get; set; }
            
    }
}
