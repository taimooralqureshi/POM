using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace POM
{
    [TestClass]
    public class Execution : BasePage
    {
        private TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {

            LogReport("Test_Report");
            Console.WriteLine("AssemblyInitialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            ExtentFlush();
            Console.WriteLine("AssemblyCleanup");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            exParentTest = extentReports.CreateTest(TestContext.TestName);
            NodeCreation(TestContext.TestName);
            InitializeBrowser("CHROME");
            OpenUrl("https://adactinhotelapp.com/");
        }

        [TestCleanup]
        public void TestCleanup()
        {
           QuitBrowser();
        }
    }
}
