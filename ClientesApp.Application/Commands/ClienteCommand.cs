using ClientesApp.Application.Models;
using MediatR;

namespace ClientesApp.Application.Commands
{
    public class ClienteCommand : IRequest
    {
        public LogClienteModel? LogCliente { get; set; }

    }
}
