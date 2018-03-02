
using HR.Data.Entities;
using System.Collections.Generic;
namespace HR.Web.ViewModels
{
    public class EmployeesInDepartmentViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<bool?> Mornings { get; set; }
        public List<bool?> Afternoons { get; set; }
        public EmployeesInDepartmentViewModel()
        {
            Employees = new List<Employee>();
            Mornings = new List<bool?>();
            Afternoons = new List<bool?>();
        }
    }
}