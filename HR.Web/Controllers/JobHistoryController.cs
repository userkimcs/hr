

using HR.Core.Contracts;
using HR.Data.Entities;
using System.Web.Mvc;
namespace HR.Web.Controllers
{
     [Authorize]
    public class JobHistoryController : Controller
    {
        private IJobHistoryService _jobHistoryService;
        public JobHistoryController(IJobHistoryService _jobHistoryService)
        {
            this._jobHistoryService = _jobHistoryService;
        }
        // GET: JobHistory
        public ActionResult Index()
        {
            return View(this._jobHistoryService.GetAllJobHistoys());
        }
 
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(JobHistory model)
        {
            try
            {
                _jobHistoryService.AddJobHistoy(model);
                return RedirectToAction("Index", "JobHistory");
            }
            catch
            {
                return View("Error");
            }
        }
        #region Update
        public ActionResult Edit(long id)
        {
            return View(_jobHistoryService.GetJobHistoyById(id));
        }
        [HttpPost]
        public ActionResult Edit(JobHistory j)
        {
            try
            {
                _jobHistoryService.UpdateJobHistoy(j);
                return RedirectToAction("Index", "JobHistory");
            }
            catch 
            {
                return View("Error");
            }
        }
        #endregion
        #region Delete
        public ActionResult Delete(long id)
        {
            try
            {
                var model = _jobHistoryService.GetJobHistoyById(id);
                _jobHistoryService.DeleteJobHistoy(model);
                return RedirectToAction("Index", "JobHistory");
            }
            catch 
            {
                return View("Error");
            }

        }

        #endregion
    }
}