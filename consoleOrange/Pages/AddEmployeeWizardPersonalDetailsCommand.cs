using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Threading;

namespace consoleOrange.Pages
{
    public class AddEmployeeWizardPersonalDetailsCommand
    {
        private By locatorBtnSection => By.Id("wizard-nav-button-section");

        private IWebElement btnSection => Driver.Instance.FindElement(locatorBtnSection);


        public AddEmployeeWizardPersonalDetailsCommand PressNextButton()
        {
            //Helper.WaitUntilElementExists(locatorBtnSection);
            //Helper.WaitUntilElementVisible(locatorBtnSection);
            //Helper.WaitUntilElementClickable(locatorBtnSection);
            //Helper.ClickAndWaitForPageToLoad(btnSection);

            Thread.Sleep(15000);

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
