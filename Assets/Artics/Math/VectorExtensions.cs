using System;
using UnityEngine;

namespace Artics.Math
{
    public static class VectorExtensions
    {
        #region Rotation90
        public static Vector2 RotateLeft(this Vector2 vec)
        {
            return new Vector2(-vec.y, vec.x);
        }

        public static Vector2 RotateRight(this Vector2 vec)
        {
            return new Vector2(vec.y, -vec.x);
        }

        public static void RotateLeft(ref Vector2 vec)
        {
            vec.Set(-vec.y, vec.x);
        }

        public static void RotateRight(ref Vector2 vec)
        {
            vec.Set(vec.y, -vec.x);
        }
        public static void RotateLeftXY(ref Vector3 vec)
        {
            vec.Set(-vec.y, vec.x, vec.z);
        }

        public static void RotateRightXY(ref Vector3 vec)
        {
            vec.Set(vec.y, -vec.x, vec.z);
        }
        #endregion

        #region Add
        public static Vector3 Add(this Vector2 destination, Vector2 source)
        {
            destination.x += source.x;
            destination.y += source.y;

            return destination;
        }

        public static Vector3 Add(this Vector3 destination, Vector2 source)
        {
            destination.x += source.x;
            destination.y += source.y;

            return destination;
        }
        #endregion

        #region Convert
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 ToVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, vector.y);
        }
        #endregion

        #region Atan_for_Vector3
        public static float CalcAtan2YX(this Vector2 vector)
        {
            return (float)System.Math.Atan2(vector.y, vector.x);
        }

        public static float CalcAtan2YX(this Vector3 vector)
        {
            return (float)System.Math.Atan2(vector.y, vector.x);
        }

        public static float CalcAtan2XY(this Vector2 vector)
        {
            return (float)System.Math.Atan2(vector.x, vector.y);
        }

        public static float CalcAtan2XY(this Vector3 vector)
        {
            return (float)System.Math.Atan2(vector.x, vector.y);
        }
        #endregion

        #region Atan_for_Vector2
        public static float Atan2XY(this Vector2 vector)
        {
            return (float)System.Math.Atan2(vector.x, vector.y);
        }
        public static float Atan2YX(this Vector2 vector)
        {
            return (float)System.Math.Atan2(vector.y, vector.x);
        }
        public static float Atan2nXY(this Vector2 vector)
        {
            return (float)System.Math.Atan2(-vector.x, vector.y);
        }
        public static float Atan2XnY(this Vector2 vector)
        {
            return (float)System.Math.Atan2(vector.x, -vector.y);
        }
        public static float Atan2nYX(this Vector2 vector)
        {
            return (float)System.Math.Atan2(-vector.y, vector.x);
        }
        public static float Atan2YnX(this Vector2 vector)
        {
            return (float)System.Math.Atan2(vector.y, -vector.x);
        }
        #endregion

        #region Angles
        public static float EulerAngle(this Vector2 vector)
        {
            return vector.Atan2XY() * Mathf.Rad2Deg;
        }

        #endregion
    }
}
