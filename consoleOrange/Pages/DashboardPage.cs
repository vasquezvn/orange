using OpenQA.Selenium;

namespace consoleOrange.Pages
{
    public class DashboardPage
    {
        public enum DashboardOptions
        {
            Pim,
            AddEmployee,
            EmployeeList,
        }

        #region IWebElements
        private static IWebElement menuPimView => Driver.Instance.FindElement(By.Id("menu_pim_viewPimModule"));
        private static IWebElement menuPimAddEmployee => Driver.Instance.FindElement(By.Id("menu_pim_addEmployee"));
        private static IWebElement menuEmployeeList => Driver.Instance.FindElement(By.Id("menu_pim_viewEmployeeList"));
        #endregion


        public static void GoToOption(DashboardOptions option)
        {
            switch(option)
            {
                case DashboardOptions.AddEmployee:
                    menuPimView.Click();
                    menuPimAddEmployee.Click();

                    break;

                case DashboardOptions.EmployeeList:
                    //menuPimView.Click();
                    menuEmployeeList.Click();

                    break;
            }
        }

        public static DashboardPageCommand AddEmployeeAs(string firstName)
        {
            return new DashboardPageCommand(firstName);
        }



    }
}
