using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifierStatic
{
    public class DateModifier
    {

        public static int CalcDifference(string first, string second)
        {
            var dateTimeOne = DateTime.Parse(first);
            var dateTimeTwo = DateTime.Parse(second);
            double res = (dateTimeOne - dateTimeTwo).TotalDays;
            //System.TimeSpan diff = dateTimeTwo.Subtract(dateTimeOne);
           //string difference = diff.ToString();
           // string[] tokens = difference.Split(".", StringSplitOptions.RemoveEmptyEntries);
           // int result = int.Parse(tokens[0]);

            return Math.Abs((int)res);
        }

    }
}
