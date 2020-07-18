using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Turmas;
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
    public class TurmaApplicationService : ITurmaApplicationService
    {
        private readonly IMediator _mediator;
        private readonly ITurmaCaching _turmaCaching;

        public TurmaApplicationService(IMediator mediator, ITurmaCaching turmaCaching)
        {
            _mediator = mediator;
            _turmaCaching = turmaCaching;
        }

        public void Add(CreateTurmaCommand command)
        {
            _mediator.Send(command);
        }

        public void Update(UpdateTurmaCommand command)
        {
            _mediator.Send(command);
        }

        public void Remove(DeleteTurmaCommand command)
        {
            _mediator.Send(command);
        }

        public List<TurmaDTO> GetAll()
        {
            return _turmaCaching.GetAll();
        }

        public TurmaDTO GetById(string id)
        {
            return _turmaCaching.GetById(Guid.Parse(id));
        }
    }
}
