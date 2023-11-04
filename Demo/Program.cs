using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // built in service and already register in ioc cantainer >>"Iconfguration" 
            // built in service but not  register in ioc cantainer  >>"Add session"
            builder.Services.AddControllersWithViews(
                //conf=>conf.Filters.Add()
                );

            builder.Services.AddSession(conf =>
            {
                conf.IdleTimeout=TimeSpan.FromSeconds(10);
            });

            builder.Services.AddDbContext<ITIDDbContext>(OptionsBuilder =>
            {
                OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUsers, IdentityRole>(Options =>
            {
                Options.Password.RequireUppercase = false;
                Options.Password.RequireDigit = false;
            }).
                AddEntityFrameworkStores<ITIDDbContext>();
            // custom service
            builder.Services.AddScoped< IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped< IEmployeeRepository,EmployeeRepository>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();//>> default

            app.UseAuthentication();
            app.UseAuthorization();//>> check cookie
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}