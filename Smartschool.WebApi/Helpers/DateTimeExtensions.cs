using System;

namespace Smartschool.WebApi.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime data)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - data.Year;
            if (currentDate < data.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}