using HR.Core.Contracts;
using HR.Data.Contracts;
using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> _departmentRepository)
        {
            this._departmentRepository = _departmentRepository;
        }


        public List<Department> GetAllDepartments()
        {
            return this._departmentRepository.GetAll();
        }

        public Department GetDepartmentById(long id)
        {
            return this._departmentRepository.GetById(id);
        }

        public void AddDepartment(Department d)
        {
            _departmentRepository.Insert(d);
        }

        public void DeteleDepartment(Department d)
        {
            _departmentRepository.Delete(d);
        }

        public void UpdateDepartment(Department d)
        {
            _departmentRepository.Update(d);
        }


        public void AddJob(Department d, Job job)
        {
            d.WorkedJobs.Add(job);
            _departmentRepository.Update(d);
        }


        public List<Employee> GetAllEmployeeInDepartment(long departmentId)
        {
            return _departmentRepository.GetAll()
                .Where(t => t.Id == departmentId)
                .SelectMany(p => p.EmployeesWork).ToList();
        }
    }
}
