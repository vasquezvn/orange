namespace consoleOrange.Pages
{
    public class AddEmployeePage
    {

        public static bool IsButtonDisplayed(string textButton)
        {
            return new AddEmployeePageCommand().IsButtonDisplayed(textButton);
        }

        public static AddEmployeePageCommand AddEmployeeAs(string firstName)
        {
            return new AddEmployeePageCommand().AddEmployeeAs(firstName);
        }



    }
}
