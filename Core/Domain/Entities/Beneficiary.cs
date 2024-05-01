using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Beneficiary Collection
    /// </summary>
    public class Beneficiary : EntityBase
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="nickName"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="userID"></param>
        /// <param name="isActive"></param>
        public Beneficiary(string nickName, string mobileNumber, long userID, bool isActive)
        {
            NickName = nickName;
            MobileNumber = mobileNumber;
            UserID = userID;
            IsActive = isActive;
        }
        public string NickName { get; set; }

        public string MobileNumber { get; set; }

        public long UserID { get; set; }

        public bool IsActive { get; set; }

    }
}
