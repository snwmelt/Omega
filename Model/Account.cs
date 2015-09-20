using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Omega.Model
{
    // Make ISerializable on completion\\
    internal class Account : INotifyPropertyChanged
    {
        #region Private_Variables

        private Decimal _Balance;
        private List<Transaction> _Transactions;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Name">Account Name</param>
        public Account(String Name) : this(Name, 0.0m)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Name">Account Name</param>
        /// <param name="Balance">Starting Balance</param>
        public Account(String Name, Decimal Balance)
        {
            _Balance      = Balance;
            this.Name     = Name;
            _Transactions = new List<Transaction>();
        }
        
        /// <summary>
        /// Assigns a value to a property and raises the PropertyChanged event if not null.
        /// </summary>
        /// <typeparam name="T">Type Specifier.</typeparam>
        /// <param name="Property">Reference to property to assign Value to.</param>
        /// <param name="PropertyName">Property name/title for PropertyChanged event call.</param>
        /// <param name="Value">Value to be assigned to referenced property.</param>
        private void AssignPropertyValue<T>(ref T Property, String PropertyName, T Value)
        {
            Property = Value;

            RaisePropertyChangedEvent(PropertyName);
        }

        /// <summary>
        /// Currently available funds within this account.
        /// </summary>
        public Decimal Balance
        {
            set
            {
                AssignPropertyValue<Decimal>(ref _Balance, "Balance", value);
            }
            get
            {
                return _Balance;
            }
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
        /// Assign multiple Transaction objects to the Account instance based on frequency and time.
        /// </summary>
        /// <param name="EndDate">Date to stop running transaction.</param>
        /// <param name="Frequency">Time between Transaction objects.</param>
        /// <param name="StartDate">Start date of running transaction.</param>
        /// <param name="Transaction">Base Transaction object to repeat.</param>
        public void CreateRunningTransaction(DateTime EndDate, TimeSpan Frequency, DateTime StartDate, Transaction Transaction)
        {
            for (DateTime ReviewDate = StartDate; EndDate >= ReviewDate; ReviewDate = ReviewDate.Add(Frequency))
            {
                Transaction RepeatTransaction = new Transaction(Transaction.Amount, Transaction.Name, ReviewDate, Transaction.TransactionType);

                CreateTransaction(RepeatTransaction);
            }
        }

        /// <summary>
        /// Assign a Transaction object to the Account instance.
        /// </summary>
        /// <param name="Transaction"></param>
        public void CreateTransaction(Transaction Transaction)
        {
            if (Transaction != null)
            {
                _Transactions.Add(Transaction);

                RaisePropertyChangedEvent("Transactions");
            }
        }

        /// <summary>
        /// Account Name.
        /// </summary>
        public String Name
        {
            private set;
            get;
        }

        /// <summary>
        /// Event to be raised when a public class propety value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise PropertyChanged event if not null.
        /// </summary>
        /// <param name="PropertyName"></param>
        public void RaisePropertyChangedEvent(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        
        /// <summary>
        /// Resolved transactions.
        /// </summary>
        public IEnumerable<Transaction> Transactions
        {
            get
            {
                return _Transactions;
            }
        }
    }
}
