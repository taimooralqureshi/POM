using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace POM
{


    public class LoginPage : BasePage
    {
        By txtUsername = By.Id("username");
        By txtPassword = By.Id("password");
        By btnLogin = By.Id("login");

        public string username { get; set; }
        public string password { get; set; }
        public void Login()
        {
            if (username != null)
            {
                EnterText(txtUsername, username);
            }
            if (password != null)
            {
                EnterText(txtPassword, password);
            }
            Click(btnLogin);

        }
    }
}
