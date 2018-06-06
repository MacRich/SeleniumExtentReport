using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestRegister.PageFiles;

namespace TestRegister.Steps
{
    [TestClass]
    public class DashboardSteps
    {
        private IWebDriver driver;
        private DashboardPageFile dpf;
        private LoginPageFile login;

        [ClassInitialize()]
        public static void ClassIniti(TestContext context)
        {
            BasicReport.StartReport("DashboardMenu");
            Thread.Sleep(50000);
        }

        [TestInitialize]
        public void TestInitilze()
        {
            //page loaded
            dpf = new DashboardPageFile();
            driver=dpf.LaunchApplication();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            login = new LoginPageFile();
            login.LoginUser(driver);
        }

        [TestMethod]
        public void b1VerifyDashboardMenuisdispalyed()
        {
            bool result = dpf.FindElementForAnyLocater(driver, dpf.dashboardmenu);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void b2VerifyDashboardPanel1isPresent()
        {
            bool result = dpf.FindElementForAnyLocater(driver, dpf.dashboardpanel);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void b3VerifyDashboardPanel2isPresent()
        {
            bool result = dpf.FindElementForAnyLocater(driver, dpf.panel2);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }


        [TestMethod]
        public void b4VerifyDashboardDisplayGraphisPresent()
        {
            bool result = dpf.FindElementForAnyLocater(driver, dpf.displaygraph);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);

            dpf.CloseBrowser(driver);
        }

        [TestCleanup]
        public void EndReport()
        {

            driver.Quit();

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            BasicReport.EndReport();
        }
    }

}
