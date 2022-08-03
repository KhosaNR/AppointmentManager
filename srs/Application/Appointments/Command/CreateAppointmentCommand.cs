using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Command
{
    internal class CreateAppointmentCommand : ICreateAppointmentCommand
    {
        //This does not look right.
        IAppointmentRepository AppointmentRepository;
        IAppointmentPersonRepository PersonRepository;
        IUnitOfWork UnitOfWork;

        public CreateAppointmentCommand(IAppointmentRepository appointmentRepository, IAppointmentPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            AppointmentRepository = appointmentRepository;
            PersonRepository = personRepository;
            UnitOfWork = unitOfWork;
        }

        public void Execute(Appointment appointment)
        {
            //Use personGuid to get related person, if person does not exist then return
            //If person exists then add new appoinment to person and save changed??
            //Insert/AddAsync
            //SaveChanges
        }
    }
}
