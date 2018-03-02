
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace HR.Data.Entities
{
    public enum Sex
    {
        Male = 1, Female = 2
    };
    
    public enum Position
    {
        Head = 1, // Truong phong 
        Vice = 2, // Pho phong
        Leader = 3, // Truong nhom
        Staff = 4 // Nhan vien
    }

    public class Employee : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        [Required]
        public Sex Sex { get; set; }
        public DateTime? BirthDay { get; set; }
        public string BirthPlace { get; set; }
        [Required]
        public string IdCard { get; set; }
        public string HighestDegree { get; set; }
        public Position Position { get; set; }
        // Jobs employee works
        public virtual ICollection<Job> JobsWork { get; set; }
        public long? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        // Job histrory 
        public virtual ICollection<JobHistory> WorkedJobs { get; set; }
        // Attendance
        public virtual ICollection<Attendance> Attedances { get; set; }
    }
}
