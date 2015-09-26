using System;

namespace Omega.Model.Interface
{
    internal interface IAccount
    {
        /// <summary>
        /// Account identification number.
        /// </summary>
        UInt32 AccountNumber { get; }

        /// <summary>
        /// Account name.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Account location (i.e. bank and branch).
        /// </summary>
        String SortCode { get; }
    }
}
