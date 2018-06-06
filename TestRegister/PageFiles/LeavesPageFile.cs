using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TestRegister.Framework;

namespace TestRegister.PageFiles
{
    class LeavesPageFile : CommonMethod
    {
        //Menu items
        public  By leavemenu = By.XPath("//a[@id='menu_leave_viewLeaveModule']");

        //Hover over Reports submenu first
        public  By reportsmenu = By.Id("menu_leave_Reports");
        //Configure
        //public static By ConfigureMenu = By.XPath("//a[@id='menu_leave_viewLeaveModule']/../ul//a[@id='menu_leave_Configure'] ");
        public  By configureMenu = By.XPath("//a[@id='menu_leave_Configure']");
        //Leave TYpes
        public  By leavetypesMenu = By.XPath("//a[@id='menu_leave_leaveTypeList']");
        //Button
        public  By addButton = By.XPath("//*[@id='btnAdd']");
        //LeaveType Name textbox
        public  By leavetypeName = By.Id("leaveType_txtLeaveTypeName");
        //Save button
        public  By savebutton = By.Id("saveButton");

        public By deletebuton = By.Id("btnDelete");

        public By newlyaddedLeavetype = By.XPath("//a[text()='SickLeave']");
        public By newlyaddedCheckbox = By.Id("ohrmList_chkSelectRecord_5");

        public By confirmOKbutton = By.Id("dialogDeleteBtn");
        public void AddLeaveType(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            System.Threading.Thread.Sleep(2000);
            Hover(driver, leavemenu);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            ClickOn(driver, leavemenu);

            System.Threading.Thread.Sleep(6000);
            Hover(driver, reportsmenu);
            
            Hover(driver, configureMenu);   

            Hover(driver, leavetypesMenu);
            
            ClickOn(driver, leavetypesMenu);
            System.Threading.Thread.Sleep(9000);

            ClickOn(driver, addButton);
            InputValue(driver, leavetypeName, GetControlConfig("LeaveName"));
            ClickOn(driver, savebutton);
            //"Successfully Saved"
        }

        public void DeleteNewlyaddedleavetype(IWebDriver driver)
        {
            Hover(driver, newlyaddedLeavetype);
            ClickOn(driver, newlyaddedCheckbox);
            ClickOn(driver, deletebuton);
        }

        public void Confirmdeletion(IWebDriver driver)
        {
            ClickOn(driver, confirmOKbutton);
        }
    }
}
