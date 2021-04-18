using Dapper;
using practice_0004.Dapper;
using practice_0004.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace practice_0004.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        public EmployeeAPIController()
        {

        }

        // GET: api/EmployeeAPI
        public IEnumerable<EmployeeModel> Get()
        {
            return DapperORM.ReturnList<EmployeeModel>("EmployeeViewAll");
        }

        // GET: api/EmployeeAPI/5
        public bool Get(string Emp_id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EmployeeID", Emp_id);
            return !string.IsNullOrEmpty(DapperORM.ReturnList<string>("EmployeeViewByEmpID", dynamicParameters).FirstOrDefault());
        }

        // POST: api/EmployeeAPI
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EmployeeAPI/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/EmployeeAPI/5
        public void Delete(int id)
        {
        }
    }
}
