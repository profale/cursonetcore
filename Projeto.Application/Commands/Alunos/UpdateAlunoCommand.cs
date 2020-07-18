using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Commands.Alunos
{
    public class UpdateAlunoCommand : IRequest
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
