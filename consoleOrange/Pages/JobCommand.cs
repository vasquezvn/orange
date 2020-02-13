using OpenQA.Selenium;

namespace consoleOrange.Pages
{
    public class JobCommand
    {
        private string Region;
        private string Fte;
        private string TemporaryDepartment;

        #region IWebElements
        private static IWebElement DropdownRegion => Driver.Instance.FindElement(By.Id("9_inputfileddiv"));
        private static IWebElement DropdownFte => Driver.Instance.FindElement(By.Id("10_inputfileddiv"));
        private static IWebElement DropdownTempDep => Driver.Instance.FindElement(By.Id("11_inputfileddiv"));

        private static IWebElement BtnsWizard => Driver.Instance.FindElement(By.Id("wizard-nav-button-section"));
        private static IWebElement SuccessPopup => Driver.Instance.FindElement(By.Id("toast-container"));

        private static IWebElement IframeElement => Driver.Instance.FindElement(By.Id("xh-bar"));

        #endregion

        public JobCommand(string Region)
        {
            this.Region = Region;
        }

        public JobCommand WithFte(string Fte)
        {
            this.Fte = Fte;

            return this;
        }

        public JobCommand WithTemporaryDepartment(string TemporaryDepartment)
        {
            this.TemporaryDepartment = TemporaryDepartment;

            return this;
        }

        public void PressSaveBtn()
        {
            Helper.ClickAndWaitForPageToLoad(DropdownRegion);
            DropdownRegion.Click();

            Helper.getWebElementFromDropdown(DropdownRegion, "li", "Region-1").Click();

            DropdownFte.Click();
            Helper.getWebElementFromDropdown(DropdownFte, "li", "0.5").Click();

            DropdownTempDep.Click();
            Helper.getWebElementFromDropdown(DropdownTempDep, "li", "Sub unit-1").Click();

            Helper.getWebElementFromSetOptions(BtnsWizard, "button").Click();

            Helper.WaitUntilElementVisible(By.Id("toast-container"));

        }
    }
}
