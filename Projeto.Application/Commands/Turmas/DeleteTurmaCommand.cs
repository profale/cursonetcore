using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Commands.Turmas
{
    public class DeleteTurmaCommand : IRequest
    {
        public string Id { get; set; }
    }
}
