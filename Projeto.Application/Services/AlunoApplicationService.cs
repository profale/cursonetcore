using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Alunos;
using Projeto.Application.Interfaces;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Services
{
    public class AlunoApplicationService : IAlunoApplicationService
    {
        //atributos
        private readonly IMediator mediator;
        private readonly IAlunoCaching _alunoCaching;

        //construtor para injecao de dependencia
        public AlunoApplicationService(IMediator mediator, IAlunoCaching alunoCaching)
        {
            this.mediator = mediator;
            _alunoCaching = alunoCaching;
        }

        public void Add(CreateAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Update(UpdateAlunoCommand command)
        {
            mediator.Send(command);
        }

        public void Remove(DeleteAlunoCommand command)
        {
            mediator.Send(command);
        }
        public List<AlunoDTO> GetAll()
        {
            return _alunoCaching.GetAll();
        }

        public AlunoDTO GetById(string id)
        {
            return _alunoCaching.GetById(Guid.Parse(id));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
