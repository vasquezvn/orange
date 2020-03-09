using OpenQA.Selenium;
using System;

namespace consoleOrange.Pages
{
    public class LoginPageCommand
    {
        #region IWebElements
        private IWebElement txtUsername => Driver.Instance.FindElement(By.Id("txtUsername"));
        private IWebElement txtPassword => Driver.Instance.FindElement(By.Id("txtPassword"));
        private IWebElement btnLogin => Driver.Instance.FindElement(By.Id("btnLogin"));

        #endregion
        
        public LoginPageCommand() { }

        public LoginPageCommand LoginAs(string userName)
        {
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

            return this;
        }

        public LoginPageCommand WithPassword(string password)
        {
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
