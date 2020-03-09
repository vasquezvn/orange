using consoleOrange;
using consoleOrange.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static consoleOrange.Pages.AddEmployeePageCommand;
using static consoleOrange.Pages.MenuPage;

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
        public void SearchNewEmployee()
        {
            string userName = $"testUser{Helper.RandomNumber(2, 100)}";

            LoginPage.GoTo();

            LoginPage.LoginAs("admin")
                .WithPassword("admin123")
                .PressLoginButton();

            MenuPage.GoToOption(MenuOptions.AddEmployee);

            AddEmployeePage.AddEmployeeAs(userName)
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

            AddEmployeeWizardPersonalDetailsPage.PressNextButton();

            AddEmployeeWizardJobPage.PressSaveButton();

            var employeeName = EmployeeProfilePage.GetLabelFirstName();

            MenuPage.GoToOption(MenuOptions.EmployeeList);

            bool searchResult = EmployeeListPage.SearchEmployee(employeeName);

            Assert.IsTrue(searchResult, "User Can't Be Found");
        }

        [TestMethod]
        public void VerifyButtonIsDisplayed()
        {
            var textButton = "Save";
            LoginPage.GoTo();

            LoginPage.LoginAs("admin")
                .WithPassword("admin123")
                .PressLoginButton();

            MenuPage.GoToOption(MenuOptions.AddEmployee);

            Assert.IsTrue(AddEmployeePage.IsSaveButtonDisplayed(textButton), $"{textButton} button is not displayed on Add Employee form");
        }

        [TestMethod]
        public void VerifyMaritalStatusOption()
        {
            var maritalStatusOption = "Divorced";
            LoginPage.GoTo();

            LoginPage.LoginAs("admin")
                .WithPassword("admin123")
                .PressLoginButton();

            MenuPage.GoToOption(MenuOptions.AddEmployee);

            AddEmployeePage.AddEmployeeAs("testUser1")
                .WithLastName("testLastName")
                .WithLocation(LocationOptions.AustralianRegionalHQ)
                .PressNextButton();

            Assert.IsTrue(PersonalDetailsPage.IsMaritalStatusOptionAvailable(maritalStatusOption), $"{maritalStatusOption} option is not found in Dropdown Marital Status");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
