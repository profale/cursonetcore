using MediatR;
using Projeto.Application.Notifications;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto.Application.Handlers
{
    public class TurmaHandler : INotificationHandler<TurmaNotification>
    {
        //atributo
        private readonly ITurmaCaching _turmaCaching;
        public TurmaHandler(ITurmaCaching turmaCaching)
        {
            _turmaCaching = turmaCaching;
        }

        public Task Handle(TurmaNotification notification, CancellationToken cancellationToken)
        {
            //executando a thread
            return Task.Run(() =>
            {
                var turmaDTO = new TurmaDTO
                {
                    Id = notification.Turma.Id,
                    DataIniciio = notification.Turma.DataIniciio,
                    Descricao = notification.Turma.Descricao
                    //TODO => Gravar os vinculos de Professor e Aluno
                };

                //executar a acao
                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        _turmaCaching.Add(turmaDTO);
                        break;
                    case ActionNotification.Atualizar:
                        _turmaCaching.Update(turmaDTO);
                        break;
                    case ActionNotification.Excluir:
                        _turmaCaching.Remove(turmaDTO);
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
