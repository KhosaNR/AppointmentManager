using Application.DTOs;
using AutoMapper;

namespace BlazorserverApp.Data.Mapping
{
    internal class ClientModelProfile: Profile
    {
        public ClientModelProfile()
        {
            CreateMap<ClientModel, ClientDto>().ReverseMap();
        }
    }
}
