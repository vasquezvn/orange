using OpenQA.Selenium;

namespace consoleOrange.Pages
{
    public class DashboardPage
    {
        public enum DashboardOptions
        {
            Pim,
            AddEmployee
        }

        #region IWebElements
        private static IWebElement menuPimView => Driver.Instance.FindElement(By.Id("menu_pim_viewPimModule"));
        private static IWebElement menuPimAddEmployee => Driver.Instance.FindElement(By.Id("menu_pim_addEmployee"));
        #endregion


        public static void GoToOption(DashboardOptions option)
        {
            switch(option)
            {
                case DashboardOptions.AddEmployee:
                    menuPimView.Click();
                    menuPimAddEmployee.Click();

                    break;
            }
        }

        public static DashboardPageCommand AddEmployeeAs(string firstName)
        {
            return new DashboardPageCommand(firstName);
        }



    }
}
