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
    }
}