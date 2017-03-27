using NUnit.Framework;
using System;
using Task1;

namespace Task1.Tests1
{
    //[TestFixture]
    public class PolynomialTest
    {
        //[Test]
        public void Add_PositiveTest()
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 6, 7);
            Assert.AreEqual("4x^3 + 5x^2 +6x^1 +7x^0", pol1.View());
        }
    }
}

