using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIDDbContext _db;//= new ITIDDbContext();

        public DepartmentRepository(ITIDDbContext db)
        {
            _db = db;
        }

        public List<Department> GetAll()
        {
            List<Department> list = new List<Department>();
            list = _db.Departments.ToList();
            return list;
        }
        public List<Department> GetAllWithEmployeeName()
        {
            return _db
                .Departments.Include(e=>e.Employees).ToList();
        }
        public Department GetById(int id)
        {
            Department dept = _db.Departments.FirstOrDefault(x => x.Id == id);
            return dept;
        }
        public void Insert(Department department)
        {
            if (department.Name != null)
            {
                _db.Departments.Add(department);
                _db.SaveChanges();
            }


        }
        public void Update(int id, Department NewDepart)
        {
            Department oldDept = GetById(id);
            oldDept.Name = NewDepart.Name;
            oldDept.MangerName= NewDepart.MangerName;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            _db.Departments.Remove(dept);
            _db.SaveChanges();
        }
    }
}
