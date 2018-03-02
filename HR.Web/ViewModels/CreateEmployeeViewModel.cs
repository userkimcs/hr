using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public string IdCard { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int CityId { get; set; }
        public List<SelectListItem> Cities { get; set; }
        [Required]
        public int DistrictId { get; set; }
        public List<SelectListItem> Districts { get; set; }
        [Required]
        public int TownId { get; set; }
        public List<SelectListItem> Towns { get; set; }
        public string DayOfBirth { get; set; }
        public string MonthOfBirth { get; set; }
        public string YearOfBirth { get; set; }
        public string HireDay { get; set; }
        public string HireMonth { get; set; }
        public string HireYear { get; set; }

        [Required]
        public string DepartmentId { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public CreateEmployeeViewModel()
        {
            Cities = new List<SelectListItem>();
            Districts = new List<SelectListItem>();
            Towns = new List<SelectListItem>();
            Departments = new List<SelectListItem>();
        }
    }
}