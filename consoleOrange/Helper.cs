using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace consoleOrange
{
    public class Helper
    {
        public static IWebElement getWebElementFromDropdown(IWebElement element, string tagName, string contains)
        {
            IWebElement result = null;
            ReadOnlyCollection<IWebElement> options = element.FindElements(By.TagName(tagName));

            foreach (IWebElement option in options)
            {
                if (option.Text.Contains(contains))
                {
                    result = option;
                    break;
                }
            }

            return result;
        }
    }
}
