using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class AddEmployeeWizardPersonalDetailsCommand
    {
        #region
        private By locatorBtnSection => By.Id("wizard-nav-button-section");
        private By locatorSpinner => By.ClassName("spinner-layer");

        #endregion

        private IWebElement btnSection => Driver.Instance.FindElement(locatorBtnSection);


        public AddEmployeeWizardPersonalDetailsCommand PressNextButton()
        {
            Helper.WaitForSpinnerDisapear(locatorSpinner);

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
