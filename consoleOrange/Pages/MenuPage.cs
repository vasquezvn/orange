using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleOrange.Pages
{
    public class MenuPage
    {
        public enum MenuOptions
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


        public static void GoToOption(MenuOptions option)
        {
            switch (option)
            {
                case MenuOptions.AddEmployee:
                    try
                    {
                        menuPimView.Click();
                    }
                    catch (Exception ex)
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

                case MenuOptions.EmployeeList:
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

    }
}
