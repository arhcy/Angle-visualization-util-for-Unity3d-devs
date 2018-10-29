using System;

namespace Artics.Math
{
    public static partial class MathUtils
    {
        public const double RadToDegD = 180d / System.Math.PI;
        public const float RadToDegF = (float)RadToDegD;
        /// <summary>
        /// converts angle of any size (in degrees) to range [-180; 180]
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static float ConvertTo180Period(float angle)
        {
            int period = (int)System.Math.Abs(angle / 180);
            angle %= 180;

            if (period % 2 == 1)
                return angle;

            return (180 - System.Math.Abs(angle)) * GetSign(angle) * -1;
        }

        public static float ConvertTo180Period2(float angle)
        {
            int period = (int)System.Math.Abs(angle / 180);
            angle %= 180;

            if (period % 2 == 0)
                return angle;

            return -(180 - System.Math.Abs(angle));
        }

        public static float GetEulerAngle(float x, float y)
        {
            return ConvertTo180Period((float)System.Math.Atan2(y, x) * RadToDegF);
        }

        public static float FindNearestAngle(float rAngle, float dAngle, float limit = 1f)
        {
            if (dAngle * rAngle < 0)
            {
                float left, right;
                float dangleSign = MathUtils.GetSign(dAngle);

                left = dAngle > 0 ? -dAngle : dAngle;
                right = (float)System.Math.PI - dAngle * dangleSign;

                rAngle *= MathUtils.GetSign(rAngle);

                left -= rAngle;
                right += (float)System.Math.PI - rAngle;

                if (System.Math.Abs(left) < System.Math.Abs(right))
                    return -left * dangleSign;
                else
                    return -right * dangleSign;
            }
            else
            {
                return dAngle - rAngle;
            }
        }

    }
}
