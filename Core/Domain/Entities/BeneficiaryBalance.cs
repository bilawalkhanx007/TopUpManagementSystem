using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// BeneficiaryBalance Collection
    /// </summary>
    public class BeneficiaryBalance : EntityBase
    {
        public long BeneficiaryId { get; set; }
        public long RoleId { get; set; }
        public decimal Balance { get; set; }
    }
}
