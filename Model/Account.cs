using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Omega.Model
{
    internal class Account : INotifyPropertyChanged
    {
        #region Private_Variables

        private Decimal _Balance;

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

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
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

        // Need to figure this out \\
        public readonly List<Transaction> Debits;
        
        /// <summary>
        /// Event to be raised when a public class propety value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
