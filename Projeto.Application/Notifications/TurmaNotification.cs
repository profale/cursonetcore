using MediatR;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Notifications
{
    public class TurmaNotification : INotification
    {
        public Turma Turma { get; set; }
        public ActionNotification Action { get; set; }
    }
   
}
