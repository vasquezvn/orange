using OpenQA.Selenium;
using System;

namespace consoleOrange.Pages
{
    public class EmployeeProfilePage
    {
        private static By locatorLblFistName => By.Id("pim.navbar.employeeName");
        private static By locatorSpinner => By.ClassName("spinner-layer");

        private static IWebElement lblFistName => Driver.Instance.FindElement(locatorLblFistName);

        public static string GetLabelFirstName()
        {
            Helper.WaitForSpinnerDisapear(locatorSpinner);
            Helper.WaitUntilElementExists(locatorLblFistName);

            string labelFirstName;

            try
            {
                labelFirstName = lblFistName.Text;
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"First Name label WebElement from Employee Profile page is not found. \nDetails:\n{ex.Message}");
            }

            return labelFirstName;
        }
    }
}
