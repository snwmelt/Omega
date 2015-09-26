using Omega.Model.Interface;
using System;

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
        /// <param name="SortCode">Account Sort Code: Foramt XX-XX-XX</param>
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
        /// Account location (i.e. bank and branch) in the format XX-XX-XX.
        /// </summary>
        public String SortCode
        {
            private set
            {
                _SortCode = value;
            }

            get
            {
                return _SortCode;
            }
        }
    }
}
