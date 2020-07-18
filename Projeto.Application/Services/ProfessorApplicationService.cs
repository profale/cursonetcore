using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Professores;
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
    public class ProfessorApplicationService : IProfessorApplicationService
    {
        //atributo
        private readonly IMediator _mediator;
        private readonly IProfessorCaching _professorCaching;
        public ProfessorApplicationService(IMediator mediator, IProfessorCaching professorCaching)
        {
            _mediator = mediator;
            _professorCaching = professorCaching;
        }

        public void Add(CreateProfessorCommand command)
        {
            _mediator.Send(command);
        }

        public void Update(UpdateProfessorCommand command)
        {
            _mediator.Send(command);
        }

        public void Remove(DeleteProfessorCommand command)
        {
            _mediator.Send(command);
        }

        public List<ProfessorDTO> GetAll()
        {
            return _professorCaching.GetAll();
        }

        public ProfessorDTO GetById(string id)
        {
            return _professorCaching.GetById(Guid.Parse(id));
        }
    }
}
