using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace API.Dapper
{
    public class DapperORM
    {
        private static string connectionString = File.ReadAllText(ConfigurationManager.AppSettings["SecIniPath"].ToString());

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters dynamicparameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, dynamicparameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        // DapperORM.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters dynamicparameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.Execute(procedureName, dynamicparameters, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }


        // DapperORM.ReturnList<EmployeeModel> <= IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters dynamicparameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, dynamicparameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}