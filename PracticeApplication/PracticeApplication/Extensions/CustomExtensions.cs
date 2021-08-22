using System;

namespace PracticeApplication.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToShortDate(this DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.ToShortDateString();
            }
            return "";
        }
    }
}
