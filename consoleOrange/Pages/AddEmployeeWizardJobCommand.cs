using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class AddEmployeeWizardJobCommand
    {
        private By locatorBtnSection => By.Id("wizard-nav-button-section");

        private IWebElement btnSection => Driver.Instance.FindElement(locatorBtnSection);

        public void PressSaveButton()
        {
            //Helper.WaitUntilElementExists(locatorBtnSection);
            //Helper.WaitUntilElementClickable(locatorBtnSection);
            //Helper.WaitUntilElementVisible(locatorBtnSection);

            ReadOnlyCollection<IWebElement> btnCollection = btnSection.FindElements(By.TagName("button"));

            foreach (IWebElement button in btnCollection)
            {
                if (button.Text.Equals("SAVE"))
                {
                    try
                    {
                        Helper.ClickAndWaitForPageToLoad(button);
                        //button.Click();
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
