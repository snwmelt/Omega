using Omega.Model.Enum;
using System;

namespace Omega.Model
{
    /// <summary>
    /// Class for representing transactions on an Account instance.
    /// </summary>
    internal class Transaction
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Amount">Transaction Ammount.</param>
        /// <param name="Name">Transaction Name.</param>
        /// <param name="TransactionType">Transaction Type.</param>
        public Transaction(Decimal Amount, String Name, TransactionType TransactionType) : this (Amount, Name, DateTime.Now, TransactionType)
        { TransactionState = TransactionState.Resolved; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Amount">Transaction Ammount.</param>
        /// <param name="Name">Transaction Name.</param>
        /// <param name="ReviewDate">Transaction review date.</param>
        /// <param name="TransactionType">Transaction Type.</param>
        public Transaction(Decimal Amount, String Name, DateTime ReviewDate, TransactionType TransactionType)
        {
            this.Amount = Amount;
            CreatedOn = DateTime.Now;
            this.Name = Name;
            this.ReviewDate = ReviewDate;
            this.TransactionType = TransactionType;
        }

        /// <summary>
        /// Transaction amount.
        /// </summary>
        public Decimal Amount
        {
            private set;
            get;
        }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedOn
        {
            private set;
            get;
        }

        /// <summary>
        /// Transaction name.
        /// </summary>
        public String Name
        {
            private set;
            get;
        }

        /// <summary>
        /// Date for Transaction instance state review.
        /// </summary>
        public DateTime ReviewDate
        {
            set;
            get;
        }

        /// <summary>
        /// Transaction state (i.e. Outstanding or Resolved).
        /// </summary>
        public TransactionState TransactionState
        {
            set;
            get;
        }

        /// <summary>
        /// Transaction type (i.e. Credit or Debit).
        /// </summary>
        public TransactionType TransactionType
        {
            private set;
            get;
        }
    }
}
