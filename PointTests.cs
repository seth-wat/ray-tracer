using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointNS;

namespace PointTestsNS
{
    [TestClass]
    public class PointTests {
        [TestMethod]
        public void Point_WithW_EqualTo0_isVector() {
            Point point = new Point(1.24f, 12.34f, 5.34f, 0);
            
            bool isVector = point.isVector();

            Assert.AreEqual(isVector, true);
        }

        [TestMethod]
        public void Point_WithW_EqualTo1_isPoint() {
            Point point = new Point(1.45f, 34.12f, 5.02f, 1);

            bool isPoint = point.isPoint();

            Assert.AreEqual(isPoint, true);
        }

        [TestMethod]
        public void CreatePoint_CreatesAPoint() {
            Point p = Point.createPoint(1.0f, 2.34f, 0.324f);

            bool isPoint = p.isPoint();
            bool isVector = p.isVector();

            Assert.AreEqual(isPoint, true);
            Assert.AreEqual(isVector, false);
        }

        [TestMethod]
        public void CreateVector_CreatesAVector() {
            Point p = Point.createVector(1.0f, 2.34f, 0.324f);

            bool isVector = p.isVector();
            bool isPoint = p.isPoint();
            
            Assert.AreEqual(isVector, true);
            Assert.AreEqual(isPoint, false);
        }

        [TestMethod]
        public void ArePointsEqual_AreEqual() {
            Point pA = Point.createVector(1.0f, 2.34f, 0.324f);
            Point pB = Point.createVector(1.0f, 2.34f, 0.324f);

            bool isEqual = Point.arePointsEqual(pA, pB);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void ArePointsEqual_AreNotEqual() {
            Point pA = Point.createVector(1.0f, 2.34f, 0.324f);
            Point pB = Point.createVector(1.0f, 2.34f, 0.323f);

            bool isEqual = Point.arePointsEqual(pA, pB);

            Assert.AreEqual(isEqual, false);
        }
    }
}