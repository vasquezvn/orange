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

            try
            {
                txtUsername.Clear();
                txtUsername.SendKeys(userName);
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"User Name WebElement from Login Page is not found. \nDetails:\n{ex.Message}");
            }
        }

        public LoginPageCommand WithPassword(string password)
        {
            this.password = password;

            try
            {
                txtPassword.Clear();
                txtPassword.SendKeys(password);
            }
            catch (Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Password WebElement from Login Page is not found. \nDetails:\n{ex.Message}");
            }

            return this;
        }

        public void PressLoginButton()
        {
            try
            {
                btnLogin.Click();
            }
            catch(Exception ex)
            {
                Helper.TakeErrorScreenshot();
                throw new Exception($"Login button WebElement from Login Page is not found. \nDetails:\n{ex.Message}");
            }
            
        }
    }
}
