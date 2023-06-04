using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace POM
{
    [TestClass]
    public class SearchPageTC :Execution
    {
        SearchPage searchPage = new SearchPage();
        LoginPageTC loginPageTC = new LoginPageTC();
        [TestMethod]
        public void ValidSearch()
        {
            loginPageTC.LoginWithValidUserValidPassword();

            searchPage.location = 4;
            searchPage.hotels = 3;
            searchPage.roomType = 3;
            searchPage.roomNos = "6 - Six";

            searchPage.dateIn = "03/08/2023";

            searchPage.dateOut = "05/08/2023";
            searchPage.adultRoom = 2;
            searchPage.childRoom = 3;


            searchPage.Search();
        }
    }
}
