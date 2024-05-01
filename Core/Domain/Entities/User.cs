using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// User Collection
    /// </summary>
    public class User : EntityBase
    {
        public string FirstNameEnglish { get; set; }

        public string LastNameEnglish { get; set; }

        public string? FirstNameArabic { get; set; }

        public string? LastNameArabic { get; set; }

        public string MobileNumber { get; set; }

        public int StatusID { get; set; }

        public bool IsActive { get; set; }
    }
}
