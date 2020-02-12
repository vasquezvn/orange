namespace consoleOrange.Pages
{
    public class PersonalDetailsPage
    {
        public static PersonalDetailsCommand SetBloodGroup(string Bloodgroup)
        {
            return new PersonalDetailsCommand(Bloodgroup);
        }

    }
}
