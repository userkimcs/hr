

using HR.Data.Entities;
using System.Collections.Generic;
namespace HR.Core.Contracts
{
    public interface IJobHistoryService
    {
        List<JobHistory> GetAllJobHistoys();
        JobHistory GetJobHistoyById(long id);
        void AddJobHistoy(JobHistory j);
        void UpdateJobHistoy(JobHistory j);
        void DeleteJobHistoy(JobHistory j);
    }
}
