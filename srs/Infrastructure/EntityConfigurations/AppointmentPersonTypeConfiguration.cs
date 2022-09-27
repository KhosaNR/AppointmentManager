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
public class AppointmentPersonTypeConfiguration :  IEntityTypeConfiguration<AppointmentPerson>
{
    public void Configure(EntityTypeBuilder<AppointmentPerson> apointmentPersonConfiguration)
    {
        //apointmentPersonConfiguration.ToTable("AppointmentPerson");
        apointmentPersonConfiguration.HasMany(x => x.Appointments);
        var navigation =
              apointmentPersonConfiguration.Metadata.FindNavigation(nameof(AppointmentPerson.Appointments));

        //EF access the Appointment collection property through its backing field
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}

