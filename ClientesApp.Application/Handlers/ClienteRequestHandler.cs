using ClientesApp.Application.Commands;
using ClientesApp.Application.Interfaces.Logs;
using MediatR;

namespace ClientesApp.Application.Handlers
{
    public class ClienteRequestHandler : IRequestHandler<ClienteCommand>
    {
        private readonly ILogClienteDataStore _logClienteDataStore;

        public ClienteRequestHandler(ILogClienteDataStore logClienteDataStore)
        {
            _logClienteDataStore = logClienteDataStore;
        }

        public async Task Handle(ClienteCommand request, CancellationToken cancellationToken)
        {
            await _logClienteDataStore.AddAsync(request.LogCliente);
        }
    }
}
