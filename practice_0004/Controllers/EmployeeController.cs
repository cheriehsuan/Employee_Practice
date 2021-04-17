using Dapper;
using practice_0004.Dapper;
using practice_0004.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice_0004.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewAll"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(string Emp_ID)
        {
            if(string.IsNullOrEmpty(Emp_ID))
                return View();
            else
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmployeeID", Emp_ID);
                return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewByEmpID", dynamicParameters).FirstOrDefault<EmployeeModel>());
            }
        }

       
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}