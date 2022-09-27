using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations;

public class UserTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : User
{
    public void Configure(EntityTypeBuilder<User> userCOnfiguration)
    {
        userCOnfiguration
           .Property<string>("FirstName")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .IsRequired();

        userCOnfiguration
           .Property<string>("LastName")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .IsRequired();

        userCOnfiguration
           .Property<string>("PhoneNo")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .IsRequired();

    }
}
