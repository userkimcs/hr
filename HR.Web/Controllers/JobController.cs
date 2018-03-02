

using HR.Core.Contracts;
using HR.Data.Entities;
using System.Web.Mvc;
namespace HR.Web.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private IJobService _jobService;

        public JobController(IJobService _jobService)
        {
            this._jobService = _jobService; // Dependency injection 
        }

        // GET: Job
        public ActionResult Index()
        {
            return View(_jobService.GetAllJob());
        }
        #region Create
        public ActionResult Create()
        {
            return View();
        }

        // Post 
        [HttpPost]
        public ActionResult Create(Job model)
        {
            try
            {
                _jobService.AddNewJob(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        #endregion
        #region Details
        // Get 
        public ActionResult Details(long id)
        {
            return View(_jobService.GetJobById(id));
        }
        #endregion 
        #region Update
        // Get 
        public ActionResult Edit(long id)
        {
            return View(_jobService.GetJobById(id));
        }
        // Post 
        [HttpPost]
        public ActionResult Edit(Job j)
        {
            try
            {
                _jobService.UpdateJob(j);
                return RedirectToAction("Index", "Job");
            }
            catch
            {
                return View("Error");
            }
        }
        #endregion 

        #region delete
        public ActionResult Delete(long id)
        {
            try
            {
                Job j = _jobService.GetJobById(id);
                _jobService.DeleteJob(j);
                return RedirectToAction("Index", "Job");
            }
            catch
            {
                return View("Error");
            }
        }
        #endregion 
    }
}