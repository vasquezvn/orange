using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace consoleOrange.Pages
{
    public class EmployeeListCommand
    {
        private string EmployeeName;
        private By locatorTxtSearchEmployee => By.Id("employee_name_quick_filter_employee_list_value");
        private By locatorRowTable => By.ClassName("cursor-pointer");

        #region IWebElement
        private IWebElement txtSearchEmployee => Driver.Instance.FindElement(locatorTxtSearchEmployee);
        private IWebElement iconSearch => Driver.Instance.FindElement(By.Id("quick_search_icon"));
        private IWebElement tableEmployeeList => Driver.Instance.FindElement(By.Id("employeeListTable"));

        #endregion

        public EmployeeListCommand() { }

        public EmployeeListCommand EnterEmployeeName(string employeeName)
        {
            EmployeeName = employeeName;

            Helper.ClickAndWaitForPageToLoad(txtSearchEmployee);

            try
            {
                txtSearchEmployee.SendKeys(EmployeeName);
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Search Employee WebElement from EmployeeList page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public bool PressSearchBtn()
        {
            bool result = false;

            try
            {
                Helper.ClickAndWaitForPageToLoad(iconSearch);
                iconSearch.Click();

                Helper.WaitUntilElementVisible(locatorRowTable);

                IReadOnlyCollection<IWebElement> rowsEmployee = tableEmployeeList.FindElements(By.TagName("tr"));

                if (rowsEmployee.Count > 0)
                {
                    foreach (IWebElement rowEmployee in rowsEmployee)
                    {
                        if (rowEmployee.Text.Contains(EmployeeName))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Search button WebElement from EmployeeList page is not found. \nDetails:\n{ex.Message}");
            }

            return result;
        }
    }
}
