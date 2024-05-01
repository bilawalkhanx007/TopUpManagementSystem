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
    public class ResponseViewModel
    {
        public string Message { get; set; }
        public bool IsSucess { get; set; } = false;
    }
}
