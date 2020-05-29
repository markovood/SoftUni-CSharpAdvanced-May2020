using System;

namespace DefiningClasses
{
    public static class DateModifier
    {
        public static int CalculateDifference(string someDate, string otherDate)
        {
            DateTime date1 = DateTime.Parse(someDate);
            DateTime date2 = DateTime.Parse(otherDate);

            TimeSpan difference = date1.Subtract(date2);
            
            return difference.Duration().Days;
        }
    }
}
