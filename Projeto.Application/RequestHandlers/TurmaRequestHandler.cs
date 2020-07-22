using AutoMapper;
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
        private readonly IMapper _mapper;
        public TurmaRequestHandler(IMediator mediator, ITurmaDomainService turmaDomainService, IMapper mapper)
        {
            _mediator = mediator;
            _turmaDomainService = turmaDomainService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateTurmaCommand command, CancellationToken cancellationToken)
        {
            //var turma = new Turma
            //{
            //    Id = Guid.NewGuid(),
            //    DataIniciio = request.DataInicio,
            //    Descricao = request.Descricao,
            //    ProfessorId = Guid.Parse(request.ProfessorId)
            //};
            var turma = _mapper.Map<Turma>(command);

            //validando o professor
            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _turmaDomainService.Add(turma);

           await _mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateTurmaCommand command, CancellationToken cancellationToken)
        {
            //var turma = new Turma
            //{
            //    Id = Guid.Parse(request.Id),
            //    DataIniciio = request.DataInicio,
            //    Descricao = request.Descricao,
            //    ProfessorId = Guid.Parse(request.ProfessorId)
            //};

            var turma = _mapper.Map<Turma>(command);

            //validando o professor
            var validation = new TurmaValidation().Validate(turma);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _turmaDomainService.Update(turma);

            await _mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteTurmaCommand command, CancellationToken cancellationToken)
        {
            //var turma = new Turma
            //{
            //    Id = Guid.Parse(request.Id)
            //};
            var turma = _mapper.Map<Turma>(command);

            _turmaDomainService.Remove(turma);

            await _mediator.Publish(new TurmaNotification
            {
                Turma = turma,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            _turmaDomainService.Dispose();
        }
    }
}
