using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// UserTopUpTrasaction Collection
    /// </summary>
    public class UserTopUpTrasaction : EntityBase
    {
        public decimal Amount { get; set; }

        public int TopUpChargeAmount { get; set; }

        public long UserID { get; set; }

        public long TopUpOptionID { get; set; }
        public long BeneficiaryID { get; set; }

    }
}
