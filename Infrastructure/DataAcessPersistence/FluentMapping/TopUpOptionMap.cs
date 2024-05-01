using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessPersistence.FluentMapping
{
    /// <summary>
    /// FluentAPI Mapping
    /// </summary>
    public class TopUpOptionMap : EntityBaseConfiguration<TopUpOption>
    {
        public override void ConfigureEntity(EntityTypeBuilder<TopUpOption> builder)
        {
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Currency).IsRequired();

            builder.ToTable("TopUpOption", "dbo");
        }
    }
}
