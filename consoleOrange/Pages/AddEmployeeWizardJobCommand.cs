using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class AddEmployeeWizardJobCommand
    {
        private By locatorBtnSection => By.Id("wizard-nav-button-section");

        private IWebElement btnSection => Driver.Instance.FindElement(locatorBtnSection);

        public void PressSaveButton()
        {
            Helper.WaitUntilElementExists(locatorBtnSection);

            ReadOnlyCollection<IWebElement> btnCollection = btnSection.FindElements(By.TagName("button"));

            foreach (IWebElement button in btnCollection)
            {
                if (button.Text.Equals("SAVE"))
                {
                    button.Click();
                    break;
                }
            }
        }
    }
}
