using Domain.Entities;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Commands
{
    public interface ICreateClientCommand
    {
        void Execute(ClientDto Client);
    }
}
