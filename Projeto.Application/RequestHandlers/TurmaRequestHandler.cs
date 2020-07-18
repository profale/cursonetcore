using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Turmas;
using Projeto.Application.Notifications;
using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Models;
using Projeto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.RequestHandlers
{
    public class TurmaRequestHandler :
        IRequestHandler<CreateTurmaCommand>,
        IRequestHandler<UpdateTurmaCommand>,
        IRequestHandler<DeleteTurmaCommand>,
        IDisposable
    {
        private readonly IMediator _mediator;
        private readonly ITurmaDomainService _turmaDomainService;
        public TurmaRequestHandler(IMediator mediator, ITurmaDomainService turmaDomainService)
        {
            _mediator = mediator;
            _turmaDomainService = turmaDomainService;
        }

        public Task<Unit> Handle(CreateTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = new Turma
            {
                Id = Guid.NewGuid(),
                DataIniciio = request.DataInicio,
                Descricao = request.Descricao,
                ProfessorId = Guid.Parse(request.ProfessorId)
            };

            //validando o professor
            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _turmaDomainService.Add(turma);

            _mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = new Turma
            {
                Id = Guid.Parse(request.Id),
                DataIniciio = request.DataInicio,
                Descricao = request.Descricao,
                ProfessorId = Guid.Parse(request.ProfessorId)
            };

            //validando o professor
            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _turmaDomainService.Update(turma);

            _mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteTurmaCommand request, CancellationToken cancellationToken)
        {
            var turma = new Turma
            {
                Id = Guid.Parse(request.Id)
            };

            _turmaDomainService.Remove(turma);

            _mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            _turmaDomainService.Dispose();
        }
    }
}
