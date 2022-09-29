using Domain.Entities;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Slots.Commands
{
    internal interface ICreateSlotCommand
    {
        void Execute(SlotDto slot);
    }
}
