using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIDDbContext _db= new ITIDDbContext();
        IDepartmentRepository DepartRepository;//= new DepartmentRepository();
        IEmployeeRepository EmployeeRepository;// = new EmployeeRepository();

        // immplement (Id) injection
        public DepartmentController(IDepartmentRepository departRepository,
            IEmployeeRepository employeeRepository)
        {
            DepartRepository = departRepository;
            EmployeeRepository = employeeRepository;
        }

        public IActionResult ShowDepts()
        {
            List<Department> depts = new List<Department>();
            depts = DepartRepository.GetAll();
            return View(depts);

        }
        public IActionResult GetEmpPerDept(int idept)
        {
            List<Employee> employees = EmployeeRepository.GetByDeptId(idept);

            return Json(employees);
        }
     
        public IActionResult Index()
        {
            List<Department> departments= DepartRepository.GetAll();


            return View(departments);
        }
        [HttpGet]
        public IActionResult New()
        {

            return View(new Department());
        }
        [HttpPost]
        public IActionResult SaveNew(Department dpt)
        {
            if (dpt.Name != null)
            {
                DepartRepository.Insert(dpt);
                return RedirectToAction("Index");
            }
            return View("New",dpt);
        }
    }
}
