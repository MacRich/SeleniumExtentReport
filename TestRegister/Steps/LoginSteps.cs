using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestRegister.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RelevantCodes.ExtentReports;
using TestRegister.PageFiles;

namespace TestRegister.Steps
{
    [TestClass]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPageFile lpf;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

            BasicReport.StartReport("LoginSteps");
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


        }

        [TestMethod]
        public void a1CheckWhetherLoginPageLoaded()
        {
            bool result = lpf.FindElementForAnyLocater(driver, By.Id("frmLogin"));

            BasicReport.PrintMessageExtension(result == true);

            Assert.AreEqual(result, true);

        }


        [TestMethod]
        public void a2CheckWhetherLoginPageHaveUsernameTextbox()
        {


            //apply
            bool result = lpf.FindElementForAnyLocater(driver, lpf.username_textbox);

            BasicReport.PrintMessageExtension(result == true);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void a3CheckWhetherLoginPageHavePasswordTextbox()
        {
            bool result = lpf.FindElementForAnyLocater(driver, lpf.password_textbox);

            BasicReport.PrintMessageExtension(result == true);
            Assert.AreEqual(lpf.FindElementForAnyLocater(driver, lpf.password_textbox), true);
        }



        [TestMethod]
        public void a4CheckWhetherLoginPageHaveLoginButtonTextbox()
        {
            bool result = lpf.FindElementForAnyLocater(driver, lpf.login_button);

            BasicReport.PrintMessageExtension(result == true);
            Assert.AreEqual(lpf.FindElementForAnyLocater(driver, lpf.login_button), true);
        }

        [TestMethod]
        public void a5VerifyValidationisfiredonenteringInvalidUsername()
        {
            lpf.InvalidUsername(driver);
            bool result = lpf.FindElementForAnyLocater(driver, lpf.validation);

            BasicReport.PrintMessageExtension(result == true);
            Assert.AreEqual(lpf.FindElementForAnyLocater(driver, lpf.validation), true);
        }

        [TestMethod]
        public void a6VerifyValidationisfiredonenteringInvalidPassword()
        {
            lpf.InvalidPassword(driver);
            bool result = lpf.FindElementForAnyLocater(driver, lpf.validation);

            BasicReport.PrintMessageExtension(result == true);
            Assert.AreEqual(lpf.FindElementForAnyLocater(driver, lpf.validation), true);
        }


        [TestMethod]

        public void a7VerfiyCorrectUsernamePasswordGiven()
        {

            lpf.LoginUser(driver);

            bool result = lpf.FindElementForAnyLocater(driver, lpf.title);

            BasicReport.PrintMessageExtension(result == true);
            Assert.AreEqual(lpf.FindElementForAnyLocater(driver, lpf.title), true);

            //string Menutext = driver.FindElement(lpf.title
            //    ).Text;

            //if (Menutext.Equals("Welcome Admin"))
            //{
            //    BasicReport.test.Log(LogStatus.Pass, "Assert Pass as Condition is True");
            //}
            //else
            //{
            //    BasicReport.test.Log(LogStatus.Fail, "Assert Fail as Condition is False");
            //}
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
