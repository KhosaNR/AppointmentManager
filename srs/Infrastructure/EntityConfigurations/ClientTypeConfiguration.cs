using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations;
public class ClientTypeConfiguration :  IEntityTypeConfiguration<Domain.Entities.Client>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Client> apointmentPersonConfiguration)
    {
        //apointmentPersonConfiguration.ToTable("Client");
        apointmentPersonConfiguration.HasMany(x => x.Slots);
        var navigation =
              apointmentPersonConfiguration.Metadata.FindNavigation(nameof(Domain.Entities.Client.Slots));

        //EF access the Appointment collection property through its backing field
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}

