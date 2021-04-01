using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework8
{
    public static class Calculation
    {
        public static bool CheckData(List<string> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (!int.TryParse(numbers[i], out _))
                    return false;
            }
            return true;
        }

        public static bool CheckData(string numb)
        {
            if (!int.TryParse(numb, out _))
            {
                return false;
            }
            return true;
        }

        public static bool CheckNullDiv(List<string> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                if (Convert.ToInt32(numbers[i]) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int Mult(List<string> numbers)
        {
            int result = Convert.ToInt32(numbers[0]);

            for (int i = 1; i < numbers.Count; i++)
            {
                result *= Convert.ToInt32(numbers[i]);
            }
            return result;
        }
        
        public static int Div(List<string> numbers)
        {
            int result = Convert.ToInt32(numbers[0]);

            for (int i = 1; i < numbers.Count; i++)
            {
                result /= Convert.ToInt32(numbers[i]);
            }
            return result;
        }
        
        public static int Sum(List<string> numbers)
        {
            int result = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                result += Convert.ToInt32(numbers[i]);
            }
            return result;
        }
        
        public static int Sub(List<string> numbers)
        {
            int result = Convert.ToInt32(numbers[0]);

            for (int i = 1; i < numbers.Count; i++)
            {
                result -= Convert.ToInt32(numbers[i]);
            }
            return result;
        }
    }
}
