using Application.DTOs;
using Application.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppointmentPerson.Command
{
    internal class AppointmentPersonCommand: IAppointmentPersonCommand
    {
        public IUnitOfWork UnitOfWork;
        public IAppointmentPersonService AppointmentPersonService;

        public AppointmentPersonCommand(IUnitOfWork unitOfWork, IAppointmentPersonService appointmentPersonService)
        {
            UnitOfWork = unitOfWork;
            AppointmentPersonService = appointmentPersonService;
        }

        public async void SaveAppointmentPerson(Domain.Entities.AppointmentPerson appointmentPerson)
        {
            var id = appointmentPerson.ID;
            if (UnitOfWork.AppointmentPeople.GetById(id).Result == null) 
                //TBD: return person already exists 
                return;
            await UnitOfWork.AppointmentPeople.AddAsync(appointmentPerson);
        }

        public void UpdateAppointmentPerson(Domain.Entities.AppointmentPerson appointmentPerson)
        {
            //var id = appointmentPerson.ID;
            //if (AppointmentPersonRepository.GetById(id).Result == null)
            //    return;
            UnitOfWork.AppointmentPeople.Update(appointmentPerson);
            UnitOfWork.SaveChangesAsync();

        }
    }
}
