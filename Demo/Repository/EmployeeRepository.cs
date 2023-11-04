using Demo.Models;

namespace Demo.Repository
{
    //CRUD Opreation 

    public class EmployeeRepository:IEmployeeRepository
    {
        ITIDDbContext _db;//= new ITIDDbContext();

        public EmployeeRepository(ITIDDbContext db)
        {
            _db = db;
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            list = _db.Employees.ToList();
            return list;
        }
        public Employee GetById(int id) 
        {
            Employee emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            return emp;
        }
        public List<Employee> GetByDeptId(int deptId)
        {
            List<Employee> employees= _db.Employees.Where(x=>x.Dept_ID == deptId).ToList();
            return employees;
        }
        public void Insert(Employee employee)
        {
            if (employee.Name != null)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
            }

           
        }
        public void Update(int id,Employee NewEmployee)
        {
          Employee oldEmp=  GetById(id);
            oldEmp.Name = NewEmployee.Name;
            oldEmp.Address = NewEmployee.Address;
            oldEmp.Dept_ID= NewEmployee.Dept_ID;
            oldEmp.Image= NewEmployee.Image;
            oldEmp.Salary= NewEmployee.Salary;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee emp = GetById(id);
            _db.Employees.Remove(emp);
            _db.SaveChanges();
        }
    }
}
