using FluentValidation;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        public UsuarioValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id do usuário é obrigatório");

            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo Nome não pode ser vazio")
                .Length(6,150).WithMessage("Nome deve ter de 6 a 150 caracteres");
            
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo E-mail não pode ser vazio")
                .EmailAddress().WithMessage("Email de e-mail inválido");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("O campo Senha não pode ser vazio")
                .Length(6, 20).WithMessage("A senha deve ter de 6 a 20 caracteres");

            RuleFor(u => u.DataCriacao)
                .NotEmpty().WithMessage("O campo Data de criação é obrigatório");
        }
    }
}
