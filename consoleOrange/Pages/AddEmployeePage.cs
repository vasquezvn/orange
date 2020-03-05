using OpenQA.Selenium;
using System;

namespace consoleOrange.Pages
{
    public class AddEmployeePage
    {

        public static bool IsSaveButtonDisplayed(string textButton)
        {
            return new AddEmployeePageCommand().IsButtonDisplayed(textButton);
        }

        public static AddEmployeePageCommand AddEmployeeAs(string firstName)
        {
            return new AddEmployeePageCommand(firstName);
        }



    }
}
