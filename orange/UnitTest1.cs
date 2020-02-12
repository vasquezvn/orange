using consoleOrange;
using consoleOrange.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static consoleOrange.Pages.DashboardPage;
using static consoleOrange.Pages.DashboardPageCommand;

namespace orange
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void TestMethod1()
        {
            LoginPage.GoTo();

            LoginPage.LoginAs("admin")
                .WithPassword("admin123")
                .PressLoginButton();

            DashboardPage.GoToOption(DashboardOptions.AddEmployee);

            DashboardPage.AddEmployeeAs("testUser")
                .WithLastName("testLastName")
                .WithLocation(LocationOptions.NewYorkSalesOffice)
                .PressNextButton();

            PersonalDetailsPage.SetBloodGroup("A")
                .WithHobbie("Art")
                .PressNextButton();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
