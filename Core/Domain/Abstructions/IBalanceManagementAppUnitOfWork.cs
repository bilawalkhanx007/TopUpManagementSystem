using System.Data;

namespace Domain.Abstructions
{
    /// <summary>
    /// All Repositories register into UnitOfWork
    /// </summary>
    public interface IBalanceManagementAppUnitOfWork
    {
        IUserBalanceRepository UserBalanceRepository { get; }
        IBalanceTransactionRepository BalanceTransactionRepository { get; }
        IUserRepository UserRepository { get; }
        IUserTopUpTrasactionRepository UserTopUpTrasactionRepository { get; }
        IBeneficiaryBalanceRepository BeneficiaryBalanceRepository { get; }

        Task<int> ApplySaveChanges(CancellationToken cancellationToken);

        IDbTransaction BeginTransaction();

    }
}
