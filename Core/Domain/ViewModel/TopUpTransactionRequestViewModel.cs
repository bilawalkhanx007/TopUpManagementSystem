using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    /// <summary>
    /// View Model Class
    /// </summary>
    public class TopUpTransactionRequestViewModel
    {
        public long UserId { get; set; }

        public long BeneficiaryID { get; set; }

        public int Amount { get; set; }

        public string TopUpChargeAmount { get; set; }

    }
}
