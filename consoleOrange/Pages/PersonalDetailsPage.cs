using System;

namespace consoleOrange.Pages
{
    public class PersonalDetailsPage
    {
        public static PersonalDetailsCommand SetBloodGroup(string Bloodgroup)
        {
            return new PersonalDetailsCommand(Bloodgroup);
        }

        public static bool IsDivorcedOptionAvailable()
        {
            return new PersonalDetailsCommand().IsDivorcedOptionAvailable();
        }
    }
}
