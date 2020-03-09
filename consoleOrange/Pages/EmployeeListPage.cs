namespace consoleOrange.Pages
{
    public class EmployeeListPage
    {
        public static bool SearchEmployee(string employeeName)
        {
            return new EmployeeListCommand().EnterEmployeeName(employeeName)
                .PressSearchBtn();
        }
    }
}
