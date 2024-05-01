using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstructions
{
    public interface IBalanceManangementAppService
    {
        /// <summary>
        /// This Method Use to Get Current Balance of User
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        Task<GetUserBalanceResponse> GetBalance(GetUserBalanceRequestViewModel getUserBalanceViewModel);

        /// <summary>
        /// This Method to perform Debit and Credit transaction
        /// </summary>
        /// <param name="debitCreditRequestViewModel"></param>
        /// <returns></returns>
        Task<ResponseViewModel> DebitCreditExecution(DebitCreditRequestViewModel debitCreditRequestViewModel);
    }
}
