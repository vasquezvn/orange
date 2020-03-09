namespace consoleOrange.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
        }

        public static LoginPageCommand LoginAs(string userName)
        {
            return new LoginPageCommand().LoginAs(userName);
        }
    }
}
