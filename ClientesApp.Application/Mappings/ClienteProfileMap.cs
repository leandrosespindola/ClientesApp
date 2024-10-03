using AutoMapper;
using ClientesApp.Application.DTO;
using ClientesApp.Domain.Entities;

namespace ClientesApp.Application.Mappings
{
    public class ClienteProfileMap : Profile
    {
        public ClienteProfileMap()
        {
            CreateMap<ClienteRequestDto, Cliente>();
            CreateMap<Cliente, ClienteResponseDto>();
        }
    }
}
