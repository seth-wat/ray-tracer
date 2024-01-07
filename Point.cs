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

        public static Point createPoint(float x, float y, float z) {
            return new Point(x, y, z, 1.0f);
        }

        public static Point createVector(float x, float y, float z) {
            return new Point(x, y, z, 0);
        }

        public static bool arePointsEqual(Point pointA, Point pointB) {
            if ((pointA.X - pointB.X) < Epsilon &&
                (pointA.Y - pointB.Y) < Epsilon &&
                (pointA.Z - pointB.Z) < Epsilon &&
                (pointA.W - pointB.W) < Epsilon) {
                    return true;
                } else {
                    return false;
                }
        }

        public static Point addPoints(Point pointA, Point pointB) {
            return new Point(
                pointA.X + pointB.X,
                pointA.Y + pointB.Y,
                pointA.Z + pointB.Z,
                pointA.W + pointB.W
            );
        }

        public static Point subtractPoints(Point pointA, Point pointB) {
            return new Point(
                pointA.X - pointB.X,
                pointA.Y - pointB.Y,
                pointA.Z - pointB.Z,
                pointA.W - pointB.W
            );
        }

        public static Point negatePoint(Point p) {
            return new Point(-p.X, -p.Y, -p.Z, p.W);
        }
    }
}