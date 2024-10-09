using ClientesApp.Application.Events;

namespace ClientesApp.Application.Interfaces.Messages
{
    public interface IMessagePublisher
    {
        Task Send(ClienteCadastradoEvent @event);
    }
}
