using AutoMapper;
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
        private readonly IMapper _mapper;


        public ProfessorRequestHandler(IMediator mediator, IProfessorDomainService professorDomainService, IMapper mapper)
        {
            _mediator = mediator;
            _professorDomainService = professorDomainService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProfessorCommand command, CancellationToken cancellationToken)
        {
            //var professor = new Professor
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = request.Nome,
            //    Email = request.Email
            //};

            var professor = _mapper.Map<Professor>(command);

            //validando o professor
            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid) 
                throw new ValidationException(validation.Errors);
                        
            _professorDomainService.Add(professor);

            await _mediator.Publish(new ProfessorNotification 
            {
                Professor = professor,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProfessorCommand command, CancellationToken cancellationToken)
        {
            //var professor = new Professor
            //{
            //    Id = Guid.Parse(request.Id),
            //    Nome = request.Nome,
            //    Email = request.Email
            //};

            var professor = _mapper.Map<Professor>(command);

            //validando o professor
            var validation = new ProfessorValidation().Validate(professor);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            _professorDomainService.Update(professor);

           await _mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProfessorCommand command, CancellationToken cancellationToken)
        {
            //var professor = new Professor
            //{
            //    Id = Guid.Parse(request.Id)
            //};
            var professor = _mapper.Map<Professor>(command);

            _professorDomainService.Remove(professor);

            await _mediator.Publish(new ProfessorNotification
            {
                Professor = professor,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            _professorDomainService.Dispose();
        }
    }
}
