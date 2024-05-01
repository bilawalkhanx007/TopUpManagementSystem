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
    public class DebitCreditRequestViewModel
    {
        public long UserId { get; set; }
        public long BeneficiaryId { get; set; }
        public decimal Amount { get; set; }
        public int TransactionCharges { get; set; }
    }
}
