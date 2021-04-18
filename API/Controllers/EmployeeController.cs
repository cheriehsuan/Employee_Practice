using API.Dapper;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class EmployeeController : ApiController
    {
        public EmployeeController()
        {
           
        }

        // GET: api/Employee
        public IEnumerable<EmployeeModel> Get()
        {
            return DapperORM.ReturnList<EmployeeModel>("EmployeeViewAll");
        }

        // GET: api/Employee/5
        public bool Get(string Emp_id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EmployeeID", Emp_id);
            return !string.IsNullOrEmpty(DapperORM.ReturnList<string>("EmployeeViewByEmpID", dynamicParameters).FirstOrDefault());
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
