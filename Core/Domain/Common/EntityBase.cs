using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    /// <summary>
    /// This Is Base Class For Every Entity
    /// </summary>
    public abstract class EntityBase : IEntityBase
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        public EntityBase()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// call this when update any record
        /// </summary>
        public void OnEntityModified()
        {
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
