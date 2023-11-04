using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
      //  ITIDDbContext _db= new ITIDDbContext();
         IEmployeeRepository EmployeeRepository;
        IDepartmentRepository DepartmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }

        public IActionResult AjaxDetail(int id)
            
        {   Employee emp= EmployeeRepository.GetById(id);

            return PartialView("_CardPartial",emp);
        }
        public IActionResult Detail (int idd)
        {
            return View(EmployeeRepository.GetById(idd));
        }
        public IActionResult CheckSalary(int Salary)
        {
            if(Salary > 2000)
            {
                return Json(true);
            }
            return Json(false);
        }
        [Authorize]
        public IActionResult Index()
        {
            var Employees= EmployeeRepository.GetAll();
            return View(Employees);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewBag.Deptlist=DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeRepository.Insert(employee);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                    // key the name of property exist in model  "Sapan"
                    // key the name of property exist in model  "Div"
                }
                
            }
            ViewBag.Deptlist = DepartmentRepository.GetAll();

            return View("New",employee);
        }
        public IActionResult Edit(int idd)
        {
           var EmployeeModel =EmployeeRepository.GetById(idd);
            ViewData["deptList"] = DepartmentRepository.GetAll();
            return View(EmployeeModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id,Employee emp)
        {
            if (emp.Name != null)
            {
                var OldEmp = EmployeeRepository.GetById(id);
                if (ModelState.IsValid)
                {
                  //  _db.Employees.Update(OldEmp);
                    EmployeeRepository.Update(id, emp);
                }
                return RedirectToAction("Index");
            }
            ViewData["deptList"] = DepartmentRepository.GetAll();

            return View(emp);
        }
    }
}
