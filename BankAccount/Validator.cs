using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public static class Validator
    {
        public static bool isWithinRange(double minimumValue, double maxValue, double valueToTest)
        {
            if (valueToTest >= minimumValue && valueToTest <= maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
