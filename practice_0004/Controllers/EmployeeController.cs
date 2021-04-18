using Dapper;
using practice_0004.Dapper;
using practice_0004.method;
using practice_0004.Models;
using practice_0004.ModelView;
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
            //publisher
            List<SelectListItem> items = new List<SelectListItem>();
            PublisherList(items);

            var model = new EmployeeModelView();

            model.PublisherItems = items;

            if (string.IsNullOrEmpty(Emp_ID))
            {
                model.EmployeeList = new EmployeeModel();
            }
            else
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EmployeeID", Emp_ID);
                //return View(DapperORM.ReturnList<EmployeeModel>("EmployeeViewByEmpID", dynamicParameters).FirstOrDefault<EmployeeModel>());
                model.EmployeeList = DapperORM.ReturnList<EmployeeModel>("EmployeeViewByEmpID", dynamicParameters).FirstOrDefault<EmployeeModel>();
            }

            return View(model);
        }

       
        public ActionResult AddOrEdit()
        {
            return View();
        }

        private void PublisherList(List<SelectListItem> items)
        {
            publisher publisher = new publisher();

            IEnumerable<PublishersModel> List = publisher.PublisherList();

            foreach (var item in List)
            {
                items.Add(new SelectListItem
                {
                    Text = item.pub_name,
                    Value = item.pub_id+";"+ item.city+";"+ item.state+";"+ item.country,
                    Selected = item == List.First()?true:false
                });
            }
        }
    }
}