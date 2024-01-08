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
            Point p = Point.CreatePoint(1.0f, 2.34f, 0.324f);

            bool isPoint = p.isPoint();
            bool isVector = p.isVector();

            Assert.AreEqual(isPoint, true);
            Assert.AreEqual(isVector, false);
        }

        [TestMethod]
        public void CreateVector_CreatesAVector() {
            Point p = Point.CreateVector(1.0f, 2.34f, 0.324f);

            bool isVector = p.isVector();
            bool isPoint = p.isPoint();
            
            Assert.AreEqual(isVector, true);
            Assert.AreEqual(isPoint, false);
        }

        [TestMethod]
        public void ArePointsEqual_AreEqual() {
            Point pA = Point.CreateVector(1.0f, 2.34f, 0.324f);
            Point pB = Point.CreateVector(1.0f, 2.34f, 0.324f);

            bool isEqual = Point.ArePointsEqual(pA, pB);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void ArePointsEqual_AreNotEqual() {
            Point pA = Point.CreateVector(1.0f, 2.34f, 0.324f);
            Point pB = Point.CreateVector(1.0f, 2.34f, 0.323f);

            bool isEqual = Point.ArePointsEqual(pA, pB);

            Assert.AreEqual(isEqual, false);
        }

        [TestMethod]
        public void AddPoints_AddsPoints() {
            Point pA = Point.CreatePoint(3, -2, 5);
            Point pB = Point.CreateVector(-2, 3, 1);

            Point pExpected = Point.CreatePoint(1, 1, 6);
            Point pResult = Point.AddPoints(pA, pB);

            bool isEqual = Point.ArePointsEqual(pExpected, pResult);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void SubtractPoints_SubtractsPoints() {
            Point pA = Point.CreatePoint(3, 2, 1);
            Point pB = Point.CreatePoint(5, 6, 7);

            Point pExpected = Point.CreateVector(-2, -4, -6);
            Point pResult = Point.SubtractPoints(pA, pB);

            bool isEqual = Point.ArePointsEqual(pExpected, pResult);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void NegatePoint_NegatesPoint() {
            Point pA = Point.CreateVector(1, -2, 3);

            Point pExpected = Point.CreateVector(-1, 2, -3);
            Point pResult = Point.NegatePoint(pA);

            bool isEqual = Point.ArePointsEqual(pResult, pExpected);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void ScaleVector_MultipliesByScalar() {
            Point p = Point.CreateVector(1, -2, 3);
            Point scaled = Point.ScaleVector(p, 3.5f);

            Point exepected = Point.CreateVector(3.5f, -7, 10.5f);

            bool isEqual = Point.ArePointsEqual(scaled, exepected);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void Compute_Magnitude_A() {
            Point p = Point.CreateVector(1, 0, 0);
            double magnitude = p.calculateMagnitude();

            double expected = 1;

            Assert.AreEqual(magnitude, expected);
        }

        [TestMethod]
        public void Compute_Magnitude_B() {
            Point p = Point.CreateVector(0, 1, 0);
            double magnitude = p.calculateMagnitude();

            double expected = 1;

            Assert.AreEqual(magnitude, expected);
        }

        [TestMethod]
        public void Compute_Magnitude_C() {
            Point p = Point.CreateVector(0, 0, 1);
            double magnitude = p.calculateMagnitude();

            double expected = 1;

            Assert.AreEqual(magnitude, expected);
        }

        [TestMethod]
        public void Compute_Magnitude_D() {
            Point p = Point.CreateVector(1, 2, 3);
            double magnitude = p.calculateMagnitude();

            double expected = Math.Sqrt(14);

            Assert.AreEqual(magnitude, expected);
        }

        [TestMethod]
        public void Compute_Magnitude_E() {
            Point p = Point.CreateVector(-1, -2, -3);
            double magnitude = p.calculateMagnitude();

            double expected = Math.Sqrt(14);

            Assert.AreEqual(magnitude, expected);
        }

        [TestMethod]
        public void Normalize_Normalizes_A() {
            Point p = Point.CreateVector(4, 0, 0);

            Point expected = Point.CreateVector(1, 0, 0);
            Point result = Point.NormalizeVector(p);

            bool isEqual = Point.ArePointsEqual(result, expected);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void Normalize_Normalizes_B() {
            Point p = Point.CreateVector(1, 2, 3);

            Point expected = Point.CreateVector(0.26726f, 0.53452f, 0.80178f);
            Point result = Point.NormalizeVector(p);

            bool isEqual = Point.ArePointsEqual(expected, result);

            Assert.AreEqual(isEqual, true);
        }

        [TestMethod]
        public void CalculateDotProduct_CalculatesDotProduct() {
            Point pA = Point.CreateVector(1, 2, 3);
            Point pB = Point.CreateVector(2, 3, 4);

            float result = Point.CalculateDotProduct(pA, pB);
            float expected = 20f;

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CrossProduct_CrossesVectors() {
            Point pA = Point.CreateVector(1, 2, 3);
            Point pB = Point.CreateVector(2, 3, 4);

            Point result = Point.CrossProduct(pA, pB);
            Point expected = Point.CreateVector(-1, 2, -1);

            bool isEqual = Point.ArePointsEqual(expected, result);

            Assert.AreEqual(isEqual, true);
        }
    }
}