using HR.Core.Contracts;
using HR.Data.Contracts;
using System.Linq;
using HR.Data.Entities;
using System.Collections.Generic;
using System;

namespace HR.Core.Services
{
    public class EmployeeService : IEmployeeService
    {   
        
        private IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> _employeeRepository)
        {
            this._employeeRepository = _employeeRepository;
        }

        public System.Collections.Generic.List<Data.Entities.Employee> GetAllEmployee()
        {
            return this._employeeRepository.GetAll();
        }

        public Data.Entities.Employee EmployeeDetails(long id)
        {
            return this._employeeRepository.GetById(id);
        }

        public bool AddNewEmployee(Data.Entities.Employee e)
        {
            if (e.HireDate.Value.Year > e.BirthDay.Value.Year)
            { 
                this._employeeRepository.Insert(e);
                return true; // Insert successfull
            }
            else
            {
                return false;
            }
        }

        public void UpdateEmployee(Data.Entities.Employee e)
        {
            this._employeeRepository.Update(e);
        }

        public void DeleteEmployee(Data.Entities.Employee e)
        {
            this._employeeRepository.Delete(e);
        }

        public System.Collections.Generic.List<Data.Entities.Employee> SearchEmployee(string by, System.Func<Data.Entities.Employee, bool> expression)
        {
            return null;
        }

        private List<Employee> SearchByName(string name)
        {
            return this._employeeRepository.Search(t => t.FirstName.ToLower() == name.ToLower());
        }


        public Employee GetEmployeeById(long id)
        {
            return this._employeeRepository.GetById(id);
        }


        public List<Employee> SearchEmployee(string name, string id)
        {
            List<Employee> results = new List<Employee>();
            if (null != name)
            {
                results = _employeeRepository.Search(t => t.FirstName.ToLower() == name.ToLower() 
                    || t.LastName.ToLower() == name.ToLower());
            }
            if (id != String.Empty)
            {
                Employee e = _employeeRepository.GetById(System.Convert.ToInt64(id));
                if (e != null)
                {
                    results.Add(e);
                }
            }
            return results;
        }
    }
}
