using Domain.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services;
using Domain.Services;

namespace Application.Slot.Commands
{
    internal class CreateSlotCommand : ICreateSlotCommand
    {
        //This does not look right.
        ISlotRepository SlotRepository;
        IClientRepository ClientRepository;
        IClientService ClientService;

        IUnitOfWork UnitOfWork;

        public CreateSlotCommand(ISlotRepository slotRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork, IClientService clientService)
        {
            SlotRepository = slotRepository;
            ClientRepository = clientRepository;
            UnitOfWork = unitOfWork;
            ClientService = clientService;
        }

        public void Execute(SlotDto slot)
        {
            //ClientService.CreateUser(appointment.FirstName, appointment.LastName, appointment.PhoneNo);

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
