using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artics.Math
{
    public static partial class MathUtils
    {
        public static float GetSign(float num)
        {
            if (num >= 0)
                return 1;
            else
                return -1;
        }

        public static float GetZeroOrSign(float num)
        {
            if (num > 0)
                return 1;
            else
                if (num < 0)
                return -1;
            else
                return 0;
        }

        public static float DecreaseValue(float value, float decreaseNum)
        {
            return value >= 0 ? value - decreaseNum : value + decreaseNum;
        }

        public static float DecreaseValueNoNegative(float value, float decreaseNum)
        {
            if (value == 0)
                return value;

            float rezult = value >= 0 ? value - decreaseNum : value + decreaseNum;
            return rezult * value >= 0 ? rezult : 0;
        }
    }
}
