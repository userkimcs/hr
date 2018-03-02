using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public class Attendance : BaseEntity 
    {
        public DateTime? Day { get; set; }
        public bool Morning { get; set; }
        public bool Afternoon { get; set; }

        public long? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Attendance()
        {
            Day = System.DateTime.Today;
            Morning = false;
            Afternoon = false;
            EmployeeId = 0;
        }
    }
}
