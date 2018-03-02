
using HR.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.Data.Mapping
{
    public class AttendanceMap : EntityTypeConfiguration<Attendance>
    {
        public AttendanceMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AttendanceId");
            Property(t => t.Day);
            Property(t => t.Morning);
            Property(t => t.Afternoon);

            ToTable("Attendances");

            HasRequired(t => t.Employee)
                .WithMany(c => c.Attedances)
                .HasForeignKey(t => t.EmployeeId).WillCascadeOnDelete(false); 
        }
    }
}
