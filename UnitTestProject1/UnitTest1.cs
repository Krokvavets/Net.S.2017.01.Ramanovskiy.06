using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

            //[Test]
            public void Add_PositiveTest()
            {
                Polynomial pol1 = new Polynomial(3, 4, 5, 6, 7);
                Assert.AreEqual("4x^3 + 5x^2 +6x^1 +7x^0", pol1.View());
            }
        }
    }
