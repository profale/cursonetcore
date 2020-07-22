using AutoMapper;
using MediatR;
using Projeto.Application.Notifications;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.Handlers
{
    public class AlunoHandler : INotificationHandler<AlunoNotification>
    {
        //atributo
        private readonly IAlunoCaching alunoCaching;
        private readonly IMapper _mapper;

        //construtor
        public AlunoHandler(IAlunoCaching alunoCaching, IMapper mapper)
        {
            this.alunoCaching = alunoCaching;
            _mapper = mapper;
        }

        //funciona de forma assincrona
        public Task Handle(AlunoNotification notification, CancellationToken cancellationToken)
        {
            //executando a thread
            return Task.Run(() =>
            {
                //var alunoDTO = new AlunoDTO
                //{
                //    Id = notification.Aluno.Id,
                //    Nome = notification.Aluno.Nome,
                //    Matricula = notification.Aluno.Matricula,
                //    Cpf = notification.Aluno.Cpf,
                //    DataNascimento = notification.Aluno.DataNascimento
                //};
                var alunoDTO = _mapper.Map<AlunoDTO>(notification.Aluno);

                //executar a acao
                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        alunoCaching.Add(alunoDTO);
                        break;
                    case ActionNotification.Atualizar:
                        alunoCaching.Update(alunoDTO);
                        break;
                    case ActionNotification.Excluir:
                        alunoCaching.Remove(alunoDTO);
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
