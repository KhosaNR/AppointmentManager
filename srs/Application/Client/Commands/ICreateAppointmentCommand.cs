using Domain.Entities;
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.General.Result;

namespace Application.Clients.Commands
{
    public interface ICreateClientCommand
    {
        Task<Results> Execute(ClientDto clientDto);
    }
}
