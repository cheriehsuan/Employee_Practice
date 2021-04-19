using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using practice_0004.Class;
using Xunit;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrage
            var EmployeeClass = new EmployeeClass();

            //Act
            var Result = EmployeeClass.Emp_idIsExist("test22223");

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(Result);
        }

        //[Theory]
        //[InlineData("test22223", true)]
        //[InlineData("test22223", false)]
        //public void TestMethod2(string Emp_id, bool Result)
        //{
        //    //Arrage
        //    var EmployeeClass = new EmployeeClass();

        //    //Act
        //    var test = EmployeeClass.Emp_idIsExist(Emp_id);

        //    //Assert
        //    if (Result)
        //        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(test);
        //    else
        //        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(test);
        //}

    }
}
