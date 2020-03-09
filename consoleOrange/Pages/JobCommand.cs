using OpenQA.Selenium;
using System;
using System.Threading;

namespace consoleOrange.Pages
{
    public class JobCommand
    {

        #region Locators
        private By locatorDropdownFte => By.Id("10_inputfileddiv");
        private By locatorDropdownRegion => By.Id("9_inputfileddiv");
        private By locatorDropdownTempDep => By.Id("11_inputfileddiv");
        #endregion

        #region IWebElements
        private IWebElement DropdownRegion => Driver.Instance.FindElement(locatorDropdownRegion);
        private IWebElement DropdownFte => Driver.Instance.FindElement(locatorDropdownFte);
        private IWebElement DropdownTempDep => Driver.Instance.FindElement(locatorDropdownTempDep);
        private IWebElement BtnsWizard => Driver.Instance.FindElement(By.Id("wizard-nav-button-section"));

        #endregion

        public JobCommand() { }

        public JobCommand SetRegion(string region)
        {
            Thread.Sleep(15000);

            try
            {
                DropdownRegion.Click();
                Helper.getWebElementFromDropdown(DropdownRegion, region).Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Region Dropdown WebElement from JobCommand Page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public JobCommand WithFte(string fte)
        {
            Helper.WaitUntilElementExists(locatorDropdownFte);

            try
            {
                DropdownFte.Click();
                Helper.getWebElementFromDropdown(DropdownFte, fte).Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Fte dropdown WebElement from JobCommand Page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public JobCommand WithTemporaryDepartment(string TemporaryDepartment)
        {
            Helper.WaitUntilElementExists(locatorDropdownTempDep);

            try
            {
                DropdownTempDep.Click();
                Helper.getWebElementFromDropdown(DropdownTempDep, TemporaryDepartment).Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Temporary Department dropdown WebElement from JobCommand Page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public void PressSaveBtn()
        {
            try
            {
                Helper.getWebElementFromSetOptions(BtnsWizard, "button").Click();
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Save button WebElement from JobCommand Page is not found. \nDetails:\n{ex.Message}");
            }
        }
    }
}
