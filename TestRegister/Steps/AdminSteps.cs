using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestRegister.Framework;
using TestRegister.PageFiles;

namespace TestRegister.Steps
{
    [TestClass]
    public class AdminSteps : CommonMethod
    {
        private IWebDriver driver;
        private LoginPageFile lpf;
        private AdminPageFile aps;

        [ClassInitialize()]
        public static void ClassIniti(TestContext context)
        {

            BasicReport.StartReport("AdminPage");
            Thread.Sleep(50000);
        }

        [TestInitialize]
        public void TestInitilze()
        {
            //report loaded
            System.Threading.Thread.Sleep(5000);

            //page loaded
            lpf = new LoginPageFile();
            driver = lpf.LaunchApplication();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            lpf.LoginUser(driver);
            aps = new AdminPageFile();
            aps.GoToUsers(driver);
        }

        [TestMethod]
        public void dVerifyUserisonAdminPage()
        {
            bool result = aps.FindElementForAnyLocater(driver, aps._elementcheckall);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestCleanup]
        public void EndReport()
        {
            lpf.CloseBrowser(driver);
            driver.Quit();

        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            BasicReport.EndReport();
        }
    }
}
