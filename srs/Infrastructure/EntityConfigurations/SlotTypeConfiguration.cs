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

public class SlotTypeConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> slotConfiguration)
    {
        //appointmentConfiguration.ToTable("Appointment");

        slotConfiguration.HasKey(o => o.Id);

        slotConfiguration
            .Property<DateTime?>("AppointmentDate")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("AppointmentDate")
            .IsRequired();

        //slotConfiguration
        //    .Property<Guid>("Person_Id")
        //    .UsePropertyAccessMode(PropertyAccessMode.Field)
        //    .HasColumnName("Person_Id")
        //    .IsRequired();

        slotConfiguration
            .Property<AppointmentStatus>("Status")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Status")
            .IsRequired();

        slotConfiguration
            .Property<string>("CancellationReason")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CancellationReason")
            .IsRequired(false);
    }
}

