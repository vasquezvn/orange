using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class AddEmployeeWizardPersonalDetailsCommand
    {
        private By locatorBtnSection => By.Id("wizard-nav-button-section");

        private IWebElement btnSection => Driver.Instance.FindElement(locatorBtnSection);


        public AddEmployeeWizardPersonalDetailsCommand PressNextButton()
        {
            Helper.WaitUntilElementExists(locatorBtnSection);

            ReadOnlyCollection<IWebElement> btnCollection = btnSection.FindElements(By.TagName("button"));

            foreach (IWebElement button in btnCollection)
            {
                if (button.Text.Equals("NEXT"))
                {
                    button.Click();
                    break;
                }
            }

            return this;
        }

    }
}
