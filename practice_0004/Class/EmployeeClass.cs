using Newtonsoft.Json;
using practice_0004.ModelView;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace practice_0004.Class
{
    public class EmployeeClass
    {
        public bool Emp_idIsExist(string Emp_id)
        {
            bool Exist;
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiRoute"].ToString());
                client.BaseAddress = new Uri("https://localhost:44313/api/");
            
                var responseTask = client.GetAsync("EmployeeAPI/" + Emp_id);
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

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return Exist;
        }

        public bool AddOrEditSuccessful(EmployeeModelView model)
        {
            bool result;

            using (var client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiRoute"].ToString());
                client.BaseAddress = new Uri("https://localhost:44313/api/");

                var responseTask = client.PostAsync("EmployeeAPI/", data);
                responseTask.Wait();

                var R = responseTask.Result;
                if (R.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<PersonAPI0001ViewMode>>();
                    var readTask = R.Content.ReadAsStringAsync();
                    readTask.Wait();

                    result = bool.Parse(readTask.Result);


                }
                else //web api sent error response
                {

                    result = false;

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return result;
        }

        public bool DeleteSuccessful(string emp_id)
        {
            bool result;

            using (var client = new HttpClient())
            {

                //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiRoute"].ToString());
                client.BaseAddress = new Uri("https://localhost:44313/api/");

                var responseTask = client.DeleteAsync("EmployeeAPI/" + emp_id);
                responseTask.Wait();

                var R = responseTask.Result;
                if (R.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<IList<PersonAPI0001ViewMode>>();
                    var readTask = R.Content.ReadAsStringAsync();
                    readTask.Wait();

                    result = bool.Parse(readTask.Result);


                }
                else //web api sent error response
                {

                    result = false;

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return result;
        }
    }
}