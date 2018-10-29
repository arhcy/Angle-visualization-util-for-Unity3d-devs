// Copyright (c) 2018 Archy Piragkov. All Rights Reserved.  Licensed under the MIT license

using UnityEngine;
using System.Collections.Generic;

namespace Artics.Math
{
    public static class TransformUtils
    {
        #region SetPosition
        public static void SetX(this Transform obj, float x)
        {
            Vector3 pos = obj.position;
            pos.x = x;
            obj.position = pos;
        }
        public static void SetY(this Transform obj, float y)
        {
            Vector3 pos = obj.position;
            pos.y = y;
            obj.position = pos;
        }
        public static void SetZ(this Transform obj, float z)
        {
            Vector3 pos = obj.position;
            pos.z = z;
            obj.position = pos;
        }

        public static void SetLocalX(this Transform obj, float x)
        {
            Vector3 pos = obj.localPosition;
            pos.x = x;
            obj.localPosition = pos;
        }
        public static void SetLocalY(this Transform obj, float y)
        {
            Vector3 pos = obj.localPosition;
            pos.y = y;
            obj.localPosition = pos;
        }
        public static void SetLocalZ(this Transform obj, float z)
        {
            Vector3 pos = obj.localPosition;
            pos.z = z;
            obj.localPosition = pos;
        }

        public static void AddX(this Transform obj, float x)
        {
            Vector3 pos = obj.position;
            pos.x += x;
            obj.position = pos;
        }
        public static void AddY(this Transform obj, float y)
        {
            Vector3 pos = obj.position;
            pos.y += y;
            obj.position = pos;
        }
        public static void AddZ(this Transform obj, float z)
        {
            Vector3 pos = obj.position;
            pos.z += z;
            obj.position = pos;
        }

        public static void AddLocalX(this Transform obj, float x)
        {
            Vector3 pos = obj.localPosition;
            pos.x += x;
            obj.localPosition = pos;
        }
        public static void AddLocalY(this Transform obj, float y)
        {
            Vector3 pos = obj.localPosition;
            pos.y += y;
            obj.localPosition = pos;
        }
        public static void AddLocalZ(this Transform obj, float z)
        {
            Vector3 pos = obj.localPosition;
            pos.z += z;
            obj.localPosition = pos;
        }

        public static float GetX(this Transform obj)
        {
            return obj.position.x;
        }
        public static float GetY(this Transform obj)
        {
            return obj.position.y;
        }
        public static float GetZ(this Transform obj)
        {
            return obj.position.z;
        }

        public static float GetLocalX(this Transform obj)
        {
            return obj.localPosition.x;
        }
        public static float GetLocalY(this Transform obj)
        {
            return obj.localPosition.y;
        }
        public static float GetLocalZ(this Transform obj)
        {
            return obj.localPosition.z;
        }

        #endregion

        #region SetRotation
        public static float GetEulerX(this Transform obj)
        {
            return obj.eulerAngles.x;
        }
        public static float GetEulerY(this Transform obj)
        {
            return obj.eulerAngles.y;
        }
        public static float GetEulerZ(this Transform obj)
        {
            return obj.eulerAngles.z;
        }

        public static void SetEulerX(this Transform obj, float x)
        {
            Vector3 pos = obj.eulerAngles;
            pos.x = x;
            obj.eulerAngles = pos;
        }
        public static void SetEulerY(this Transform obj, float y)
        {
            Vector3 pos = obj.eulerAngles;
            pos.y = y;
            obj.eulerAngles = pos;
        }
        public static void SetEulerZ(this Transform obj, float z)
        {
            Vector3 pos = obj.eulerAngles;
            pos.z = z;
            obj.eulerAngles = pos;
        }

        public static void AddEulerX(this Transform obj, float x)
        {
            Vector3 pos = obj.eulerAngles;
            pos.x += x;
            obj.eulerAngles = pos;
        }
        public static void AddEulerY(this Transform obj, float y)
        {
            Vector3 pos = obj.eulerAngles;
            pos.y += y;
            obj.eulerAngles = pos;
        }
        public static void AddEulerZ(this Transform obj, float z)
        {
            Vector3 pos = obj.eulerAngles;
            pos.z += z;
            obj.eulerAngles = pos;
        }

        //local

        public static float GetLocalEulerX(this Transform obj)
        {
            return obj.localEulerAngles.x;
        }
        public static float GetLocalEulerY(this Transform obj)
        {
            return obj.localEulerAngles.y;
        }
        public static float GetLocalEulerZ(this Transform obj)
        {
            return obj.localEulerAngles.z;
        }

        public static void SetLocalEulerX(this Transform obj, float x)
        {
            Vector3 pos = obj.localEulerAngles;
            pos.x = x;
            obj.localEulerAngles = pos;
        }
        public static void SetLocalEulerY(this Transform obj, float y)
        {
            Vector3 pos = obj.localEulerAngles;
            pos.y = y;
            obj.localEulerAngles = pos;
        }
        public static void SetLocalEulerZ(this Transform obj, float z)
        {
            Vector3 pos = obj.localEulerAngles;
            pos.z = z;
            obj.localEulerAngles = pos;
        }

        public static void AddLocalEulerX(this Transform obj, float x)
        {
            Vector3 pos = obj.localEulerAngles;
            pos.x += x;
            obj.localEulerAngles = pos;
        }
        public static void AddLocalEulerY(this Transform obj, float y)
        {
            Vector3 pos = obj.localEulerAngles;
            pos.y += y;
            obj.localEulerAngles = pos;
        }
        public static void AddLocalEulerZ(this Transform obj, float z)
        {
            Vector3 pos = obj.localEulerAngles;
            pos.z += z;
            obj.localEulerAngles = pos;
        }

        #endregion

        #region TRS
        public static Matrix4x4 GetGlobalTransformMatrix(this Transform transform)
        {
            return Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        }

        public static Matrix4x4 GetGlobalTransformMatrix(this Transform transform, Vector3 position)
        {
            return Matrix4x4.TRS(position, transform.rotation, transform.lossyScale);
        }

        public static Matrix4x4 GetGlobalTransformMatrix2(this Transform transform)
        {
            Matrix4x4 matrix = transform.localToWorldMatrix;

            return LocalToWorld(transform);
            /*var parent = transform.parent;

            var matrices = new List<Matrix4x4>();
            matrices.Add(matrix);

            while (parent != null)
            {
                //matrix *= parent.worldToLocalMatrix;
                matrices.Add(parent.localToWorldMatrix);
                parent = parent.parent;
            }

            int len = matrices.Count - 1;

            matrix = matrices[len];

            while (--len >= 0)
                matrix *= matrices[len];

            return matrix;*/
        }

        // t.localToWorldMatrix
        public static Matrix4x4 LocalToWorld(Transform t)
        {
            if (t == null)
                return Matrix4x4.identity;
            else
                return LocalToWorld(t.parent) * LocalToParent(t);
        }

        public static Matrix4x4 LocalToParent(Transform transform)
        {
            return TRS(transform.localPosition, transform.localEulerAngles, transform.localScale);
        }

        // Matrix4x4.TRS(trans, Quaternion.Euler(euler), scale)
        public static Matrix4x4 TRS(Vector3 trans, Vector3 euler, Vector3 scale)
        {
            return Translate(trans) * Rotate(euler) * Scale(scale);
        }

        // Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(euler), Vector3.one)
        public static Matrix4x4 Rotate(Vector3 euler)
        {
            return RotateY(euler.y) * RotateX(euler.x) * RotateZ(euler.z);
        }

        // Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(deg, 0, 0), Vector3.one)
        public static Matrix4x4 RotateX(float deg)
        {
            var rad = deg * Mathf.Deg2Rad;
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);
            var mat = Matrix4x4.identity;
            mat.m11 = cos;
            mat.m12 = -sin;
            mat.m21 = sin;
            mat.m22 = cos;
            return mat;
        }

        // Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, deg, 0), Vector3.one)
        public static Matrix4x4 RotateY(float deg)
        {
            var rad = deg * Mathf.Deg2Rad;
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);
            var mat = Matrix4x4.identity;
            mat.m22 = cos;
            mat.m20 = -sin;
            mat.m02 = sin;
            mat.m00 = cos;
            return mat;
        }


        // Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, deg), Vector3.one)
        public static Matrix4x4 RotateZ(float deg)
        {
            var rad = deg * Mathf.Deg2Rad;
            var sin = Mathf.Sin(rad);
            var cos = Mathf.Cos(rad);
            var mat = Matrix4x4.identity;
            mat.m00 = cos;
            mat.m01 = -sin;
            mat.m10 = sin;
            mat.m11 = cos;
            return mat;
        }

        // Matrix4x4.Scale(scale)
        public static Matrix4x4 Scale(Vector3 scale)
        {
            var mat = Matrix4x4.identity;
            mat.m00 = scale.x;
            mat.m11 = scale.y;
            mat.m22 = scale.z;
            return mat;
        }

        // Matrix4x4.TRS(vec, Quaternion.identity, Vector3.one)
        public static Matrix4x4 Translate(Vector3 vec)
        {
            var mat = Matrix4x4.identity;
            mat.m03 = vec.x;
            mat.m13 = vec.y;
            mat.m23 = vec.z;
            return mat;
        }

        #endregion
    }
}
