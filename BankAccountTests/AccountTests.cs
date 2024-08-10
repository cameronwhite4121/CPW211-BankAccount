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
    public class AccountTests
    {
        [TestMethod()]
        public void Deposit_APositiveAmount_AddToBalance()
        {
            // AAA - Arrange Act Assert
            
            // Arange
            Account acc = new Account("Crooble");

            // Act
            acc.Deposit(100);

            // Assert
            Assert.AreEqual(100, acc.Balance);
        }
    }
}