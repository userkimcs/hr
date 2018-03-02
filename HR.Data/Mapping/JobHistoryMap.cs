using HR.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HR.Data.Mapping
{
    public class JobHistoryMap : EntityTypeConfiguration<JobHistory>
    {
        public JobHistoryMap()
        {
            #region Properties
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("JobHistoryId");
            Property(t => t.EndDate);
            Property(t => t.StartDate);
            ToTable("JobHistorys");
            #endregion

            // Job
            HasRequired(t => t.Job)
                .WithMany(c => c.HistoryJobs)
                .HasForeignKey(t => t.JobId).WillCascadeOnDelete(false); 

            // Employee
            HasRequired(t => t.Employee)
                .WithMany(c => c.WorkedJobs)
                .HasForeignKey(t => t.EmployeeId).WillCascadeOnDelete(false); 
        }
    }
}
