using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace consoleOrange.Pages
{
    public class DashboardPageCommand
    {
        private string FirstName;
        private string LastName;
        private string Location;

        public enum LocationOptions
        {
            NewYorkSalesOffice,
            LondonOffice
        }

        #region IWebWElements
        private static IWebElement txtFirstName => Driver.Instance.FindElement(By.Id("firstName"));
        private static IWebElement txtLastName => Driver.Instance.FindElement(By.Id("lastName"));
        private static IWebElement selectDropdownLocation => Driver.Instance.FindElement(By.Id("location_inputfileddiv"));
        private static IWebElement btnNext => Driver.Instance.FindElement(By.Id("systemUserSaveBtn"));
        

        #endregion


        public DashboardPageCommand(string FirstName)
        {
            this.FirstName = FirstName;
        }

        public DashboardPageCommand WithLastName(string LastName)
        {
            this.LastName = LastName;

            return this;
        }

        public DashboardPageCommand WithLocation(LocationOptions option)
        {
            switch(option)
            {
                case LocationOptions.NewYorkSalesOffice:
                    selectDropdownLocation.Click();
                    ReadOnlyCollection<IWebElement> options = selectDropdownLocation.FindElements(By.TagName("li"));

                    foreach (IWebElement element in options)
                    {
                        string text = element.Text;
                        if (element.Text.Contains("Australian Regional HQ"))
                        {
                            element.Click();
                            break;
                        }
                            
                    }

                    break;
            }

            return this;
        }

        public void PressNextButton()
        {
            txtFirstName.SendKeys(FirstName);
            txtLastName.SendKeys(LastName);

            btnNext.Click();

        }
    }
}
