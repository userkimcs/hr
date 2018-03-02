using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
namespace HR.Data.Entities
{
    public class Department : BaseEntity
    {
        [Required]
        public string DepartmentName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> EmployeesWork { get; set; }

        // Job 
        public virtual ICollection<Job> WorkedJobs { get; set; }
    }

}
