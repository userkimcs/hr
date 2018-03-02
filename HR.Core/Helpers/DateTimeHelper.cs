
using System;
using System.Collections.Generic;
namespace HR.Core.Helpers
{
    public class DateTimeHelper
    {

        public static DateTime CreateDate(string day, string month, string year)
        {
            return new DateTime(
                System.Convert.ToInt16(year),
                System.Convert.ToInt16(month),
                System.Convert.ToInt16(day)
                );
        }

        public static List<string> GetDate()
        {
            List<string> days = new List<string>();
            days.Add("-Please select day-");
            for (int i = 1; i <= 31; i++)
            {
                days.Add(i.ToString());
            }
            return days;
        }

        public static List<string> GetMonth()
        {
            List<string> month = new List<string>();
            month.Add("-Please select month-");
            for (int i = 1; i <= 12; i++)
            {
                month.Add(i.ToString());
            }
            return month;
        }

        public static List<string> GetYear()
        {
            List<string> years = new List<string>();
            years.Add("-Please select year-");
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - 99; i--)
            {
                years.Add(i.ToString());
            }
            return years;
        }
    }
}
