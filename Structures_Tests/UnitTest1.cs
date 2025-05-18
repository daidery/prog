using Microsoft.VisualStudio.TestTools.UnitTesting;
using Structures;
using System;
using System.Security.Cryptography;

namespace Structures_Tests
{
    [TestClass]
    public class ZPowerTests
    {
        [TestMethod]
        public void TestConstructor_ValidValues()
        {
            var power = new ZPower(2.0, 3);
            Assert.AreEqual(2.0, power.Base);
            Assert.AreEqual(3, power.Exponent);
            Assert.AreEqual(8.0, power.Value, 1e-13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor_InvalidZeroBaseNegativeExponent()
        {
            var power = new ZPower(0, -1);
        }

        [TestMethod]
        public void TestToString()
        {
            var power = new ZPower(1.23456, 3);
            string result = power.ToString();

            Assert.AreEqual("1.2346E3", result);
        }

        [TestMethod]
        public void TestEquals_SameValues()
        {
            var power1 = new ZPower(2.0, 3);
            var power2 = new ZPower(2.0, 3);
            Assert.IsTrue(power1.Equals(power2));
        }

        [TestMethod]
        public void TestEquals_DifferentValues()
        {
            var power1 = new ZPower(2.0, 3);
            var power2 = new ZPower(2.0, 4);
            Assert.IsFalse(power1.Equals(power2));
        }

        [TestMethod]
        public void TestGetHashCode_SameValues()
        {
            var power1 = new ZPower(2.0, 3);
            var power2 = new ZPower(2.0, 3);
            Assert.AreEqual(power1.GetHashCode(), power2.GetHashCode());
        }

        [TestMethod]
        public void TestMultiplication_SameBase()
        {
            var power1 = new ZPower(2.0, 3);
            var power2 = new ZPower(2.0, 4);
            var result = power1 * power2;
            Assert.AreEqual(2.0, result.Base);
            Assert.AreEqual(7, result.Exponent);
            Assert.AreEqual(128.0, result.Value, 1e-13);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMultiplication_DifferentBase()
        {
            var power1 = new ZPower(2.0, 3);
            var power2 = new ZPower(3.0, 4);
            var result = power1 * power2;
        }

        [TestMethod]
        public void TestDivision_SameBase()
        {
            var power1 = new ZPower(2.0, 4);
            var power2 = new ZPower(2.0, 3);
            var result = power1 / power2;
            Assert.AreEqual(2.0, result.Base);
            Assert.AreEqual(1, result.Exponent);
            Assert.AreEqual(2.0, result.Value, 1e-13);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDivision_DifferentBase()
        {
            var power1 = new ZPower(2.0, 4);
            var power2 = new ZPower(3.0, 3);
            var result = power1 / power2;
        }
    }
}

