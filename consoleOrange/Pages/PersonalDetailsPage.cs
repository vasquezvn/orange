using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
