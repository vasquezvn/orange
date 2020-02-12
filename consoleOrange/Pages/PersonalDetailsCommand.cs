using OpenQA.Selenium;
using System.Collections.ObjectModel;

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
            DropdownBloodGroup.Click();
            ReadOnlyCollection<IWebElement> HoobiesOptions = DropdownBloodGroup.FindElements(By.TagName("li"));

            foreach(IWebElement option in HoobiesOptions)
            {
                if (option.Text.Contains(BloodGroup))
                {
                    option.Click();
                    break;
                }
            }

            txtHobbie.SendKeys(Hobbies);

            ReadOnlyCollection<IWebElement> buttonsNext = btnRegion.FindElements(By.TagName("button"));

            foreach(IWebElement btnOption in buttonsNext)
            {
                if(btnOption.Text.Contains("NEXT"))
                {
                    btnOption.Click();
                    break;
                }
            }
        }
    }
}
