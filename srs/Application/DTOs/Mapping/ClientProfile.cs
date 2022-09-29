using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Mapping
{
    internal class ClientProfile: Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();
        }
    }
}
