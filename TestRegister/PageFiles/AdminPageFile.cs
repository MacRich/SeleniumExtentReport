using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestRegister.Framework;

namespace TestRegister.PageFiles
{
    public class AdminPageFile : CommonMethod
    {
        public By _adminmenu = By.Id("menu_admin_viewAdminModule");

        public By _usermanagementmenu = By.Id("menu_admin_UserManagement");

        public By _usersmenu = By.Id("menu_admin_viewSystemUsers");
        public By _addButton = By.Id("btnAdd");

        //Adduser page locators
        public By _empName = By.Id("systemUser_employeeName_empName");
        public By _userName = By.Id("systemUser_userName");
        public By _userPassword = By.Id("systemUser_password");
        public By _confirmPassword = By.Id("systemUser_confirmPassword");
        public By _userSave = By.Id("btnSave");
        public By _userCancel = By.Id("btnCancel");

        //toverify
        public By _elementcheckall = By.Id("ohrmList_chkSelectAll");
        public void GoToUsers(IWebDriver driver)
        {
            Hover(driver, _adminmenu);
            Thread.Sleep(3000);
            Hover(driver, _usermanagementmenu);
            Thread.Sleep(3000);
            Hover(driver, _usersmenu);
            ClickOn(driver, _usersmenu);
        }

        public void Addbuttonclick(IWebDriver driver)
        {
            ClickOn(driver, _addButton);
            Thread.Sleep(3000);
        }

        public void ESSUserDetails(IWebDriver driver)
        {
            InputValue(driver, _empName, GetControlConfig("employeeName"));
            InputValue(driver, _userName, GetControlConfig("empuserName"));
            InputValue(driver, _userPassword, GetControlConfig("empuserPassword"));
            InputValue(driver, _confirmPassword, GetControlConfig("empuserConfirmpassword"));
            Thread.Sleep(3000);
        }

        public void ClickSaveUserbutton(IWebDriver driver)
        {
            ClickOn(driver, _userSave);
        }

        public void ClickCancelUserbutton(IWebDriver driver)
        {
            ClickOn(driver, _userCancel);
        }
    }
}
