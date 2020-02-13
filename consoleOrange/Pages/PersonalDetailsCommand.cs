using OpenQA.Selenium;

namespace consoleOrange.Pages
{
    public class PersonalDetailsCommand
    {
        private string BloodGroup;
        private string Hobbies;

        #region IWebElements
        private static IWebElement DropdownBloodGroup => Driver.Instance.FindElement(By.Id("1_inputfileddiv"));
        private static IWebElement txtHobbie => Driver.Instance.FindElement(By.Id("5"));
        private static IWebElement btnRegion => Driver.Instance.FindElement(By.Id("wizard-nav-button-section"));


        #endregion

        public PersonalDetailsCommand(string BloodGroup)
        {
            this.BloodGroup = BloodGroup;
        }

        public PersonalDetailsCommand WithHobbie(string Hobbies)
        {
            this.Hobbies = Hobbies;

            return this;
        }

        public void PressNextButton()
        {
            Helper.WaitUntilElementExists(By.Id("1_inputfileddiv"));
            DropdownBloodGroup.Click();
            Helper.getWebElementFromDropdown(DropdownBloodGroup, "li", BloodGroup).Click();

            txtHobbie.SendKeys(Hobbies);

            Helper.WaitUntilElementExists(By.Id("wizard-nav-button-section"));
            Helper.getWebElementFromSetOptions(btnRegion, "button").Click();
        }
    }
}
