using Demo.Models;

namespace Demo.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
       
        List<Department> GetAllWithEmployeeName();
        
         Department GetById(int id);
        
        void Insert(Department department);
        
        void Update(int id, Department NewDepart);

        void Delete(int id);
        
    }
}
