using HR.Core.Contracts;
using HR.Data.Entities;
using HR.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web.Controllers
{
     [Authorize]
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        private IJobService _jobService;
        private IAttendanceService _attendanceService;
        public DepartmentController(IDepartmentService _departmentService, IJobService _jobService,
            IAttendanceService _attendanceService)
        {
            this._departmentService = _departmentService;
            this._jobService = _jobService;
            this._attendanceService = _attendanceService;

        }
        // GET: Department
        public ActionResult Index()
        {
            return View(_departmentService.GetAllDepartments());
        }
        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department model)
        {
            try
            {
                _departmentService.AddDepartment(model);
                return RedirectToAction("Index", "Department");
            }
            catch
            {
                return View("Error");
            }

        }
        #endregion

        #region Edit
        // Get
        public ActionResult Edit(long id)
        {

            return View(_departmentService.GetDepartmentById(id));
        }

        [HttpPost]
        public ActionResult Edit(Department model)
        {
            try
            {
                _departmentService.UpdateDepartment(model);
                return RedirectToAction("Index", "Department");
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
                var department = _departmentService.GetDepartmentById(id);
                _departmentService.DeteleDepartment(department);
                return RedirectToAction("Index", "Department");
            }
            catch
            {
                return View("Error");
            }
        }
        #endregion 
        #region details 
        public ActionResult Details(long id)
        {
            try
            {

                return View(_departmentService.GetDepartmentById(id));
            }
            catch
            {
                return View("Error");
            }
        }

        #endregion 
        #region Add job for department
        public ActionResult NewJob(long id)
        {
            Department d = _departmentService.GetDepartmentById(id);
            List<Job> jobs = _jobService.GetAllJob();
            AddJobForDepartmentViewModel model = new AddJobForDepartmentViewModel(d, jobs);
            return View(model);
        }
        [HttpPost]
        public ActionResult NewJob(AddJobForDepartmentViewModel model)
        {
            try
            {
                long departmentId = System.Convert.ToInt64(Url.RequestContext.RouteData.Values["id"]);
                Department department = _departmentService.GetDepartmentById(departmentId);
                long jobId = System.Convert.ToInt64(model.JobId);
                Job j = _jobService.GetJobById(jobId);
                _departmentService.AddJob(department, j);
                return RedirectToAction("Details", "Department", new { id = departmentId });
            }
            catch
            {
                return View();
            }
        }
        #endregion 
        #region List employees 
        public ActionResult ListEmployee(long id)
        {
            return View(_departmentService.GetAllEmployeeInDepartment(id));
        }
        #endregion 
        #region roll up
        public ActionResult MorningRollUp(long empId, long id)
        {
            _attendanceService.MorningRollUp(empId);
            return RedirectToAction("ListEmployee", new { id = id });
        }

        public ActionResult AfternoonRollUp(long empId, long id)
        {
            _attendanceService.AfternoonRollUp(empId);
            return RedirectToAction("ListEmployee", new { id = id });
        }
        #endregion 
    }
}