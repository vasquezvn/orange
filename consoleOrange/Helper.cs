using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace consoleOrange
{
    public class Helper
    {
        private static string LogsPath = new DirectoryInfo(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\consoleOrange\Logs"))).ToString();


        public static IWebElement getWebElementFromDropdown(IWebElement element, string contains)
        {
            IWebElement result = null;
            ReadOnlyCollection<IWebElement> options = element.FindElements(By.TagName("li"));

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

        public static IWebElement getWebElementFromSetOptions(IWebElement element, string tagName)
        {
            IWebElement result = null;
            ReadOnlyCollection<IWebElement> options = element.FindElements(By.TagName(tagName));

            foreach (IWebElement option in options)
            {
                if (option.Text.Length > 0)
                {
                    result = option;
                    break;
                }
            }

            return result;
        }

        public static void WaitForElement(IWebElement element, double time)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(time);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                if (element.Displayed)
                {
                    return true;
                }
                return false;
            });

            wait.Until(waiter);
        }

        public static void waitForElement2(IWebElement element)
        {
            try
            {
                Driver.Instance.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/client/#/pim/employees");
            }
            catch
            {
                //ignored
            }
            finally
            {
                Driver.Instance.FindElement(By.Id("location_inputfileddiv"));
            }
        }

        public static void WaitUntilElementExists(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch(NoSuchElementException)
            {
                Console.WriteLine($"Element with locator: {elementLocator} was not found in current context page");
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"WaitUntilElementExists method is failing due {ex.Message}");
            }
        }

        public static void WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element with locator: {elementLocator} was not found in current context page");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WaitUntilElementClickable method is failing due {ex.Message}");
            }
        }

        public static void ClickAndWaitForPageToLoad(IWebElement element, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ClickAndWaitForPageToLoad method is failing due {ex.Message}");
            }
        }

        public static void WaitUntilElementVisible(By elementLocator, int timeout = 10, IWebElement iframeElement = null)
        {
            if(iframeElement != null)
            {
                Driver.Instance.SwitchTo().Frame(iframeElement);
            }

            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (Exception ex)
            {
                throw new Exception($"Element with locator: {elementLocator} was not found in current context page");
            }

            if(iframeElement != null)
            {
                Driver.Instance.SwitchTo().ParentFrame();
            }
        }

        public static void TakeErrorScreenshot()
        {
            var logPathName = LogsPath + @"\ErrorScreenshot_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
            ((ITakesScreenshot)Driver.Instance).GetScreenshot().SaveAsFile(logPathName, ScreenshotImageFormat.Png);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
            //var js = String.Format("window.scrollBy({0}, {1})", xPosition, yPosition);
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(js);
        }

        private static void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                ScrollTo(0, element.Location.Y - 100);
            }
        }

        public static IWebElement ScrollToView(By selector)
        {
            var element = Driver.Instance.FindElement(selector);
            ScrollToView(element);

            return element;
        }

    }
}
