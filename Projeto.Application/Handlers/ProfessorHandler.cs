using AutoMapper;
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
    //classe para escutar o Notification e conversa diretamente com a base de cache
    public class ProfessorHandler : INotificationHandler<ProfessorNotification>
    {
        //atributo
        private readonly IProfessorCaching _professorCaching;
        private readonly IMapper _mapper;

        //construtor para injecao de dependencia
        public ProfessorHandler(IProfessorCaching professorCaching, IMapper mapper)
        {
            _professorCaching = professorCaching;
            _mapper = mapper;
        }

        //orquestra quando fará o CUD no cache
        public Task Handle(ProfessorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                //var professorDTO = new ProfessorDTO
                //{
                //    Id = notification.Professor.Id,
                //    Nome = notification.Professor.Nome,
                //    Email = notification.Professor.Email
                //};
                var professorDTO = _mapper.Map<ProfessorDTO>(notification.Professor);

                //executar a açao
                switch (notification.Action)
                {
                    case ActionNotification.Criar:
                        _professorCaching.Add(professorDTO);
                        break;
                    case ActionNotification.Atualizar:
                        _professorCaching.Update(professorDTO);
                        break;
                    case ActionNotification.Excluir:
                        _professorCaching.Remove(professorDTO);
                        break;
                }
            });
        }
    }
}
