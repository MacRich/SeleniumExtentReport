using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestRegister.Framework;

namespace TestRegister.PageFiles
{
    public class LoginPageFile : CommonMethod
    {
        public By username_textbox = By.Id("txtUsername");
        public By password_textbox = By.Id("txtPassword");
        public By login_button = By.Id("btnLogin");

        public By title = By.Id("welcome");
        public By validation = By.Id("spanMessage");

        // This method is used to login the application

        public void InvalidUsername(IWebDriver driver)
        {

            InputValue(driver, username_textbox, GetControlConfig("InvalidUsername"));
            InputValue(driver, password_textbox, GetControlConfig("LoginPassword"));
            ClickOn(driver, login_button);
        }

        public void InvalidPassword(IWebDriver driver)
        {

            InputValue(driver, username_textbox, GetControlConfig("LoginUsername"));
            InputValue(driver, password_textbox, GetControlConfig("InvalidPassword"));
            ClickOn(driver, login_button);
        }
        public void LoginUser(IWebDriver driver)
        {

            InputValue(driver,username_textbox, GetControlConfig("LoginUsername"));
            InputValue(driver, password_textbox, GetControlConfig("LoginPassword"));
            ClickOn(driver, login_button);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(GetControlConfig("Dashboard"));
        }




    }
}
