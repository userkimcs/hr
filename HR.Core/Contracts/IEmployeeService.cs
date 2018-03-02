using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Contracts
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployee();
        Employee EmployeeDetails(long id);
        Employee GetEmployeeById(long id);
        bool AddNewEmployee(Employee e);
        void UpdateEmployee(Employee e);
        void DeleteEmployee(Employee e);
        List<Employee> SearchEmployee(string by, Func<Employee, bool> expression);

        List<Employee> SearchEmployee(string name, string id);
    }
}
