using OpenQA.Selenium;
using System;

namespace consoleOrange.Pages
{
    public class LoginPageCommand
    {
        private string userName;
        private string password;

        #region IWebElements

        private static IWebElement txtUsername => Driver.Instance.FindElement(By.Id("txtUsername"));
        private static IWebElement txtPassword => Driver.Instance.FindElement(By.Id("txtPassword"));
        private static IWebElement btnLogin => Driver.Instance.FindElement(By.Id("btnLogin"));

        #endregion

        public LoginPageCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginPageCommand WithPassword(string password)
        {
            this.password = password;

            return this;
        }

        public void PressLoginButton()
        {
            try
            {
                txtUsername.Clear();
                txtUsername.SendKeys(userName);

                txtPassword.Clear();
                txtPassword.SendKeys(password);

                btnLogin.Click();
            }
            catch(NoSuchElementException element)
            {
                Console.WriteLine($"Element can't be found: {element.Message}");
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Method PressLoginButton has errors: {ex.Message}");
            }
            
        }
    }
}
