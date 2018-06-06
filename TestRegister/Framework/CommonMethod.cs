using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using System.Resources;


namespace TestRegister.Framework
{
    public class CommonMethod
    {
        public ResourceManager rm = new ResourceManager("TestRegister.Resource.Resource1", Assembly.GetExecutingAssembly());


        [AssemblyInitialize]
        //Launch application
        public IWebDriver LaunchApplication()
        {
            IWebDriver driver;
            string browsertype = GetControlConfig("browser");
            switch (browsertype)
            {
                case "IE":
                    {
                        driver = new InternetExplorerDriver();
                        break;
                    }
                case "Firefox":
                    {
                        driver = new FirefoxDriver();
                        break;
                    }
                case "Chrome":
                default:
                    {
                        driver = new ChromeDriver();
                        break;
                    }
            }

            driver.Navigate().GoToUrl(GetControlConfig("URL"));
            driver.Manage().Window.Maximize();

            return driver;
        }

        public void Hover(IWebDriver driver, By elementClause)
        {
            var element = driver.FindElement(elementClause);

            bool wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20))
                .Until(d => d.FindElement(elementClause).Enabled  
                            && d.FindElement(elementClause).Displayed);

            Actions action = new Actions(driver);
                     

            action.MoveToElement(element).Perform();
            //Waiting for the menu to be displayed    
            System.Threading.Thread.Sleep(4000);

           
            action.MoveToElement(driver.FindElement(elementClause)).Perform();
        }

        public void HoverAndClick(IWebDriver driver, By element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(element)).Click().Build().Perform();
        }

        //CLick on Element
        public void ClickOn(IWebDriver driver, By element)
        {
            driver.FindElement(element).Click();
        }

        //Enter value in any field
        public void InputValue(IWebDriver driver, By element, string val)
        {
            driver.FindElement(element).SendKeys(val);
        }

        //Get value from any text field
        public string GetValue(IWebDriver driver, By element)
        {
            string eleValue = driver.FindElement(element).GetAttribute("Value");
            return eleValue;
        }

        //Tab functionality
        public void Tabfunction(IWebDriver driver, By element)
        {
            driver.FindElement(element).SendKeys(Keys.Tab);
        }

        //Select value from dropdown
        public void SelectValueFromDropdown(IWebDriver driver, By element, string Elevalue)
        {
            IWebElement Dropdownelement = driver.FindElement(element);
            SelectElement selectdropdown = new SelectElement(Dropdownelement);
            selectdropdown.SelectByValue(Elevalue);
        }


        //Fetch value from Resource file
        public string GetControlConfig(string config)
        {
            string valuefromresourcefile = rm.GetString(config);
            return valuefromresourcefile;
        }

        public bool FindElementForAnyLocater(IWebDriver driver, By id)
        {
            try
            {
                driver.FindElement(id);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //Close the browser        
        public void CloseBrowser(IWebDriver driver)
        {
            driver.Close();
        }

    }
}
