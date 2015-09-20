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
        private String _Name;
        private List<Transaction> _Transactions;

        #endregion

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
        /// Assign multiple Transaction object to the Account instance
        /// </summary>
        /// <param name="EndDate"></param>
        /// <param name="Frequency"></param>
        /// <param name="StartDate"></param>
        /// <param name="Transaction"></param>
        public void CreateRunningTransaction(DateTime EndDate, DateTime Frequency, DateTime StartDate, Transaction Transaction)
        {

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
