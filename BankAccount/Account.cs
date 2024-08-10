using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// A single customer's bank account
    /// </summary>
    internal class Account
    {
        /// <summary>
        /// Create an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="owner"></param>
        public Account(string owner)
        {
            Owner = owner;
        }

        public string Owner { get; set; }

        public double Balance { get; set; }

        /// <summary>
        /// Add a specified amount of money to the account
        /// </summary>
        /// <param name="amt">The positive amount to deposit</param>
        public void Deposit(double amt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Withdraws an amount of money from the balance
        /// </summary>
        /// <param name="amt"> The positive amount to be taken from
        /// the balance </param>
        public void Withdraw(double amt)
        {
            throw new NotImplementedException(); 
        }
    }
}
