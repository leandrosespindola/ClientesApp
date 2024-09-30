using ClientesApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator() 
        { 
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O Id é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("O Id não pode ser igual ao valor padrão.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .Length(8,150).WithMessage("O nome deve ter de 8 a 150 caracteres.");
            
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ter um endereço de email válido"); ;
            
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O Id é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve ter 11 dígitos.");
        }
    }
}
