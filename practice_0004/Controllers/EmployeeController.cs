using Dapper;
using practice_0004.Dapper;
using practice_0004.method;
using practice_0004.Models;
using practice_0004.ModelView;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModelView model)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            PublisherList(items);
            model.PublisherItems = items;

            if (InfoNoError(model))
            {
                if (Emp_idIsExist(model.EmployeeList.Emp_ID))
                {
                    model.EmployeeList.Emp_ID = string.Empty;
                    TempData["message"] = "Employee ID 已存在，請更換!";
                    return View(model);
                }
                else
                {
                    TempData["message"] = "新增成功!";
                    return RedirectToAction("Index", "Employee");
                }

            }
            else
            {
                TempData["message"] = "尚有欄位未填寫、日期格有誤、Age或Salary為零!";
                return View(model);
            }
            

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

        public bool InfoNoError(EmployeeModelView method)
        {
            bool result;
            DateTime dateTime;

            if (string.IsNullOrEmpty(method.EmployeeList.Emp_ID))
                result = false;
            else if (string.IsNullOrEmpty(method.EmployeeList.FName))
                result = false;
            else if (string.IsNullOrEmpty(method.EmployeeList.LName))
                result = false;
            else if (method.EmployeeList.Age == 0)
                result = false;
            else if (!DateTime.TryParse(method.EmployeeList.BirthDay.ToString(), out dateTime))
                result = false;
            else if (!DateTime.TryParse(method.EmployeeList.Hire_date.ToString(), out dateTime))
                result = false;
            else if (string.IsNullOrEmpty(method.EmployeeList.Address))
                result = false;
            else if (method.EmployeeList.salary == 0)
                result = false;
            else
                result = true;

            return result;
        }

        public bool Emp_idIsExist(string Emp_id)
        {
            bool Exist;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiRoute"].ToString());

                var responseTask = client.GetAsync("EmployeeAPI/"+ Emp_id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<PersonAPI0001ViewMode>>();
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    Exist = bool.Parse(readTask.Result);


                }
                else //web api sent error response
                {

                    Exist = false;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return Exist;
        }
    }
}