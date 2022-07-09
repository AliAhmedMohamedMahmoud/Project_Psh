using Project_Psh.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project_Psh.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext db_Context;

        public EmployeeRepo(AppDbContext db_Context)
        {
            this.db_Context = db_Context;
        }
        public List<Employee> GetAllEmployee() => db_Context.Employees.ToList();

        public Employee GetEmployeeById(int id) => db_Context.Employees.SingleOrDefault(E => E.Id == id);

        public int AddEmployee(Employee Employee)
        {
            db_Context.Employees.Add(Employee);
            return db_Context.SaveChanges();
        }

        public Employee EditEmployee(int id, Employee Employee)
        {
            Employee _Employee = GetEmployeeById(id);
            if (_Employee != null)
            {
                _Employee.FirstName = Employee.FirstName;
                _Employee.LastName = Employee.LastName;
                _Employee.Phone = Employee.Phone;
                _Employee.BirthDate = Employee.BirthDate;
                _Employee.DeptId = Employee.DeptId;
                db_Context.SaveChanges();
                return Employee;
            }
            return null;
        }
        public int DeleteEmployee(int id)
        {
            Employee Employee = GetEmployeeById(id); //db_Context.Employees.SingleOrDefault(E => E.Id == id);
            if (Employee != null)
            {
                db_Context.Employees.Remove(Employee);
                return db_Context.SaveChanges();
            }
            return 0;
        }

    }
}
