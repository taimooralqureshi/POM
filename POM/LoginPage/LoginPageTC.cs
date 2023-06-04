using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace POM
{
    [TestClass]
    public class LoginPageTC : Execution
    {
        LoginPage loginPage = new LoginPage();
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "abc.csv", "abc#csv", DataAccessMethod.Sequential)]


        [TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Login.csv", "Login#csv", DataAccessMethod.Sequential)]
        public void LoginWithValidUserValidPassword()
        {
            //string user = TestContext.DataRow[0].ToString();
            //string pass = TestContext.DataRow[1].ToString();
            loginPage.username = "ZuniraQ1";
            loginPage.password = "4VS622";
            Thread.Sleep(1000);
            loginPage.Login();
        }
    }
}
