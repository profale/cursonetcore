using AutoMapper;
using FluentValidation;
using MediatR;
using Projeto.Application.Commands.Alunos;
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
    public class AlunoRequestHandler : 
        IRequestHandler<CreateAlunoCommand>, 
        IRequestHandler<UpdateAlunoCommand>,
        IRequestHandler<DeleteAlunoCommand>,
        IDisposable
    {
        //atributos
        private readonly IMediator mediator;
        private readonly IAlunoDomainService alunoDomainService;
        private readonly IMapper _mapper;
        public AlunoRequestHandler(IMediator mediator, IAlunoDomainService alunoDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.alunoDomainService = alunoDomainService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAlunoCommand command, CancellationToken cancellationToken)
        {
            //Usar o Mapper para fazer o De x Para
            //var aluno = new Aluno
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = request.Nome,
            //    Matricula = request.Matricula,
            //    Cpf = request.Cpf,
            //    DataNascimento = request.DataNascimento
            //};

            var aluno = _mapper.Map<Aluno>(command);
            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);
            
            alunoDomainService.Add(aluno);

            await mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Criar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateAlunoCommand command, CancellationToken cancellationToken)
        {
            //Usar o Mapper para fazer o De x Para
            //var aluno = new Aluno
            //{
            //    Id = Guid.Parse(request.Id),
            //    Nome = request.Nome,
            //    DataNascimento = request.DataNascimento
            //};
            var aluno = _mapper.Map<Aluno>(command);
            var validation = new AlunoValidation().Validate(aluno);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            alunoDomainService.Update(aluno);

            await mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Atualizar
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteAlunoCommand command, CancellationToken cancellationToken)
        {
            //Usar o Mapper para fazer o De x Para
            //var aluno = new Aluno
            //{
            //    Id = Guid.Parse(request.Id),
            //};
            //var validation = new AlunoValidation().Validate(aluno);
            //if (!validation.IsValid)
            //    throw new ValidationException(validation.Errors);
            var aluno = _mapper.Map<Aluno>(command);
            alunoDomainService.Remove(aluno);

            await mediator.Publish(new AlunoNotification
            {
                Aluno = aluno,
                Action = ActionNotification.Excluir
            });

            return Unit.Value;
        }

        public void Dispose()
        {
            alunoDomainService.Dispose();
        }
    }
}
