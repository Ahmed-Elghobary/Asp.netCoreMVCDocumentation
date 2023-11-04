using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PassDataController : Controller
    {
        ITIDDbContext db= new ITIDDbContext();
        public IActionResult TestViewData()
        {
            return View();
        }

        public IActionResult TestViewModel(int id)
        {
            var EmpModel= db.Employees.FirstOrDefault(x=>x.Id==id);
            EmployeeVM EmployeeVM = new EmployeeVM();
            EmployeeVM.Message = "Hello";
            EmployeeVM.color = "red";
            EmployeeVM.Temp = 10;
            EmployeeVM.EmployeeName = EmpModel.Name;
            EmployeeVM.EmployeeId = EmpModel.Id;

            return View(EmployeeVM);
        }
    }
}
