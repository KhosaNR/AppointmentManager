using Application.DTOs;
using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppointmentPerson.Command
{
    internal class AppointmentPersonCommand: IAppointmentPersonCommand
    {
        public IAppointmentPersonRepository AppointmentPersonRepository;
        public IUnitOfWork UnitOfWork;
        public AppointmentPersonCommand(IAppointmentPersonRepository appointmentReposistory, IUnitOfWork unitOfWork)
        {
            AppointmentPersonRepository = appointmentReposistory;
            UnitOfWork = unitOfWork;
        }

        public async void SaveAppointmentPerson(Domain.Entities.AppointmentPerson appointmentPerson)
        {
            var id = appointmentPerson.ID;
            if(AppointmentPersonRepository.GetById(id).Result == null) 
                //TBD: return person already exists 
                return;
            await AppointmentPersonRepository.AddAsync(appointmentPerson);
        }

        public void UpdateAppointmentPerson(Domain.Entities.AppointmentPerson appointmentPerson)
        {
            //var id = appointmentPerson.ID;
            //if (AppointmentPersonRepository.GetById(id).Result == null)
            //    return;
            AppointmentPersonRepository.Update(appointmentPerson);
            UnitOfWork.SaveAsync();

        }
    }
}
