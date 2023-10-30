using System.Globalization;

namespace MVCProjekt.Extensions
{
    public static class DarkModeAddOn
    {
        public static string TimeCheckerBg()
        {
            DateTime currentTime = DateTime.Now;
            DateTime dark = DateTime.ParseExact("18:00:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            if (currentTime < dark)
            {
                return "light";
            }
            else
            {
                return "dark";
            }
        }
        public static string TimeCheckerText()
        {
            DateTime currentTime = DateTime.Now;
            DateTime dark = DateTime.ParseExact("18:00:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            if (currentTime < dark)
            {
                return "dark";
            }
            else
            {
                return "light";
            }
        }


    }
}
