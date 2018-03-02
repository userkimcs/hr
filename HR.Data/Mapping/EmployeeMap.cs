using HR.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.Data.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            #region Properties
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("EmployeeId");
            // Update 1
            Property(t => t.Address);
            Property(t => t.BirthDay);
            Property(t => t.BirthPlace);
            Property(t => t.Email);
            Property(t => t.FirstName);
            Property(t => t.HighestDegree);
            Property(t => t.HireDate);
            Property(t => t.IdCard);
            Property(t => t.LastName);
            Property(t => t.PhoneNumber);
            Property(t => t.Sex);
            ToTable("Employees");
            #endregion
            // Job 
            HasMany(t => t.JobsWork).WithMany(c => c.EmployeesWork)
                                .Map(t => t.ToTable("Employee_Work_Job")
                                    .MapLeftKey("EmployeeId")
                                    .MapRightKey("JobId"));
            // Department
            HasRequired(t => t.Department)
                .WithMany(c => c.EmployeesWork)
                .HasForeignKey(t => t.DepartmentId).WillCascadeOnDelete(false); 
        }
    }
}
