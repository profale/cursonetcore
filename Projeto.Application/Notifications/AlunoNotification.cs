using MediatR;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Notifications
{
    /*
     * Classe que irá conter as informações do Aluno
     * quando uma açao for realizada pelo Meaditor
     */
    public class AlunoNotification : INotification //interface do mediator
    {
        public Aluno  Aluno { get; set; }
        public ActionNotification Action { get; set; }
    }
}
