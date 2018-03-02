using HR.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.Data.Mapping
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("JobId");
            Property(t => t.JobTitle);
            Property(t => t.MaxSalary);
            Property(t => t.MinSalary);
            ToTable("Jobs");
        }
    }
}
