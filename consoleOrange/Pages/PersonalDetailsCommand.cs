using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class PersonalDetailsCommand
    {

        #region Locators
        private By locatorDropDownBloodGroup => By.Id("1_inputfileddiv");
        private By locatorBtnRegion => By.Id("wizard-nav-button-section");
        private By locatorDropDownMaritalStatus => By.Id("emp_marital_status_inputfileddiv");

        #endregion


        #region IWebElements
        private IWebElement DropdownBloodGroup => Driver.Instance.FindElement(locatorDropDownBloodGroup);
        private IWebElement txtHobbie => Driver.Instance.FindElement(By.Id("5"));
        private IWebElement DropdownMaritalStatus => Driver.Instance.FindElement(locatorDropDownMaritalStatus);
        private IWebElement btnRegion => Driver.Instance.FindElement(locatorBtnRegion);

        #endregion


        public PersonalDetailsCommand() { }


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

        public PersonalDetailsCommand SetBloodGroup(string bloodGroup)
        {
            Helper.WaitUntilElementExists(locatorDropDownBloodGroup, 60);

            try
            {
                DropdownBloodGroup.Click();
                Helper.getWebElementFromDropdown(DropdownBloodGroup, bloodGroup).Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Dropdown BloodGroup WebElement from Personal Detail Page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
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
