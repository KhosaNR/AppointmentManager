using Application.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class AppointmentPersonService: IAppointmentPersonService, IUserService
    {
        IUnitOfWork uow;

        public AppointmentPersonService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        public void CreateAppointment(Guid appoinmentPerson_Id, DateTime appointmentTime)
        {
            var appointmentPerson = uow.AppointmentPeople.GetById(appoinmentPerson_Id).Result;
            if (appointmentPerson == null)
                throw new Exception("Appointment person not found");
            var appointment = new Appointment
            {
                AppointmentDate = appointmentTime,
                Status = Domain.Enums.AppointmentStatus.Booked,
                AppointmentPerson_Id = appoinmentPerson_Id,
            };
            appointmentPerson.AddAppointment(appointment);
            uow.SaveChangesAsync();
        }

        public void CreateUser(string firstName, string lastName, string PhoneNo)
        {
            var appointmentPerson = new Domain.Entities.AppointmentPerson
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNo = PhoneNo
            };
            uow.AppointmentPeople.AddAsync(appointmentPerson);
            uow.SaveChangesAsync();
        }
    }
}
