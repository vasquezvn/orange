using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleOrange.Pages
{
    public class JobPage
    {
        public static JobCommand SetRegion(String region)
        {
            return new JobCommand(region);
        }
    }
}
