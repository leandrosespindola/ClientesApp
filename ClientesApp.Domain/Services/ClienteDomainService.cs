using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using FluentValidation;

namespace ClientesApp.Domain.Services
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IValidator<Cliente> _validator;

        public ClienteDomainService(IClienteRepository clienteRepository, IValidator<Cliente> validator)
        {
            _clienteRepository = clienteRepository;
            _validator = validator;
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            var validationResult = await _validator.ValidateAsync(cliente);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _clienteRepository.AddAsync(cliente);
            return cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            var validationResult = await _validator.ValidateAsync(cliente);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _clienteRepository.UpdateAsync(cliente);
            return cliente;
        }

        public async Task<Cliente> DeleteAsync(Guid id)
        {
            await _clienteRepository.DeleteAsync(new Cliente { Id = id});
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<List<Cliente>> GetManyAsync(string nome)
        {
            throw new NotImplementedException();
            //return await _clienteRepository.GetManyAsync(nome);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
