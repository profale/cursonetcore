using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Professores;
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
    public class ProfessorRequestHandler : 
        IRequestHandler<CreateProfessorCommand>,
        IRequestHandler<UpdateProfessorCommand>,
        IRequestHandler<DeleteProfessorCommand>,
        IDisposable
    {
        //atributo
        private readonly IMediator _mediator; //cache
        private readonly IProfessorDomainService _professorDomainService; //relacional
        

        public ProfessorRequestHandler(IMediator mediator, IProfessorDomainService professorDomainService)
        {
            _mediator = mediator;
            _professorDomainService = professorDomainService;
        }

        public Task<Unit> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Professor
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email
            };

            //validando o professor
            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid) 
                throw new ValidationException(validation.Errors);
                        
            _professorDomainService.Add(professor);

            _mediator.Publish(new ProfessorNotification 
            {
                Professor = professor,
                Action = ActionNotification.Criar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(UpdateProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Professor
            {
                Id = Guid.Parse(request.Id),
                Nome = request.Nome,
                Email = request.Email
            };

            //validando o professor
            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _professorDomainService.Update(professor);

            _mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Atualizar
            });

            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(DeleteProfessorCommand request, CancellationToken cancellationToken)
        {
            var professor = new Professor
            {
                Id = Guid.Parse(request.Id)
            };

            _professorDomainService.Remove(professor);

            _mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Excluir
            });

            return Task.FromResult(new Unit());
        }

        public void Dispose()
        {
            _professorDomainService.Dispose();
        }
    }
}
