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

        /*[TestMethod]
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
        }*/

        /*[TestMethod]
        public void VerifySaveButton()
        {
            LoginPage.GoTo();

            LoginPage.LoginAs("admin")
                .WithPassword("admin123")
                .PressLoginButton();

            DashboardPage.GoToOption(DashboardOptions.AddEmployee);

            Assert.IsTrue(DashboardPage.IsSaveButtonDisplayed(), "Save button is not displayed on Add Employee form");
        }*/

        [TestMethod]
        public void VerifiedDivorcedOption()
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

            Assert.IsTrue(PersonalDetailsPage.IsDivorcedOptionAvailable(), "Divorced Option is not found in Dropdown Marital Status");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
