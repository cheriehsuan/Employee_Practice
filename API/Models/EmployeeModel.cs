using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EmployeeModel
    {
        public string Emp_ID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public DateTime Hire_date { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int salary { get; set; }

        public DateTime BirthDay { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Pub_Name { get; set; }

    }
}