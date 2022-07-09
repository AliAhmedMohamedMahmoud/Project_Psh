using Project_Psh.Model;
using System.Collections.Generic;

namespace Project_Psh.Repositories
{
    public interface IDepartmentRepo
    {
        List<Department> GetAllDepartment();
        Department GetDepartmentById(int id);
    }
}