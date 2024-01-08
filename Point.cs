using System.Numerics;

namespace PointNS
{
    public class Point {
        float X;
        float Y;
        float Z;
        float W;
        private const float Epsilon = 0.00001f;

        public Point(float x, float y, float z, float w) {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public bool isPoint() {
            return W == 1.0;
        }

        public bool isVector() {
            return W == 0;
        }

        public double calculateMagnitude() {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        public static Point CreatePoint(float x, float y, float z) {
            return new Point(x, y, z, 1.0f);
        }

        public static Point CreateVector(float x, float y, float z) {
            return new Point(x, y, z, 0);
        }

        public static bool ArePointsEqual(Point pointA, Point pointB) {
            if ((pointA.X - pointB.X) < Epsilon &&
                (pointA.Y - pointB.Y) < Epsilon &&
                (pointA.Z - pointB.Z) < Epsilon &&
                (pointA.W - pointB.W) < Epsilon) {
                    return true;
                } else {
                    return false;
                }
        }

        public static Point AddPoints(Point pointA, Point pointB) {
            return new Point(
                pointA.X + pointB.X,
                pointA.Y + pointB.Y,
                pointA.Z + pointB.Z,
                pointA.W + pointB.W
            );
        }

        public static Point SubtractPoints(Point pointA, Point pointB) {
            return new Point(
                pointA.X - pointB.X,
                pointA.Y - pointB.Y,
                pointA.Z - pointB.Z,
                pointA.W - pointB.W
            );
        }

        public static Point NegatePoint(Point p) {
            return new Point(-p.X, -p.Y, -p.Z, p.W);
        }

        public static Point ScaleVector(Point pointA, float scalar) {
            return CreateVector(
                pointA.X * scalar,
                pointA.Y * scalar,
                pointA.Z * scalar
            );
        }

        public static Point NormalizeVector(Point pointA) {
            double magnitude = pointA.calculateMagnitude();
            return CreateVector(
                pointA.X / (float)magnitude,
                pointA.Y / (float)magnitude,
                pointA.Z / (float)magnitude
            );
        }

        public static float CalculateDotProduct(Point pointA, Point pointB) {
            return(
                pointA.X * pointB.X +
                pointA.Y * pointB.Y +
                pointA.Z * pointB.Z
            );
        }

        public static Point CrossProduct (Point pointA, Point pointB) {
            return CreateVector(
                pointA.Y * pointB.Z - pointA.Z * pointB.Y,
                pointA.Z * pointB.X - pointA.X * pointB.Z,
                pointA.X * pointB.Y - pointA.Y * pointB.X
            );
        }

    }
}