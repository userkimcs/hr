

using HR.Data.Entities;
using System.Collections.Generic;
namespace HR.Core.Contracts
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(long id);
        void AddDepartment(Department d);
        void DeteleDepartment(Department d);
        void UpdateDepartment(Department d);

        void AddJob(Department d, Job job);

        List<Employee> GetAllEmployeeInDepartment(long departmentId);

    }
}
