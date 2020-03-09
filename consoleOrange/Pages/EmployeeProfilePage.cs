using OpenQA.Selenium;

namespace consoleOrange.Pages
{
    public class EmployeeProfilePage
    {
        private static IWebElement lblFistName => Driver.Instance.FindElement(By.Id("pim.navbar.employeeName"));

        public static string GetLabelFirstName()
        {
            return lblFistName.Text;
        }
    }
}
