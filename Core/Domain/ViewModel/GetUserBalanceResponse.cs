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
    public class GetUserBalanceResponse
    {
        public string UserName { get; set; }
        public decimal Balance { get; set; }
    }

}
