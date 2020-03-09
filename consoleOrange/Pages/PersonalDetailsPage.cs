using System;

namespace consoleOrange.Pages
{
    public class PersonalDetailsPage
    {
        public static PersonalDetailsCommand SetBloodGroup(string bloodGroup)
        {
            return new PersonalDetailsCommand().SetBloodGroup(bloodGroup);
        }

        public static bool IsMaritalStatusOptionAvailable(string maritalStatusOption)
        {
            return new PersonalDetailsCommand().IsMaritalStatusOptionAvailable(maritalStatusOption);
        }
    }
}
