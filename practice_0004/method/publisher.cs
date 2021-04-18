using practice_0004.Dapper;
using practice_0004.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practice_0004.method
{
    public class publisher
    {
        public IEnumerable<PublishersModel> PublisherList()
        {
            return DapperORM.ReturnList<PublishersModel> ("publishersViewAll");
        }
    }
}