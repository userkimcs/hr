

using HR.Core.Contracts;
using HR.Data.Contracts;
using HR.Data.Entities;
namespace HR.Core.Services
{
    public class JobHistoryService : IJobHistoryService
    {
        private IRepository<JobHistory> _jobHistoyRepository;
        public JobHistoryService(IRepository<JobHistory> _jobHistoyRepository)
        {
            this._jobHistoyRepository = _jobHistoyRepository;
        }

        public System.Collections.Generic.List<JobHistory> GetAllJobHistoys()
        {
            return this._jobHistoyRepository.GetAll();
        }

        public JobHistory GetJobHistoyById(long id)
        {
            return this._jobHistoyRepository.GetById(id);
        }

        public void AddJobHistoy(JobHistory j)
        {
            _jobHistoyRepository.Insert(j);
        }

        public void UpdateJobHistoy(JobHistory j)
        {
            _jobHistoyRepository.Update(j);
        }

        public void DeleteJobHistoy(JobHistory j)
        {
            _jobHistoyRepository.Delete(j);
        }
    }

}
