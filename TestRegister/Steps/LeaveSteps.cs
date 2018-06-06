using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRegister.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using TestRegister.PageFiles;
using System.Threading;

namespace TestRegister.Steps
{
    [TestClass]
    public class LeaveSteps : CommonMethod
    {
        private IWebDriver driver;
        private LoginPageFile lpf;
        private LeavesPageFile leavepf;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

            BasicReport.StartReport("AddLeaveType");
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
            leavepf = new LeavesPageFile();
            leavepf.AddLeaveType(driver);

        }

        [TestMethod]
        public void c1VerifyuserisonLeaveTypespage()
        {
            bool result = leavepf.FindElementForAnyLocater(driver, leavepf.leavetypesMenu);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void c2VerifyAddButtonisPresent()
        {
            bool result = leavepf.FindElementForAnyLocater(driver, leavepf.addButton);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void c3VerifyDeleteButtonisPresnt()
        {
            bool result = leavepf.FindElementForAnyLocater(driver, leavepf.deletebuton);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }


        [TestMethod]
        public void c4VerifyLeavetypeadded()
        {
            bool result = leavepf.FindElementForAnyLocater(driver, leavepf.newlyaddedLeavetype);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void c5VerifyNewlyaddedLeavetypeisdeleted()
        {
            leavepf.DeleteNewlyaddedleavetype(driver);
            bool result = leavepf.FindElementForAnyLocater(driver, leavepf.confirmOKbutton);

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void c6VerifyNewlyaddedLeavetypeisdeleted()
        {
            leavepf.Confirmdeletion(driver);
            bool result = leavepf.FindElementForAnyLocater(driver, leavepf.newlyaddedLeavetype);

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
