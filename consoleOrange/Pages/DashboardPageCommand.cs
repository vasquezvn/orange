using OpenQA.Selenium;
using System;

namespace consoleOrange.Pages
{
    public class DashboardPageCommand
    {
        private string FirstName;
        private string LastName;
        private string Location;

        public enum LocationOptions
        {
            NewYorkSalesOffice,
            LondonOffice,
            AustralianRegionalHQ,
        }

        #region IWebWElements
        private static IWebElement txtFirstName => Driver.Instance.FindElement(By.Id("firstName"));
        private static IWebElement txtLastName => Driver.Instance.FindElement(By.Id("lastName"));
        private static IWebElement selectDropdownLocation => Driver.Instance.FindElement(By.Id("location_inputfileddiv"));
        private static IWebElement btnNext => Driver.Instance.FindElement(By.Id("systemUserSaveBtn"));
        

        #endregion


        public DashboardPageCommand(string FirstName)
        {
            this.FirstName = FirstName;
        }

        public DashboardPageCommand WithLastName(string LastName)
        {
            this.LastName = LastName;

            return this;
        }

        public DashboardPageCommand WithLocation(LocationOptions option)
        {
            try
            {
                Helper.WaitUntilElementExists(By.Id("location_inputfileddiv"));
            }
            catch(Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Location Dropdown WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }
            

            switch (option)
            {
                case LocationOptions.AustralianRegionalHQ:
                    try
                    {
                        selectDropdownLocation.Click();
                        Helper.getWebElementFromDropdown(selectDropdownLocation, "li", "Australian Regional HQ").Click();
                    }
                    catch(Exception ex)
                    {
                        Helper.TakeErrorScreenshot();
                        throw new Exception($"Location Dropdown WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
                    }
                    
                    break;
            }

            return this;
        }

        public void PressNextButton()
        {
            try
            {
                txtFirstName.SendKeys(FirstName);
            }
            catch(Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"First Name WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }

            try
            {
                txtLastName.SendKeys(LastName);
            }
            catch(Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Last Name WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }

            try
            {
                btnNext.Click();
            }
            catch(Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Next button WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }
        }
    }
}
