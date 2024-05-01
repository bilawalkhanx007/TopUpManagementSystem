using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessPersistence.FluentMapping
{
    /// <summary>
    /// FluentAPI Mapping
    /// </summary>
    public class UserTopUpTrasactionMap : EntityBaseConfiguration<UserTopUpTrasaction>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserTopUpTrasaction> builder)
        {
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.TopUpChargeAmount).IsRequired();
            builder.Property(p => p.TopUpOptionID).IsRequired();
            builder.Property(p => p.UserID).IsRequired();

            builder.ToTable("UserTopUpTrasaction", "dbo");
        }
    }
}
