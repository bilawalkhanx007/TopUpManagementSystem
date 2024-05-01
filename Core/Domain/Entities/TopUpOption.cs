using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// TopUpOption Collection
    /// </summary>
    public class TopUpOption : EntityBase
    {
        public int Amount { get; set; }

        public string Currency { get; set; }

    }
}
