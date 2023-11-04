using Demo.Models;

namespace Demo.Repository
{
    public interface IEmployeeRepository
    {
         List<Employee> GetAll();
       
         Employee GetById(int id);
       
        List<Employee> GetByDeptId(int deptId);
        
         void Insert(Employee employee);
       
         void Update(int id, Employee NewEmployee);

         void Delete(int id);
       
    }
}
