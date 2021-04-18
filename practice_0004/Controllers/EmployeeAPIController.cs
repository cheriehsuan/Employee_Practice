using Dapper;
using practice_0004.Dapper;
using practice_0004.Models;
using practice_0004.ModelView;
using System;
using System.Collections.Generic;
using System.Data;
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
        public bool Post(EmployeeModelView model)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            
            dynamicParameters.Add("@Emp_id", model.EmployeeList.Emp_ID);
            dynamicParameters.Add("@FName", model.EmployeeList.FName);
            dynamicParameters.Add("@LName", model.EmployeeList.LName);
            dynamicParameters.Add("@hire_date", model.EmployeeList.Hire_date);
            dynamicParameters.Add("@salary", model.EmployeeList.salary);
            dynamicParameters.Add("@Age", model.EmployeeList.Age);
            dynamicParameters.Add("@BirthDay", model.EmployeeList.BirthDay);
            dynamicParameters.Add("@Address", model.EmployeeList.Address);
            dynamicParameters.Add("@pub_id", model.EmployeeList.pub_id);
            dynamicParameters.Add("@foo", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
           
            DapperORM.ExecuteWithoutReturn("EmployeeAddOrEdit", dynamicParameters);

            int result = dynamicParameters.Get<int>("@foo");

            return result == 1 ? true : false;
        }

        // PUT: api/EmployeeAPI/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/EmployeeAPI/5
        public bool Delete(string emp_id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Emp_id", emp_id);
            dynamicParameters.Add("@foo", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            DapperORM.ExecuteWithoutReturn("EmployeeDeleteByID", dynamicParameters);

            int result = dynamicParameters.Get<int>("@foo");

            return result == 1 ? true : false;
        }
    }
}
