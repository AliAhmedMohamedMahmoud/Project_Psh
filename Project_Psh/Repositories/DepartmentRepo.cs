using Project_Psh.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project_Psh.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext db_Context;
        public DepartmentRepo(AppDbContext db_Context)
        {
            this.db_Context = db_Context;
        }
        public List<Department> GetAllDepartment() => db_Context.Departments.ToList();
        public Department GetDepartmentById(int id) => db_Context.Departments.SingleOrDefault(d => d.Id == id);
    }
}
