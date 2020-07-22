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
using System.Threading.Tasks;

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

        public async Task Add(CreateProfessorCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task Update(UpdateProfessorCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task Remove(DeleteProfessorCommand command)
        {
           await _mediator.Send(command);
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
