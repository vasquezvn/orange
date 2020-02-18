using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class PersonalDetailsCommand
    {
        private string BloodGroup;
        private string Hobbies;

        #region IWebElements
        private static IWebElement DropdownBloodGroup => Driver.Instance.FindElement(By.Id("1_inputfileddiv"));
        private static IWebElement txtHobbie => Driver.Instance.FindElement(By.Id("5"));
        private static IWebElement DropdownMaritalStatus => Driver.Instance.FindElement(By.Id("emp_marital_status_inputfileddiv"));

        internal bool IsDivorcedOptionAvailable()
        {
            bool result = false;
            Helper.WaitUntilElementExists(By.Id("emp_marital_status_inputfileddiv"));

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
                if (option.Text.Contains("Divorced"))
                {
                    result = true;
                    break;
                }
            }


            return result;
        }

        private static IWebElement btnRegion => Driver.Instance.FindElement(By.Id("wizard-nav-button-section"));


        #endregion

        public PersonalDetailsCommand(string BloodGroup)
        {
            this.BloodGroup = BloodGroup;
        }

        public PersonalDetailsCommand()
        {
        }

        public PersonalDetailsCommand WithHobbie(string Hobbies)
        {
            this.Hobbies = Hobbies;

            return this;
        }

        public void PressNextButton()
        {
            try
            {
                Helper.WaitUntilElementExists(By.Id("1_inputfileddiv"));
                DropdownBloodGroup.Click();
                Helper.getWebElementFromDropdown(DropdownBloodGroup, "li", BloodGroup).Click();

                txtHobbie.SendKeys(Hobbies);

                Helper.WaitUntilElementExists(By.Id("wizard-nav-button-section"));
                Helper.getWebElementFromSetOptions(btnRegion, "button").Click();
            }
            catch (NoSuchElementException element)
            {
                Helper.TakeErrorScreenshot();
                Console.WriteLine($"Element can't be found: {element.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                Console.WriteLine($"Method PressLoginButton has errors: {ex.Message}");
            }
        }
    }
}
