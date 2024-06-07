using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace FormulaOneTech.Helpers
{
    public class Common
    {
        public static DateTime? ParseDateTime(string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime dateTime))
            {
                return dateTime;
            }

            return null;
        }

        public static DateTime? ConvertRaceTime(string timeString)
        {
            string format = "HH:mm:ss'Z'";
            if (DateTime.TryParseExact(timeString, format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime utcTime))
            {
                return utcTime.ToLocalTime();
            }
            else
            {
                throw new FormatException("Invalid time string format");
            }
        }

        public static DateTime? ParseSessionTime(string dateString, string timeString)
        {
            if (string.IsNullOrEmpty(dateString) || string.IsNullOrEmpty(timeString))
            {
                return null;
            }

            string dateTimeString = $"{dateString}T{timeString}";

            if (DateTime.TryParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out DateTime dateTime))
            {
                return dateTime.ToLocalTime();
            }
            else
            {
                return null;
            }

        }
    }
}
