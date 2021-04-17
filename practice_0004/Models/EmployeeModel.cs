using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace practice_0004.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID (員工編號)")]
        public string Emp_ID { get; set; }

        [Display(Name = "First Name (名字)")]
        public string FName { get; set; }

        [Display(Name = "Last Name (姓)")]
        public string LName { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Hire_date { get; set; }

        public string City { get; set; }

        public string  Country { get; set; }

        public int salary { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        [Display(Name = "Pub Name")]
        public string Pub_Name { get; set; }

    }
}