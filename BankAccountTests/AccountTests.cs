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
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("Crooble");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_989.08)]
        [TestCategory("DepositTest")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            // AAA - Arrange Act Assert

            // Arrange

            // Act
            acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(depositAmount, acc.Balance);
        }

        /// <summary>
        /// Tests if balance is returned after deposit is called
        /// </summary>
        [TestMethod]
        [TestCategory("DepositTest")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance() 
        {
            // Arrange/Act
            double depositAmount = acc.Deposit(100);
              
            // Assert
            Assert.AreEqual(100, depositAmount);

        }

        /// <summary>
        /// DataRow parameter is passed into method parameter to test different
        /// data. More DataRows increase number of times test method runs.
        /// </summary>
        /// <param name="invalidDeposit"></param>
        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("DepositTest")]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDeposit) 
        {

            // Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDeposit));
        }

        [TestMethod]
        [TestCategory("WithdrawTest")]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            double initialDeposit = 100;

            double withdrawAmount = 50;

            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);

            acc.Withdraw(withdrawAmount);

            double actualBalance = acc.Balance;

            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [TestCategory("WithdrawTest")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            double testDeposit = 150;
            double testWithdraw = 100;

            acc.Deposit(testDeposit);
            double returnedBalance = acc.Withdraw(testWithdraw);

            Assert.AreEqual(acc.Balance, returnedBalance);          
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.01)]
        [DataRow(-1000)]
        [TestCategory("WithdrawTest")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidWithdraw)
        {        
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Withdraw(invalidWithdraw));
        }

        [TestMethod]
        [TestCategory("WithdrawTest")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException ()
        {
            double largeWithdraw = 1500;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(largeWithdraw));
        }

        [TestMethod]
        [TestCategory("OwnerTest")]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        [DataRow("   ")]
        [DataRow("")]
        [TestCategory("OwnerTest")]
        public void Owner_EmptyStringOrWhitespace_ThrowsArgumentException(string invalidName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = invalidName);
        }

        [TestMethod]
        [DataRow("Cam")]
        [DataRow("Cameron White")]
        [DataRow("Cameron James White")]
        [TestCategory("OwnerTest")]
        public void Owner_UpTo20Characters_SetsSuccessfully(string validName)
        {
            acc.Owner = validName;
            Assert.AreEqual(validName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Cameron James White is too long of a name")]
        [DataRow("Camer0n White")]
        [TestCategory("OwnerTest")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string invalidName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = invalidName);
        }
    }
}