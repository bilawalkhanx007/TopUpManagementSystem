using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstructions
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IBeneficiaryRepository : IRepository<Beneficiary>
    {
        /// <summary>
        /// This Method is use to Get All User Beneficiaries
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isActive"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Beneficiary>> GetUserBeneficiaries(long userId, bool isActive, CancellationToken cancellationToken = default);
    }
}
