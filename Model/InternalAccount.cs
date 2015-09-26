using Omega.Model.Enum;
using Omega.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Omega.Model
{
    // Make ISerializable on completion\\
    internal class InternalAccount : IAccount, INotifyPropertyChanged
    {
        #region Private_Variables

        private Decimal                  _Balance;
        private List<AccountTransaction> _Transactions;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Name">Account Name</param>
        public InternalAccount(UInt32 AccountNumber, String Name) : this(AccountNumber, 0.0m, Name)
        { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Name">Account Name</param>
        /// <param name="Balance">Starting Balance</param>
        public InternalAccount(UInt32 AccountNumber, Decimal Balance, String Name)
        {
            this.AccountNumber = AccountNumber;
            this.Balance       = Balance;
            this.Name          = Name;
            SortCode           = String.Empty; // Possibly use machine ID?
            _Transactions      = new List<AccountTransaction>();
        }

        /// <summary>
        /// Account identification number.
        /// </summary>
        public UInt32 AccountNumber
        {
            private set;
            get;
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
            private set
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
        /// Assign multiple AccountTransaction objects to the Account instance based on frequency and time.
        /// </summary>
        /// <param name="Amount">Repeat transaction amount.</param>
        /// <param name="EndDate">Date to stop running transaction.</param>
        /// <param name="Frequency">Time between AccountTransaction objects.</param>
        /// <param name="Name">Transaction name.</param>
        /// <param name="StartDate">Start date of running transaction.</param>
        /// <param name="Type">Transaction type (i.e. Credit or Debit).</param>
        public void CreateRunningTransaction(Decimal Amount, IAccount Destination, DateTime EndDate, TimeSpan Frequency, 
                                             String Name, IAccount Origin, DateTime StartDate, TransactionType Type)
        {
            for (DateTime ReviewDate = StartDate; EndDate >= ReviewDate; ReviewDate = ReviewDate.Add(Frequency))
                CreateTransaction(Amount, Destination, Name, Origin, ReviewDate, Type);
        }

        /// <summary>
        /// Assign an AccountTransaction object to the Account instance.
        /// </summary>
        /// <param name="Amount">Transaction amount.</param>
        /// <param name="Name">Transaction name.</param>
        /// <param name="ReviewDate">Date for transaction state review.</param>
        /// <param name="Type">Transaction type (i.e. Credit or Debit).</param>
        public void CreateTransaction(Decimal Amount, IAccount Destiation, String Name, IAccount Origin, DateTime ReviewDate, 
                                      TransactionType Type)
        {
            AccountTransaction Transaction = new AccountTransaction(Amount, this, TransactionCount, Name, ReviewDate, Type);
            
            Transaction.Destination = Destiation;
            Transaction.Origin      = Origin;

            _Transactions.Add(Transaction);

            RaisePropertyChangedEvent("Transactions");
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
        /// Account location (i.e. bank and branch).
        /// </summary>
        public String SortCode
        {
            private set;
            get;
        }

        /// <summary>
        /// Number of account transactions.
        /// </summary>
        public Int64 TransactionCount
        {
            get
            {
                return _Transactions.Count;
            }
        }

        /// <summary>
        /// Account transactions.
        /// </summary>
        public IEnumerable<AccountTransaction> Transactions
        {
            get
            {
                return _Transactions;
            }
        }
    }
}
