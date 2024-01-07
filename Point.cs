namespace PointNS
{
    public class Point {
        float X;
        float Y;
        float Z;
        float W;
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
    }
}