using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class AddEmployeePageCommand
    {
        public enum LocationOptions
        {
            NewYorkSalesOffice,
            LondonOffice,
            AustralianRegionalHQ,
        }

        #region Locators
        private By locatorDropDown => By.Id("location_inputfileddiv");
        private By locatorTxtFirstName => By.Id("firstName");
        private By locatorBtnNext => By.Id("systemUserSaveBtn");
        #endregion

        #region IWebWElements
        private IWebElement txtFirstName => Driver.Instance.FindElement(locatorTxtFirstName);
        private IWebElement txtLastName => Driver.Instance.FindElement(By.Id("lastName"));
        private IWebElement btnNext => Driver.Instance.FindElement(locatorBtnNext);
        private IWebElement selectDropdownLocation => Driver.Instance.FindElement(locatorDropDown);
        private ReadOnlyCollection<IWebElement> btnsOnAddform => Driver.Instance.FindElements(By.XPath("//form[@id='pimAddEmployeeForm']/div[@class='modal-footer']/a"));

        #endregion

        public AddEmployeePageCommand() { }

        public AddEmployeePageCommand AddEmployeeAs(string firstName)
        {
            Helper.WaitUntilElementExists(locatorTxtFirstName, 20);

            try
            {
                txtFirstName.SendKeys(firstName);
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"First Name WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public AddEmployeePageCommand WithLastName(string lastName)
        {
            try
            {
                txtLastName.SendKeys(lastName);
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Last Name WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public AddEmployeePageCommand WithLocation(LocationOptions option)
        {
            Helper.ClickAndWaitForPageToLoad(selectDropdownLocation);

            switch (option)
            {
                case LocationOptions.AustralianRegionalHQ:
                    try
                    {
                        selectDropdownLocation.Click();
                        Helper.getWebElementFromDropdown(selectDropdownLocation, "Australian Regional HQ").Click();
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

        internal bool IsButtonDisplayed(string textButton)
        {
            Helper.WaitUntilElementVisible(locatorBtnNext);
            bool result = false;

            try
            {
                foreach (IWebElement button in btnsOnAddform)
                {
                    if (button.Text.Equals(textButton.ToUpper()))
                    {
                        result = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"{textButton} Button WebElement from Add Employee form is not found. \nDetails:\n{ex.Message}");
            }


            return result;
        }

        public void PressNextButton()
        {
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
