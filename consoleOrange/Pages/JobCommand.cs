using OpenQA.Selenium;
using System;
using System.Threading;

namespace consoleOrange.Pages
{
    public class JobCommand
    {

        #region Locators
        private static By locatorSuccessPopup => By.Id("toast-container");
        private static By locatorDropdownFte => By.Id("10_inputfileddiv");
        private static By locatorDropdownRegion => By.Id("9_inputfileddiv");
        private static By locatorDropdownTempDep => By.Id("11_inputfileddiv");
        #endregion

        #region IWebElements
        private static IWebElement DropdownRegion => Driver.Instance.FindElement(locatorDropdownRegion);
        private static IWebElement DropdownFte => Driver.Instance.FindElement(locatorDropdownFte);
        private static IWebElement DropdownTempDep => Driver.Instance.FindElement(locatorDropdownTempDep);
        private static IWebElement BtnsWizard => Driver.Instance.FindElement(By.Id("wizard-nav-button-section"));

        #endregion

        public JobCommand(string region)
        {
            //Helper.ClickAndWaitForPageToLoad(DropdownRegion);
            //Helper.WaitUntilElementVisible(locatorDropdownRegion);
            
            //Helper.WaitUntilElementClickable(locatorDropdownRegion);
            //Helper.WaitUntilElementExists(locatorDropdownRegion);
            //Helper.WaitUntilElementVisible(locatorDropdownRegion);
            //Helper.ScrollToView(locatorDropdownRegion);

            Thread.Sleep(10000);

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
            
        }

        public JobCommand WithFte(string fte)
        {
            Helper.WaitUntilElementExists(locatorDropdownFte);

            try
            {
                //Helper.ScrollToView(locatorDropdownFte).Click();
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
