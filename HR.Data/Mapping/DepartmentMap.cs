
using HR.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace HR.Data.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            #region Properties
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("DepartmentId");
            Property(t => t.DepartmentName);
            Property(t => t.Location);

            ToTable("Departments");
            #endregion
            // Job 
            HasMany(t => t.WorkedJobs).WithMany(c => c.WorkedDepartments)
                                .Map(t => t.ToTable("Department_Work_Job")
                                    .MapLeftKey("DepartmentId")
                                    .MapRightKey("JobId")); 
        }
    }
}
