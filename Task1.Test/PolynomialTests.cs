
using NUnit.Framework;
using System;
using Task1;

namespace Task1.Tests1
{
    [TestFixture]
    public class PolynomialTest
    {
        [TestCase(" 5x + 6", 5, 6)]
        [TestCase(" 6x", 6, 0)]
        [TestCase(" 5x",5, 0)]
        [TestCase(" 4x^2 + 5x + 6", 4, 5, 6)]
        [TestCase(" 5x^2 -6x + 2", 5, -6, 2)]
        [TestCase(" 7x^3 + 4x^2 + 6",7, 4, 0, 6)]
        [TestCase(" 4x^3 + 5x^2 + 6x + 7", 4, 5, 6, 7)]
        [TestCase(" 9x^4 -4x^3 + 5x^2 + 7",9, -4, 5, 0, 7)]
        [Test]
        public void ToString_PositiveTest(string expectedResult, params double[]coefficients)
        {
            Assert.AreEqual(expectedResult, new Polynomial(coefficients).ToString());
        }

        [TestCase(" 8x^3 + 10x^2 + 12x + 14", 4, 5, 6, 7)]
        [TestCase(" 9x^3 + 11x^2 + 14x + 4", 5, 6, 8, -3)]
        [TestCase(" 8x^3 + 5x^2 + 12x + 14", 4, 0, 6, 7)]
        [Test]
        public void Add_PositiveTest(string expectedResult, params double[] coefficients)
        {
            Polynomial pol1 = new Polynomial(4, 5, 6, 7);
            pol1 = pol1 + new Polynomial(coefficients);
            Assert.AreEqual(expectedResult, pol1.ToString());
        }

        [TestCase("0", 4, 5, 6, 7)]
        [TestCase(" 3x^4 + 1x^3 + 1x^2 + 2x -10", 3, 5, 6, 8, -3)]
        [TestCase(" 5x^4 -5x^2", 5, 4, 0, 6, 7)]
        [Test]
        public void Sub_PositiveTest(string expectedResult, params double[] coefficients)
        {
            Polynomial pol1 = new Polynomial(4, 5, 6, 7);
            pol1 = new Polynomial(coefficients) - pol1;
            Assert.AreEqual(expectedResult, pol1.ToString());
        }

        [TestCase(" 12x^7 + 31x^6 + 58x^5 + 94x^4 + 116x^3 + 106x^2 + 84x + 49", 4, 5, 6, 7)]
        [TestCase(" 9x^8 + 27x^7 + 53x^6 + 91x^5 + 104x^4 + 99x^3 + 75x^2 + 38x -21", 3, 5, 6, 8, -3)]
        [TestCase(" 15x^8 + 32x^7 + 41x^6 + 68x^5 + 104x^4 + 86x^3 + 71x^2 + 84x + 49", 5, 4, 0, 6, 7)]
        [Test]
        public void Mul_By_Poynomial_PositiveTest(string expectedResult, params double[] coefficients)
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 6, 7);
            pol1 = pol1 * new Polynomial(coefficients);
            Assert.AreEqual(expectedResult, pol1.ToString());
        }

        [TestCase(" 20x^3 + 25x^2 + 30x + 35",5, 4, 5, 6, 7)]
        [TestCase(" 10x^3 + 12x^2 + 16x -6", 2, 5, 6, 8, -3)]
        [TestCase(" 15x^4 + 12x^3 + 18x + 21", 3, 5, 4, 0, 6, 7)]
        [Test]
        public void Mul_By_TheNumber_PositiveTest(string expectedResult, double value, params double[] coefficients)
        {
            Polynomial pol1 = new Polynomial(coefficients)*value;
            Assert.AreEqual(expectedResult, pol1.ToString());
        }
        [TestCase(0.1, 4, 5, 6, 7, " 40x^3 + 50x^2 + 60x + 70")]
        [TestCase(2, 8, 6, 8, -3, " 4x^3 + 3x^2 + 4x -1,5")]
        [TestCase(10, 40, 0, 60, 70, " 4x^3 + 6x + 7")]
        [Test]
        public void Div_By_TheNumber_PositiveTest(double value, double coefficient1, double coefficient2, double coefficient3, double coefficient4, string expectedResult)
        {
            Polynomial pol1 = new Polynomial( coefficient1, coefficient2, coefficient3, coefficient4) / value;
            Assert.AreEqual(expectedResult, pol1.ToString());
        }
        [TestCase(3, 4, 6, 7, false)]
        [TestCase(2, 5, 3, 3, false)]
        [TestCase(2, 3, 2, 3, true)]
        [TestCase(4, 2.5, 4, 2.5, true)]
        [TestCase(-2, 30, -2, 30, true)]
        [Test]
        public void Equals_PositiveTest( double coefficient1, double coefficient2, double coefficient3, double coefficient4, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(coefficient1, coefficient2) == new Polynomial( coefficient3, coefficient4));
        }

        [TestCase(5, 6, 1, 11)]
        [TestCase(6, 0, 2, 12)]
        [TestCase(5, -6,-10, -56)]
        [Test]
        public void GetValue_PositiveTest(double coefficient1, double coefficient2, double x, double expectedResult)
        {
            Assert.AreEqual(expectedResult, new Polynomial(coefficient1, coefficient2).GetValue(x));
        }

        [TestCase(-1)]
        [TestCase()]
        public void Array_Params_ArgumentOutOfRangeException(params double[] numbers)
        {            
            Assert.Throws<ArgumentOutOfRangeException>(() => new Polynomial(numbers));
        }

    }
}



