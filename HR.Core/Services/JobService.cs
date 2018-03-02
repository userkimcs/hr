

using HR.Core.Contracts;
using HR.Data.Contracts;
using HR.Data.Entities;
namespace HR.Core.Services
{
    public class JobService : IJobService
    {
        private IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> _jobRepository)
        {
            this._jobRepository = _jobRepository;
        }




        public System.Collections.Generic.List<Job> GetAllJob()
        {
            return _jobRepository.GetAll();
        }

        public void AddNewJob(Job j)
        {
            _jobRepository.Insert(j);
        }

        public void UpdateJob(Job j)
        {
            _jobRepository.Update(j);
        }

        public void DeleteJob(Job j)
        {
            _jobRepository.Delete(j);
        }


        public Job GetJobById(long id)
        {
            return _jobRepository.GetById(id);
        }
    }
}
