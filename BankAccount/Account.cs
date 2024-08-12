namespace BankAccount
{
    /// <summary>
    /// A single customer's bank account
    /// </summary>
    public class Account
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

        public double Balance { get; private set; }

        /// <summary>
        /// Add a specified amount of money to the account
        /// </summary>
        /// <param name="amt">The positive amount to deposit</param>
        /// <returns> Returns total balance after deposit </returns>
        public double Deposit(double amt)
        {
            if(amt <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposit must be greater than 0");
            }

            Balance += amt;

            return Balance;
        }

        /// <summary>
        /// Withdraws an amount of money from the balance
        /// </summary>
        /// <param name="amt"> The positive amount to be taken from
        /// the balance </param>
        /// <returns> Returns balance after the withdraw </returns>
        public double Withdraw(double amt)
        {
            if(amt > Balance)
            {
                throw new ArgumentException("Withdraw can't be greater than the balance");
            }

            if (amt <= 0) 
            {
                throw new ArgumentOutOfRangeException("Withdraw must be greater than 0");
            } 
            
            Balance -= amt;
            return Balance;
        }
    }
}
