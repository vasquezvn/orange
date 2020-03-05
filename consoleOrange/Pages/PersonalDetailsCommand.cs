using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class PersonalDetailsCommand
    {

        #region Locators
        private static By locatorDropDownBloodGroup => By.Id("1_inputfileddiv");
        private static By locatorBtnRegion => By.Id("wizard-nav-button-section");
        private static By locatorDropDownMaritalStatus => By.Id("emp_marital_status_inputfileddiv");

        #endregion


        #region IWebElements
        private static IWebElement DropdownBloodGroup => Driver.Instance.FindElement(locatorDropDownBloodGroup);
        private static IWebElement txtHobbie => Driver.Instance.FindElement(By.Id("5"));
        private static IWebElement DropdownMaritalStatus => Driver.Instance.FindElement(locatorDropDownMaritalStatus);
        private static IWebElement btnRegion => Driver.Instance.FindElement(locatorBtnRegion);

        #endregion


        public PersonalDetailsCommand()
        {
        }


        internal bool IsMaritalStatusOptionAvailable(string maritalStatusOption)
        {
            bool result = false;
            Helper.WaitUntilElementExists(locatorDropDownMaritalStatus);

            try
            {
                DropdownMaritalStatus.Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Marital Status Dropdown WebElement from Login Page is not found. \nDetails:\n{ex.Message}");
            }

            ReadOnlyCollection<IWebElement> options = DropdownMaritalStatus.FindElements(By.TagName("li"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Contains(maritalStatusOption))
                {
                    result = true;
                    break;
                }
            }


            return result;
        }

        
        public PersonalDetailsCommand(string BloodGroup)
        {
            Helper.WaitUntilElementExists(locatorDropDownBloodGroup);

            try
            {
                DropdownBloodGroup.Click();
                Helper.getWebElementFromDropdown(DropdownBloodGroup, BloodGroup).Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Dropdown BloodGroup WebElement from Personal Detail Page is not found. \nDetails:\n{ex.Message}");
            }
        }

        
        public PersonalDetailsCommand WithHobbie(string Hobbies)
        {
            try
            {
                txtHobbie.SendKeys(Hobbies);
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Hobbies WebElement from Personal Detail Page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }


        public void PressNextButton()
        {
            Helper.WaitUntilElementExists(locatorBtnRegion);

            try
            {
                Helper.getWebElementFromSetOptions(btnRegion, "button").Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Next button WebElement from Personal Detail Page is not found. \nDetails:\n{ex.Message}");
            }
        }
    }
}
