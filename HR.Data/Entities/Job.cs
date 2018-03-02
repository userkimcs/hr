using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace HR.Data.Entities
{
    public class Job : BaseEntity
    {
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public double MinSalary { get; set; }
        [Required]
        public double MaxSalary { get; set; }

        // Employee works job
        public virtual ICollection<Employee> EmployeesWork { get; set; }

        // Job history 
        public virtual ICollection<JobHistory> HistoryJobs { get; set; }

        // Department
        public virtual ICollection<Department> WorkedDepartments { get; set; }
    }
}
