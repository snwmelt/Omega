using Omega.Model.Enum;
using Omega.Model.Interface;
using System;
using System.ComponentModel;

namespace Omega.Model
{
    // Make ISerializable on completion\\
    internal class AccountTransaction : INotifyPropertyChanged
    {
        #region Private_Variables

        private IAccount         _Destination;
        private String           _Name;
        private IAccount         _Origin;
        private IAccount         _Owner;
        private DateTime         _ResolvedOn;
        private DateTime         _ReviewDate;
        private TransactionState _State;
        private TransactionType  _Type;

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Amount">Transaction amount.</param>
        /// <param name="Owner">Transaction owner Account.</param>
        /// <param name="ID">Transaction identification number.</param>
        /// <param name="Name">Transaction name.</param>
        /// <param name="ReviewDate">DateTime for transaction state review.</param>
        /// <param name="Type">Transaction type.</param>
        public AccountTransaction(Decimal Amount, IAccount Owner, Int64 ID, String Name, DateTime ReviewDate, 
                                  TransactionType Type)
        {
            this.Amount     = Amount;
            this.ID         = ID;
            this.Name       = Name;
            this.Owner      = Owner;
            this.ReviewDate = ReviewDate;
            this.Type       = Type;

            CreatedOn = DateTime.Now;
        }

        /// <summary>
        /// AccountTransaction amount.
        /// </summary>
        public Decimal Amount
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

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
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
        /// AccountTransaction destination Account.
        /// </summary>
        public IAccount Destination
        {
            set
            {
                if (_Destination == null)
                    AssignPropertyValue(ref _Destination, "Destination", value);
            }

            get
            {
                return _Destination;
            }
        }

        /// <summary>
        /// AccountTransaction ID.
        /// </summary>
        public Int64 ID
        {
            private set;
            get;
        }

        /// <summary>
        /// AccountTransaction name.
        /// </summary>
        public String Name
        {
            private set
            {
                AssignPropertyValue(ref _Name, "Name", value);
            }

            get
            {
                return _Name;
            }
        }

        /// <summary>
        /// AccountTransaction origin Account.
        /// </summary>
        public IAccount Origin
        {
            set
            {
                if (_Origin == null)
                    AssignPropertyValue(ref _Origin, "Origin", value);
            }

            get
            {
                return _Origin;
            }
        }

        /// <summary>
        /// AccountTransaction owning Account.
        /// </summary>
        public IAccount Owner
        {
            private set
            {
                AssignPropertyValue(ref _Owner, "Owner", value);
            }

            get
            {
                return _Owner;
            }
        }

        /// <summary>
        /// Event to be raised when a public class propety value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime ResolvedOn
        {
            private set
            {
                AssignPropertyValue(ref _ResolvedOn, "ResolvedOn", value);
            }

            get
            {
                return _ResolvedOn;
            }
        }

        /// <summary>
        /// DateTime for AccountTransaction instance state review.
        /// </summary>
        public DateTime ReviewDate
        {
            set
            {
                AssignPropertyValue(ref _ReviewDate, "ReviewDate", value);
            }

            get
            {
                return _ReviewDate;
            }
        }
        
        /// <summary>
        /// AccountTransaction state (i.e. Outstanding or Resolved).
        /// </summary>
        public TransactionState State
        {
            set
            {
                switch (value)
                {
                    case TransactionState.Outstanding:
                        ResolvedOn = new DateTime(0, 0, 0);
                        break;

                    case TransactionState.Resolved:
                        ResolvedOn = DateTime.Now;
                        break;
                }

                AssignPropertyValue(ref _State, "State", value);
            }

            get
            {
                return _State;
            }
        }

        /// <summary>
        /// AccountTransaction type (i.e. Credit or Debit).
        /// </summary>
        public TransactionType Type
        {
            private set
            {
                switch (value)
                {
                    case TransactionType.Credit:
                        this.Destination = this.Owner;
                        break;

                    case TransactionType.Debit:
                        this.Origin = this.Owner;
                        break;
                }

                AssignPropertyValue(ref _Type, "TransactionType", value);
            }

            get
            {
                return _Type;
            }
        }
    }
}
