namespace consoleOrange.Pages
{
    public class EmployeeListPage
    {
        public static bool SearchEmployee(string employeeName)
        {
            EmployeeListCommand objSearch = new EmployeeListCommand(employeeName);

            return objSearch.PressSearchBtn();
        }
    }
}
