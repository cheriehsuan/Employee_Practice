using practice_0004.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice_0004.ModelView
{
    public class EmployeeModelView
    {
        public List<SelectListItem> PublisherItems { get; set; }
        public EmployeeModel EmployeeList { get; set; }
    }
}