using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web.ViewModels
{
    public class AddJobForDepartmentViewModel
    {
        public Department Department { get; set; }
        public string JobId { get; set; }
        public List<SelectListItem> Jobs { get; set; }

        public AddJobForDepartmentViewModel()
        {
            this.Jobs = new List<SelectListItem>();
        }
        
        public AddJobForDepartmentViewModel(Department Department, List<Job> Jobs)
        {
            this.Department = Department;
            this.Jobs = new List<SelectListItem>();
            foreach(Job j in Jobs)
            {
                this.Jobs.Add(
                    new SelectListItem
                    {
                        Text = j.JobTitle,
                        Value = j.Id.ToString()
                    });
            }
        }
    }
}