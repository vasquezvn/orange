using System;

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
