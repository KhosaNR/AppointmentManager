using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.EntityConfigurations;

public class BaseTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<BaseEntity> baseEntityConfiguration)
    {
        baseEntityConfiguration.HasKey(o => o.Id);
        /////////////////////////////////////////////////////
        baseEntityConfiguration
            .Property<DateTime>("UpdatedDate")
            //.UsePropertyAccessMode(PropertyAccessMode.Field)
            //.HasColumnName("CancellationReason")
            .IsRequired(false);

        baseEntityConfiguration
            .Property<DateTime>("CreatedDate")
            //.UsePropertyAccessMode(PropertyAccessMode.Field)
            //.HasColumnName("CancellationReason")
            .IsRequired(false);
    }
}

