using System;

namespace Capitalism.SharedKernel
{
    public class Guard
    {
        public static void ForLessZero(int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForPrecedesDate(DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForNullObject(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
    }
}
