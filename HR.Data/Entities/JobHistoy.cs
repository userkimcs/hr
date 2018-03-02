

using System;
using System.ComponentModel.DataAnnotations;
namespace HR.Data.Entities
{
    public class JobHistory : BaseEntity
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Job 
        public long? JobId { get; set; }
        public Job Job { get; set; }

        // Employee 
        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } // Lazy loading
    }

}
