using System.Collections;
using DynamicFormula.Models.Entity;

namespace DynamicFormula.Helper
{
    public static class CustomFunction
    {
        private const int _ROUND_PLACE = 0;
        //Flee hieu default gia tri truyen vao la double
        public static decimal RoundUp(double value)
        {
            return RoundBase((decimal)value, _ROUND_PLACE, 0);
        }
        public static decimal RoundDown(double value)
        {
            return RoundBase((decimal)value, _ROUND_PLACE, 1);
        }
        public static decimal Round(double value)
        {
            return RoundBase((decimal)value, _ROUND_PLACE, 2);
        }
        public static decimal Sum(params double[] value)
        {
            return RoundBase((decimal)value.Sum(), _ROUND_PLACE, 2);
        }
        //type = 0: UP, 1: DOWN, 2: DEFAULT
        private static decimal RoundBase(decimal input, int place, int type)
        {
            decimal multiplier = Convert.ToDecimal(Math.Pow(10, place));
            if(type ==0)
                return decimal.Ceiling(input * multiplier) / multiplier;
            if (type == 1)
                return Math.Floor(input * multiplier) / multiplier;
            return Math.Round(input, _ROUND_PLACE);
        }

        public static decimal Sum(object arg)
        {
            decimal[] arr = ((IEnumerable)arg).Cast<object>().Select(x => Convert.ToDecimal(x)).ToArray();
            decimal sum = 0;
            foreach (decimal i in arr)
                sum += i;

            return sum;
        }

        public static decimal Count(object arg)
        {
            string[] arr = ((IEnumerable)arg).Cast<object>().Select(x => x.ToString()).ToArray();
            return arr.Count();
        }

    }
}

