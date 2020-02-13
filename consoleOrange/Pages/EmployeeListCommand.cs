﻿using OpenQA.Selenium;
using System.Collections.Generic;

namespace consoleOrange.Pages
{
    public class EmployeeListCommand
    {
        private string EmployeeName;

        #region IWebElement
        private static IWebElement txtSearchEmployee => Driver.Instance.FindElement(By.Id("employee_name_quick_filter_employee_list_value"));
        private static IWebElement iconSearch => Driver.Instance.FindElement(By.Id("quick_search_icon"));
        private static IWebElement tableEmployeeList => Driver.Instance.FindElement(By.Id("employeeListTable"));
        #endregion

        public EmployeeListCommand(string EmployeeName)
        {
            this.EmployeeName = EmployeeName;
        }

        public bool PressSearchBtn()
        {
            bool result = false;
            txtSearchEmployee.SendKeys(EmployeeName);
            iconSearch.Click();

            IReadOnlyCollection<IWebElement> rowsEmployee = tableEmployeeList.FindElements(By.TagName("tr"));

            if(rowsEmployee.Count > 0)
            {
                foreach(IWebElement rowEmployee in rowsEmployee)
                {
                    if(rowEmployee.Text.Contains(EmployeeName))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}