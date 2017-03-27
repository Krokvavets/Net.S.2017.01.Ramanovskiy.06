
using NUnit.Framework;
using System;
using Task1;

namespace Task1.Tests1
{
    [TestFixture]
    public class PolynomialTest
    {
        [TestCase(3, 5, 6, " 5x^3 + 6x^2")]
        [TestCase(7, 6, 0, " 6x^7")]
        [TestCase(3, 5, -6, " 5x^3 -6x^2")]        
        [Test]
        public void ToString_And_Constructar_With_Two_Params_PositiveTest(int power, double coefficient1, double coefficient2, string expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(power, coefficient1, coefficient2).ToString());
        }

        [TestCase(3, 4, 5, 6, " 4x^3 + 5x^2 + 6x")]
        [TestCase(9, -4, 5, 0, " -4x^9 + 5x^8")]
        [TestCase(3, 5, -6, 2, " 5x^3 -6x^2 + 2x")]
        [TestCase(7, 4, 0, 6, " 4x^7 + 6x^5")]
        [Test]
        public void ToString_And_Constructar_With_Three_Params_PositiveTest(int power, double coefficient1, double coefficient2, double coefficient3, string expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(power, coefficient1, coefficient2, coefficient3).ToString());
        }

        [TestCase(3, 4, 5, 6, 7, " 4x^3 + 5x^2 + 6x + 7")]
        [TestCase(9, -4, 5, 0, 7, " -4x^9 + 5x^8 + 7x^6")]
        [Test]
        public void ToString_And_Constructar_With_Four_Params_PositiveTest(int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(power, coefficient1, coefficient2, coefficient3, coefficient4).ToString());
        }
        [TestCase(3, 4, 5, 6, 7, " 8x^3 + 10x^2 + 12x + 14")]
        [TestCase(3, 5, 6, 8, -3, " 9x^3 + 11x^2 + 14x + 4")]
        [TestCase(5, 4, 0, 6, 7, " 4x^5 + 10x^3 + 12x^2 + 6x + 7")]
        [Test]
        public void Add_PositiveTest(int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 6, 7);
            pol1 = pol1 + new Polynomial(power, coefficient1, coefficient2, coefficient3, coefficient4);
            Assert.AreEqual(expectedResult, pol1.ToString());
        }

        [TestCase(3, 4, 5, 6, 7, "0")]
        [TestCase(3, 5, 6, 8, -3, " 1x^3 + 1x^2 + 2x -10")]
        [TestCase(5, 4, 0, 6, 7, " 4x^5 + 2x^3 + 2x^2 -6x -7")]
        [Test]
        public void Sub_PositiveTest(int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 6, 7);
            pol1 = new Polynomial(power, coefficient1, coefficient2, coefficient3, coefficient4) - pol1;
            Assert.AreEqual(expectedResult, pol1.ToString());
        }

        [TestCase(3, 4, 5, 6, 7, " 16x^6 + 40x^5 + 73x^4 + 116x^3 + 106x^2 + 84x + 49")]
        [TestCase(3, 5, 6, 8, -3, " 20x^6 + 49x^5 + 92x^4 + 99x^3 + 75x^2 + 38x -21")]
        [TestCase(5, 4, 0, 6, 7, " 16x^8 + 20x^7 + 48x^6 + 86x^5 + 71x^4 + 84x^3 + 49x^2")]
        [Test]
        public void Mul_By_Poynomial_PositiveTest(int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 6, 7);
            pol1 = pol1 * new Polynomial(power, coefficient1, coefficient2, coefficient3, coefficient4);
            Assert.AreEqual(expectedResult, pol1.ToString());
        }

        [TestCase(5, 3, 4, 5, 6, 7, " 20x^3 + 25x^2 + 30x + 35")]
        [TestCase(2, 3, 5, 6, 8, -3, " 10x^3 + 12x^2 + 16x -6")]
        [TestCase(3, 5, 4, 0, 6, 7, " 12x^5 + 18x^3 + 21x^2")]
        [Test]
        public void Mul_By_TheNumber_PositiveTest(double value, int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Polynomial pol1 = new Polynomial(power, coefficient1, coefficient2, coefficient3, coefficient4)*value;
            Assert.AreEqual(expectedResult, pol1.ToString());
        }
        [TestCase(0.1, 3, 4, 5, 6, 7, " 40x^3 + 50x^2 + 60x + 70")]
        [TestCase(2, 3, 8, 6, 8, -3, " 4x^3 + 3x^2 + 4x -1,5")]
        [TestCase(10, 5, 40, 0, 60, 70, " 4x^5 + 6x^3 + 7x^2")]
        [Test]
        public void Div_By_TheNumber_PositiveTest(double value, int power, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Polynomial pol1 = new Polynomial(power, coefficient1, coefficient2, coefficient3, coefficient4) / value;
            Assert.AreEqual(expectedResult, pol1.ToString());
        }
        [TestCase(1, 3, 4, 5, 6, 7, false)]
        [TestCase(2, 2, 5, 4, 3, 3, false)]
        [TestCase(5, 2, 3, 5, 2, 3, true)]
        [TestCase(7, 4, 2.5, 7, 4, 2.5, true)]
        [TestCase(5, -2, 30, 5, -2, 30, true)]
        [Test]
        public void Equals_PositiveTest( int power, double coefficient1, double coefficient2, int power2, double coefficient3, double coefficient4, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(power, coefficient1, coefficient2) == new Polynomial(power2, coefficient3, coefficient4));
        }

        [TestCase(3, 5, 6, 1, 11)]
        [TestCase(2, 6, 0, 2, 24)]
        [TestCase(3, 5, -6,-10, -5600)]
        [Test]
        public void GetValue_PositiveTest(int power, double coefficient1, double coefficient2, double x, double expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(power, coefficient1, coefficient2).GetValue(x));
        }

        [TestCase(-1, 0,0,0,0,0,0)]
        [TestCase(0, 0, 0, 0,0,0,0)]
        [TestCase(2, 0, 0, 0, 0, 0,0,0)]
        public void Array_Params_ThrowsArgumentException(int power, params int[] numbers)
        {            
            Assert.Throws<ArgumentException>(() => new Polynomial(power, numbers[0], numbers[1], numbers[2], numbers[4], numbers[5]));
        }

    }
}



