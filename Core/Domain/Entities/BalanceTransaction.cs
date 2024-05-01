using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// BalanceTransaction Collection
    /// </summary>
    public class BalanceTransaction : EntityBase
    {
        public long UserId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } // Debit or Credit
    }
}
