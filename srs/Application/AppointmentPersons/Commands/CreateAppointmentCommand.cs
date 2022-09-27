using Domain.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Slot.DTOs;
using Slot.Services;
using Domain.Services;

namespace AppointmentPersons.Command
{
    public class CreateAppointmentCommand : ICreateAppointmentPersonCommand
    {
        //This does not look right.
        IAppointmentRepository AppointmentRepository;
        IAppointmentPersonRepository PersonRepository;
        IAppointmentPersonService PersonService;

        IUnitOfWork UnitOfWork;

        public CreateAppointmentCommand(IAppointmentRepository appointmentRepository, IAppointmentPersonRepository personRepository, IUnitOfWork unitOfWork, AppointmentPersonService appointmentPersonService)
        {
            AppointmentRepository = appointmentRepository;
            PersonRepository = personRepository;
            UnitOfWork = unitOfWork;
            PersonService = appointmentPersonService;
        }

        public CreateAppointmentCommand(IUnitOfWork unitOfWork, IAppointmentPersonService appointmentPersonService)
        {
            UnitOfWork = unitOfWork;
            PersonService = appointmentPersonService;
        }

        public void Execute(AppointmentPersonDto appointmentPerson)
        {
            AppointmentPerson person = new()
            {
                FirstName = appointmentPerson.FirstName,
                LastName = appointmentPerson.LastName,
                PhoneNo = appointmentPerson.PhoneNo,
            };

            SlotDto slotDto = appointmentPerson.Slots.FirstOrDefault();
            if (slotDto is null)
            {
                //maybe a throw a message saying you cannot add an appointment without a slot?
                return;
            }
            PersonService.CreateUser(appointmentPerson.FirstName, appointmentPerson.LastName, appointmentPerson.PhoneNo, slotDto.SlotDate);
        }
    }
}
