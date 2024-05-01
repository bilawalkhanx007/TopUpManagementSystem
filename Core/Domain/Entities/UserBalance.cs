using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// UserBalance Collection
    /// </summary>
    public class UserBalance : EntityBase
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public decimal Balance { get; set; }

        public User User { get; set; }
    }
    
}
