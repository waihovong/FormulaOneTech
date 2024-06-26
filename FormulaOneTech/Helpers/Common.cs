﻿using System.Globalization;
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
        
        public static decimal? ConvertToDecimalMinutes(string? time)
        {
            if (time == null)
            {
                return decimal.MaxValue;
            }

            var timeParts = time.Split(':', '.');

            int minutes = int.Parse(timeParts[0]);
            int seconds = int.Parse(timeParts[1]);
            int milliseconds = int.Parse(timeParts[2]);

            // Calculate the total number of seconds
            decimal lapTime = (minutes * 60 * 1000) + seconds * 1000 + milliseconds;

            return lapTime;
        }

        public static double CalculateTimeDifference(string time1, string time2)
        {
            TimeSpan ts1 = ParseTime(time1);
            TimeSpan ts2 = ParseTime(time2);

            double difference = (ts1 - ts2).TotalSeconds;

            return difference;
        }

        public static TimeSpan ParseTime(string time)
        {
            // Split the string into minutes, seconds, and milliseconds
            if (time != null)
            {
                var parts = time.Split(new char[] { ':', '.' });

                if (parts.Length == 3)
                {
                    int minutes = int.Parse(parts[0]);
                    int seconds = int.Parse(parts[1]);
                    int milliseconds = int.Parse(parts[2]);

                    return new TimeSpan(0, 0, minutes, seconds, milliseconds);
                }
            }

            return new TimeSpan(0, 0, 0, 0, 0);
        }
    }
}
