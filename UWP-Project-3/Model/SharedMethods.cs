using System;
using System.Linq;

namespace UWP_Project_3.Model
{
    public class SharedMethods
    {
        //ref https://stackoverflow.com/questions/16010804/getting-only-time-of-a-datetime-object
        public DateTime getDate(double millisecond)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();

            return day;
        }//getDate

        //ref https://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-with-maximum-performance
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }//FirstCharToUpper
    }//SharedMethods
}//UWP