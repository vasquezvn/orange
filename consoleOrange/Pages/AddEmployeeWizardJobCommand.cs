using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class AddEmployeeWizardJobCommand
    {
        private By locatorBtnSection => By.Id("wizard-nav-button-section");
        private By locatorSpinner => By.ClassName("spinner-layer");

        private IWebElement btnSection => Driver.Instance.FindElement(locatorBtnSection);

        public void PressSaveButton()
        {
            Helper.WaitForSpinnerDisapear(locatorSpinner);

            ReadOnlyCollection<IWebElement> btnCollection = btnSection.FindElements(By.TagName("button"));

            foreach (IWebElement button in btnCollection)
            {
                if (button.Text.Equals("SAVE"))
                {
                    try
                    {
                        button.Click();
                    }
                    catch(Exception ex)
                    {
                        Helper.TakeErrorScreenshot();
                        throw new Exception($"Save button WebElement from AddEmployeeWizard - JobCommand page is not found. \nDetails:\n{ex.Message}");
                    }
                    
                    break;
                }
            }
        }
    }
}
