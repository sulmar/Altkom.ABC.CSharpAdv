using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    public class ExtensionMethodTests
    {
        public static void Test()
        {
            DateTime dateTime = DateTime.Today;

            // bool isWeekend = DateTimeHelper.IsWeekend(dateTime);


             


            bool isWekeend = dateTime.IsWeekend();

            DateTime.Today.AddWorkDays(5);

            // dateTime.IsWeekend()

            string text = "Hello world!";

            string result = "Hello".RemoveSpecialSigns();


             DateTime date =  10.Days();
            
            
        }
    }

    public static class IntExtensions
    {
        public static DateTime Days(this int days)
        {
            return DateTime.Today.AddDays(days);
        }
    }

    public static class StringExtensions
    {
        public static string RemoveSpecialSigns(this string input) 
            => input.Replace("!", string.Empty);
    }

    public class DateTimeHelper
    {
        

        public static bool IsWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkDays(this DateTime dateTime, byte days)
        {
            return dateTime.AddDays(days);
        }
    }


}
