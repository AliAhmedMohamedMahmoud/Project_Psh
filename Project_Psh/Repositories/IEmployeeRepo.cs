using Project_Psh.Model;
using System.Collections.Generic;

namespace Project_Psh.Repositories
{
    public interface IEmployeeRepo
    {
        int AddEmployee(Employee Employee);
        int DeleteEmployee(int id);
        Employee EditEmployee(int id, Employee Employee);
        List<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);
    }
}