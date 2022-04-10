using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private IFormatProvider cultureInfo;

        private string Difference;

        public string difference
        {
            get { return Difference; }
            set { Difference = value; }
        }

        public int CalcDifference(string first, string second)
        {
            var dateTimeOne = DateTime.Parse(first);
            var dateTimeTwo = DateTime.Parse(second);
            System.TimeSpan diff = dateTimeTwo.Subtract(dateTimeOne);
            string difference = diff.ToString();
            string[] tokens = difference.Split(".", StringSplitOptions.RemoveEmptyEntries);
            int result = int.Parse(tokens[0]);

            return Math.Abs(result);
        }

    }
}
