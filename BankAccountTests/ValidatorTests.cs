using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class ValidatorTests
    {
        [TestMethod()]
        [DataRow(0, 100, 0)]
        [DataRow(0, 100, 100)]
        [DataRow(0, 100, 49.99)]
        [TestCategory("ValidatorTest")]
        public void IsWithinRange_InclusiveRange_ReturnsTrue(double min, double max, double test)
        {
            bool result = Validator.isWithinRange(min, max, test);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow(0, 100, -0.1)]
        [DataRow(0, 100, 100.01)]
        [TestCategory("ValidatorTest")]
        public void IsWithinRange_OutOfRangeValue_ReturnsFalse(double min, double max, double test)
        {
            bool result = Validator.isWithinRange(min, max, test);
            Assert.IsFalse(result);
        }
    }
}