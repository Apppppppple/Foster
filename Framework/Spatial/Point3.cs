﻿using System;

namespace Foster.Framework
{
    public struct Point3
    {

        public static readonly Point3 Zero = new Point3(0, 0, 0);
        public static readonly Point3 One = new Point3(1, 1, 1);
        public static readonly Point3 Left = new Point3(-1, 0, 0);
        public static readonly Point3 Right = new Point3(1, 0, 0);
        public static readonly Point3 Up = new Point3(0, -1, 0);
        public static readonly Point3 Down = new Point3(0, 1, 0);
        public static readonly Point3 Forward = new Point3(0, 0, 1);
        public static readonly Point3 Backward = new Point3(0, 0, -1);

        public int X;
        public int Y;
        public int Z;

        public float Length => (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        public Vector3 Normal => new Vector3(X, Y, Z) / Length;

        public Point3(int xyz)
        {
            X = Y = Z = xyz;
        }

        public Point3(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Point3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object? obj) => (obj is Point3 other) && (this == other);

        public override int GetHashCode()
        {
            var hashCode = 17;
            hashCode = hashCode * 23 + X;
            hashCode = hashCode * 23 + Y;
            return hashCode;
        }

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

        public static Point3 operator -(Point3 point) => new Point3(-point.X, -point.Y, point.Z);

        public static Point3 operator /(Point3 point, int scaler) => new Point3(point.X / scaler, point.Y / scaler, point.Z / scaler);

        public static Point3 operator *(Point3 point, int scaler) => new Point3(point.X * scaler, point.Y * scaler, point.Z * scaler);

        public static Vector3 operator %(Point3 point, int scaler) => new Vector3(point.X % scaler, point.Y % scaler, point.Z % scaler);

        public static Vector3 operator /(Point3 point, float scaler) => new Vector3(point.X / scaler, point.Y / scaler, point.Z / scaler);

        public static Vector3 operator *(Point3 point, float scaler) => new Vector3(point.X * scaler, point.Y * scaler, point.Z * scaler);

        public static Vector3 operator %(Point3 point, float scaler) => new Vector3(point.X % scaler, point.Y % scaler, point.Z % scaler);

        public static Point3 operator +(Point3 a, Point3 b) => new Point3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Point3 operator -(Point3 a, Point3 b) => new Point3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static bool operator ==(Point3 a, Point3 b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;

        public static bool operator !=(Point3 a, Point3 b) => a.X != b.X || a.Y != b.Y || a.Z != b.Z;

    }
}