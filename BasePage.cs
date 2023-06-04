using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace POM
{
    
    public class BasePage
    {
        public static  IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath = @"E:\ExtentReports" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "\\";


        public static void LogReport(string Testcase)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);

            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            htmlReporter.Config.ReportName = "Hotal " + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            htmlReporter.Config.Theme = Theme.Dark;
            
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);

            //Info box in report dashboard
            extentReports.AddSystemInfo("AUT", "Hotel Adactin");
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("Machine", Environment.MachineName);
            extentReports.AddSystemInfo("OS", Environment.OSVersion.VersionString);


        }
        public void NodeCreation(string methodname)
        {
            exChildTest = exParentTest.CreateNode(methodname);
        }

        public void TakeScreenshot(Status status, string stepDetail)
        {
            string path = dirpath + "TestLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            exChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
            
        }

        public static void ExtentFlush()
        {
            extentReports.Flush();
        }
        public static void InitializeBrowser(string browser)
        {
            if (browser == "CHROME")
            {
                IWebDriver chromedriver = new ChromeDriver();
                driver = chromedriver;
            }
            else if (browser == "EDGE")
            {
                IWebDriver edgedriver = new EdgeDriver(EdgeDriverService.CreateDefaultService(".", "msedgedriver.exe"));
                driver = edgedriver;

            }
            else if (browser == "FIREFOX")
            {
                IWebDriver firefoxdriver = new FirefoxDriver();
                driver = firefoxdriver;
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);


        }
        //public void InitializeChrome()
        //{
        //    driver = new ChromeDriver();
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        //}
        public void EnterText(By by, string value)
        {
            try
            {
                driver.FindElement(by).SendKeys(value);
                TakeScreenshot(Status.Pass, "Text on " + by + " is " + value );
            }
            catch (Exception ex)
            { 
                TakeScreenshot(Status.Fail , "Send Text Failed" + ex.ToString());
            }
        }


        public void OpenUrl(string url)
        {
          driver.Navigate().GoToUrl(url);
        }

        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass , "Click on" + by);
            }
            catch (Exception ex) 
            {
                TakeScreenshot(Status.Fail, "Click Failed" + ex.ToString());
            }
        }
        public void DropDown(By by, int index)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(by));
            dropdown.SelectByIndex(index);
            TakeScreenshot(Status.Pass, "Select " + by + " on Index " + index);
        }
        public void DropDownByText(By by ,string text)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(by));
            dropdown.SelectByText(text);
            TakeScreenshot(Status.Pass, "Select " + by + " on Index " + text);
        }


        public void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }


        public void QuitBrowser()
        {
            driver.Quit();
        }


    }
}
