using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Commands.Alunos
{
    public class DeleteAlunoCommand : IRequest
    {
        public string Id { get; set; }
    }
}
