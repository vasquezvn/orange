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

            DashboardPage.AddEmployeeAs("testUser1")
                .WithLastName("testLastName")
                .WithLocation(LocationOptions.AustralianRegionalHQ)
                .PressNextButton();

            PersonalDetailsPage.SetBloodGroup("A")
                .WithHobbie("Art")
                .PressNextButton();

            JobPage.SetRegion("Region-1")
                .WithFte("0.5")
                .WithTemporaryDepartment("Sub unit-1")
                .PressSaveBtn();

            DashboardPage.GoToOption(DashboardOptions.EmployeeList);

            bool searchResult = EmployeeListPage.SearchEmployee("testUser1");

            Assert.IsTrue(searchResult, "User Can't Be Found");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
