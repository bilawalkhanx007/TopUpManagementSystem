using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence
{

    /// <summary>
    ///  Base configuration for Mapping, Entity mapping class Must inherit this.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
          where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.ModifiedAt).IsRequired(false);
            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
