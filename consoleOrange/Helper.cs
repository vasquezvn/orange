using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

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

        public static void WaitUntilElementExists(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch(Exception ex)
            {
                TakeErrorScreenshot();
                throw new Exception($"Element locator {elementLocator.ToString()} can't be found in WaitUntilElementExists method. \nDetails:\n{ex.Message}");
            }
        }

        public static void WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (Exception ex)
            {
                TakeErrorScreenshot();
                throw new Exception($"Element locator {elementLocator.ToString()} can't be found in WaitUntilElementClickable method. \nDetails:\n{ex.Message}");
            }
        }

        public static void ClickAndWaitForPageToLoad(IWebElement element, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(timeout));
                element.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception ex)
            {
                TakeErrorScreenshot();
                throw new Exception($"Element locator can't be found in ClickAndWaitForPageToLoad method. \nDetails:\n{ex.Message}");
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
                TakeErrorScreenshot();
                throw new Exception($"Element locator {elementLocator.ToString()} can't be found in WaitUntilElementVisible method. \nDetails:\n{ex.Message}");
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

        public static void WaitForReady(TimeSpan seconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver.Instance, seconds);
            wait.Until(d =>
            {
                return WaitForPageLoad(seconds);
            });
        }

        private static bool WaitForPageLoad(TimeSpan waitTime)
        {
            WaitForDocumentReady(waitTime);
            bool ajaxReady = WaitForAjaxReady(waitTime);
            WaitForDocumentReady(waitTime);

            return ajaxReady;
        }

        private static bool WaitForAjaxReady(TimeSpan waitTime)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(Driver.Instance, waitTime);

            return wait.Until<bool>((d) =>
            {
                return Driver.Instance.FindElements(By.CssSelector(".waiting, .tb-loading")).Count == 0;
            });
        }

        private static void WaitForDocumentReady(TimeSpan waitTime)
        {
            var wait = new WebDriverWait(Driver.Instance, waitTime);
            var javascript = Driver.Instance as IJavaScriptExecutor;

            if (javascript == null)
                throw new ArgumentException("driver", "Driver must support javascript execution");

            wait.Until((d) =>
            {
                try
                {
                    string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyStatue;").ToString();
                    return readyState.ToLower() == "complete";
                }
                catch (InvalidOperationException e)
                {
                    return e.Message.ToLower().Contains("unable to get browser");
                }
                catch (WebDriverException e)
                {
                    return e.Message.ToLower().Contains("unable to connect");
                }
                catch (Exception)
                {
                    return false;
                }
            }
            );
        }

        public static void WaitForSpinnerDisapear(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (Exception ex)
            {
                TakeErrorScreenshot();
                throw new Exception($"Element locator {locator.ToString()} can't be found in WaitForSpinnerDisapear method. \nDetails:\n{ex.Message}");
            }
        }
    }
}
