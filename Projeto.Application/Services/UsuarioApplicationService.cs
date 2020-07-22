using AutoMapper;
using FluentValidation;
using Projeto.Application.Commands.Usuarios;
using Projeto.Application.Interfaces;
using Projeto.CrossCutting.Security.Services;
using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;
        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService, TokenService tokenService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public void Add(CreateUsuarioCommand command)
        {
            //var usuario = new Usuario
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = command.Nome,
            //    Email = command.Email,
            //    Senha = command.Senha,
            //    DataCriacao = DateTime.Now
            //};
            var usuario = _mapper.Map<Usuario>(command);

            var validation = new UsuarioValidation().Validate(usuario);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _usuarioDomainService.Add(usuario);
        }

        public string Authenticate(AuthenticateUsuarioCommand command)
        {
            var usuario = _usuarioDomainService.Get(command.Email, command.Senha);

            if (usuario != null)
                return _tokenService.GenerateToken(usuario.Email);

            return null;
        }

        public void Dispose()
        {
            _usuarioDomainService.Dispose();
        }
    }
}
