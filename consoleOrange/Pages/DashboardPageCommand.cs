﻿using OpenQA.Selenium;

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
            LondonOffice,
            AustralianRegionalHQ,
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
            Helper.WaitUntilElementExists(By.Id("location_inputfileddiv"));

            switch(option)
            {
                case LocationOptions.AustralianRegionalHQ:
                    selectDropdownLocation.Click();
                    Helper.getWebElementFromDropdown(selectDropdownLocation, "li", "Australian Regional HQ").Click();

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
