using Domain.Entities;
using Domain.Enums;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations;

public class AppointmentTypeConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> appointmentConfiguration)
    {
        //appointmentConfiguration.ToTable("Appointment");

        appointmentConfiguration.HasKey(o => o.Id);

        appointmentConfiguration
            .Property<DateTime?>("AppointmentDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("AppointmentDate")
            .IsRequired();

        appointmentConfiguration
            .Property<Guid>("Person_Id")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Person_Id")
            .IsRequired();

        appointmentConfiguration
            .Property<AppointmentStatus>("Status")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Status")
            .IsRequired();

        appointmentConfiguration
            .Property<string>("CancellationReason")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CancellationReason")
            .IsRequired(false);
    }
}

