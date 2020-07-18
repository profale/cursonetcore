using MediatR;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Notifications
{
    public class ProfessorNotification : INotification
    {
        public Professor Professor { get; set; }
        public ActionNotification Action { get; set; } //ação Incluir, Atualizar e Deletar
    }
}
