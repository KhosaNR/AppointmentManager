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

namespace Slot.Appointments.Command
{
    internal class CreateAppointmentCommand : ICreateAppointmentCommand
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

        public void Execute(SlotDto appointment)
        {
            //PersonService.CreateUser(appointment.FirstName, appointment.LastName, appointment.PhoneNo);

            //SlotDto slotDto = appointment.Slots.FirstOrDefault();
            //if (slotDto != null)
            //{
            //    //maybe a throw a message saying you cannot add an appointment without a slot?
            //    return;
            //}


            //Appointment slot = new()
            //{
            //    //Person_Id = person.ID,//?


            //};
            //Use personGuid to get related person, if person does not exist then return
            //If person exists then add new appoinment to person and save changed??
            //Insert/AddAsync
            //SaveChanges
        }
    }
}
