using Omega.Model.Interface;
using System;
using System.Text.RegularExpressions;

namespace Omega.Model
{
    internal class ExternalAccount : IAccount
    {
        #region Private_Variables
        
        private String _SortCode;

        #endregion

        /// <summary>
        /// Constructor/
        /// </summary>
        /// <param name="AccountNumber">Account Number.</param>
        /// <param name="Name">Account Name.</param>
        /// <param name="SortCode">Account cort code in the foramt XX-XX-XX or XXXXXX</param>
        public ExternalAccount (UInt32 AccountNumber, String Name, String SortCode)
        {
            this.AccountNumber = AccountNumber;
            this.Name          = Name;
            this.SortCode      = SortCode;
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
        /// Account name.
        /// </summary>
        public String Name
        {
            private set;
            get;
        }

        /// <summary>
        /// Account location (i.e. bank and branch) in the format XX-XX-XX or XXXXXX.
        /// </summary>
        public String SortCode
        {
            private set
            {
                Regex Rx = new Regex(@"\b([0-9]{2})-?([0-9]{2})-?([0-9]{2})\b");

                if (!Rx.IsMatch(value))
                    throw new FormatException("Invalid Sort Code.");

                _SortCode = Rx.Replace(value, @"$1-$2-$3");
            }

            get
            {
                return _SortCode;
            }
        }
    }
}
