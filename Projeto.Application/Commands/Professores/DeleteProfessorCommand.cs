using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Commands.Professores
{
    public class DeleteProfessorCommand : IRequest
    {
        public string Id { get; set; }
    }
}
