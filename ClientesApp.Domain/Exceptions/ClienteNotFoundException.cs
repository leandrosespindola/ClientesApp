namespace ClientesApp.Domain.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException(Guid clienteId)
            : base ($"Cliente com o ID {clienteId} não encontrado.")
        {            
        }
    }
}
