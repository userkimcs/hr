

using HR.Data.Entities;
using System.Collections.Generic;
namespace HR.Core.Contracts
{
    public interface IJobService
    {
        List<Job> GetAllJob();
        Job GetJobById(long id);
        void AddNewJob(Job j);
        void UpdateJob(Job j);
        void DeleteJob(Job j);
    }
}
