
using HR.Core.Contracts;
using HR.Data.Entities;
using HR.Web.ViewModels;
using System.Web.Mvc;
using System.Linq;
using System;
using HR.Core.Helpers;
namespace HR.Web.Controllers
{
     [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private ILocationService _locationService;
        private IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService _employeeService, ILocationService _locationService,
            IDepartmentService _departmentService)
        {
            this._employeeService = _employeeService;
            this._locationService = _locationService;
            this._departmentService = _departmentService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(this._employeeService.GetAllEmployee());
        }
         #region Create
        public ActionResult Create()
        {
            ViewModels.CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            model.Cities.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            model.Districts.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            model.Towns.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            model.Departments.Add(new SelectListItem { Text = "-Please select-", Value = "Selects items" });
            var cities = _locationService.GetCities();
            foreach (var city in cities)
            {
                model.Cities.Add(new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.Id.ToString()
                });
            }
            // Get all departments to select list
            var deparments = _departmentService.GetAllDepartments();
            foreach (var department in deparments)
            {
                model.Departments.Add(new SelectListItem()
                {
                    Text = department.DepartmentName,
                    Value = department.Id.ToString()
                });
            }
            ViewBag.Days = DateTimeHelper.GetDate();
            ViewBag.Months = DateTimeHelper.GetMonth();
            ViewBag.Years = DateTimeHelper.GetYear();
            ViewBag.Sex = ListHelper.CreateSex();
            return View(model);
        }

        // Post 
        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel model)
        {
            try
            {
                // Get name 
                string city = _locationService.GetCity(System.Convert.ToInt64(model.CityId)).Name;
                string district = _locationService.GetDistrict(System.Convert.ToInt64(model.DistrictId)).Name;
                string town = _locationService.GetTown(System.Convert.ToInt64(model.TownId)).Name;
                long departmentId = System.Convert.ToInt64(model.DepartmentId);

                // Get department 
                var department = _departmentService.GetDepartmentById(departmentId);
                // string day = model.DayOfBirth;
                // Create new employee
                var employee = EntityFactory.CreateEmployee(model.FirstName, model.LastName,
                    model.IdCard, model.Email, model.PhoneNumber,
                    city, district, town, DateTimeHelper.CreateDate(model.DayOfBirth, model.MonthOfBirth, model.YearOfBirth), 
                    DateTimeHelper.CreateDate(model.HireDay, model.HireMonth, model.HireYear), 
                    model.Sex.ToString(), department);
                // Insert to DB
                bool insertResult = _employeeService.AddNewEmployee(employee);
                if (insertResult == true)
                { 
                    // Return list employees
                    return RedirectToAction("Index");
                }
                else
                {
                    JsHelper.Alert("Khong hop le");
                    return View();
                }
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
            return View(_employeeService.GetEmployeeById(id));
        }
        #endregion 
        #region Update
        // Get 
        public ActionResult Edit(long id)
        {
            return View(_employeeService.GetEmployeeById(id));
        }
        // Post 
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            try
            {
                _employeeService.UpdateEmployee(e);
                return RedirectToAction("Index", "Employee");
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
                Employee e = _employeeService.GetEmployeeById(id);
                _employeeService.DeleteEmployee(e);
                return RedirectToAction("Index", "Employee");
            }
            catch
            {
                return View("Error");
            }
        }
        #endregion 
   

        // Get district by city Id 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDistrictByCityId(string CityId)
        {
            if (String.IsNullOrEmpty(CityId))
            {
                throw new ArgumentNullException("CityId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CityId, out id);
            var districts = _locationService.GetDistrictsByCity(id);
            var result = (from s in districts
                          select new
                          {
                              id = s.Id,
                              name = s.Name
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetTownByDistrictId(string DistrictId)
        {
            if (String.IsNullOrEmpty(DistrictId))
            {
                throw new ArgumentNullException("DistrictId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(DistrictId, out id);
            var towns = _locationService.GetTownsByDistrict(id);
            var result = (from s in towns
                          select new
                          {
                              id = s.Id,
                              name = s.Name
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Search(string SearchName, string SearchId)
        {
            return View(_employeeService.SearchEmployee(SearchName, SearchId));
        }
    }

}