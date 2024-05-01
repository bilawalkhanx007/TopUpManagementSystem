using DataAcessPersistence.Context;
using Domain.Abstructions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class BeneficiaryRepository : Repository<Beneficiary>, IBeneficiaryRepository
    {
        private readonly ApplicationDbContext context;
        public BeneficiaryRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }


        /// <summary>
        /// This Method is use to Get All User Beneficiaries
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isActive"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Beneficiary>> GetUserBeneficiaries(long userId, bool isActive, CancellationToken cancellationToken = default)
        {
            var userBeneficiaries = await context.Beneficiary.Where(x => x.UserID == userId && x.IsActive == isActive)
                                                             .ToListAsync(cancellationToken);
            if (userBeneficiaries != null && userBeneficiaries.Count > 0)
                return userBeneficiaries;
            else
                return new List<Beneficiary>();
        }


    }
}
