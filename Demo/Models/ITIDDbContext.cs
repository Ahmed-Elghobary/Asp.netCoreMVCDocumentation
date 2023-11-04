using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ITIDDbContext:IdentityDbContext<ApplicationUsers>
    {
        public ITIDDbContext() : base()
        {

        }

        // inject
        public ITIDDbContext(DbContextOptions options) : base(options)
        {

        }
       public DbSet<Department>  Departments { get; set; }
       public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GNA35PN;Database=Major;Trusted_Connection=True;");
        }
    }
}
