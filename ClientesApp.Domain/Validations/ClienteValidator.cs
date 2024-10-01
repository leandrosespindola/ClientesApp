using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using FluentValidation;

namespace ClientesApp.Domain.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            ConfigureRules();
        }

        private void ConfigureRules()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O Id é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("O Id não pode ser igual ao valor padrão.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .Length(8, 150).WithMessage("O nome deve ter de 8 a 150 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ter um endereço de email válido.")
                .MustAsync(BeUniqueEmail).WithMessage("O email já está em uso."); 

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O Id é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve ter 11 dígitos.")
                .MustAsync(BeUniqueCPF).WithMessage("O CPF já está em uso.");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        => await _clienteRepository.VerifyExistsAsync(c => c.Email.Equals(email));        

        private async Task<bool> BeUniqueCPF(string cpf, CancellationToken cancellationToken)
        {
            return await _clienteRepository.VerifyExistsAsync(c => c.Cpf.Equals(cpf));
        }
    }
}
