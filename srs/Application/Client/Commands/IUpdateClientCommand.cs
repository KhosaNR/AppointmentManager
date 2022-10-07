using Application.DTOs;
using Domain.General.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients.Commands
{
    public interface IUpdateClientCommand
    {
        Task<Results> Execute(ClientDto clientDto);
    }
}
