namespace BankAccount
{
    /// <summary>
    /// A single customer's bank account
    /// </summary>
    public class Account
    {
        private string owner;

        /// <summary>
        /// Create an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="owner"></param>
        public Account(string owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// The account owner's name
        /// </summary>
        public string Owner
        {
            get { return owner; }
            set 
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Owner cannot be null");
                }

                if(value.Trim() == string.Empty)
                {
                    throw new ArgumentException("Owner cannot be empty string");
                }

                if (IsOwnerNameIsValid(value))
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException("Name of owner can be up to characters, A-Z only. Can contain spaces.");
                }
                // Check if owner is only characters

                // Check if owner is 20 characters or less
            }
        }

        /// <summary>
        /// Checks if the owner name is 20 character or less, and that it
        /// contains character A-Z only, with spaces being allowed.
        /// </summary>
        /// <returns></returns>
        private bool IsOwnerNameIsValid(string ownerName)
        {
            int ownerLength = 0;

            ownerName = ownerName.ToLower();

            char[] validCharacters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
                                     'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                                     's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '};

            foreach(char letter in ownerName)
            {
                ownerLength++;
                if(!validCharacters.Contains(letter)) 
                {
                    return false;
                }
                if(ownerLength > 20)
                {
                    return false;
                }
            }

            return true;
        }

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
