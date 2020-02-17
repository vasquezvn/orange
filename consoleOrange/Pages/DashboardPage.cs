using OpenQA.Selenium;
using System;

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
            switch (option)
            {
                case DashboardOptions.AddEmployee:
                    try
                    {
                        menuPimView.Click();
                    }
                    catch(Exception ex)
                    {
                        Helper.TakeErrorScreenshot();
                        throw new Exception($"PIM WebElement from Side Menu is not found. \nDetails:\n{ex.Message}");
                    }

                    try
                    {
                        menuPimAddEmployee.Click();
                    }
                    catch (Exception ex)
                    {
                        Helper.TakeErrorScreenshot();
                        throw new Exception($"PIM > Add Employee WebElement from Side Menu is not found. \nDetails:\n{ex.Message}");
                    }

                    break;

                case DashboardOptions.EmployeeList:
                    try
                    {
                        menuEmployeeList.Click();
                    }
                    catch (Exception ex)
                    {
                        Helper.TakeErrorScreenshot();
                        throw new Exception($"PIM > Employee List WebElement from Side Menu is not found. \nDetails:\n{ex.Message}");
                    }
                        
                    break;
            }

        }

        public static DashboardPageCommand AddEmployeeAs(string firstName)
        {
            return new DashboardPageCommand(firstName);
        }



    }
}
