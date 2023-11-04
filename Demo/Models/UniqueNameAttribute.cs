using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;


namespace Demo.Models
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        public string msg { get; set; }
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
           
        {
            Employee employee =(Employee) validationContext.ObjectInstance;
            
            string name = value.ToString();
            ITIDDbContext dbContext = new ITIDDbContext();
           Employee emp=  dbContext.Employees.FirstOrDefault(x => x.Name == name);
            if (emp == null)// Name Is Unique
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already found");
           // return base.IsValid(value, validationContext);
        }
    }
}
