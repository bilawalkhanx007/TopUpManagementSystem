using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstructions
{
    /// <summary>
    /// All Repositories register into UnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBeneficiaryRepository BeneficiaryRepository { get; }
        ITopUpOptionRepository TopUpOptionRepository { get; }
        IUserTopUpTrasactionRepository UserTopUpTrasactionRepository { get; }
        Task<int> ApplySaveChanges(CancellationToken cancellationToken = default);
        IDbTransaction BeginTransaction();

    }
}
