﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Application.Commands.Turmas
{
    public class UpdateTurmaCommand : IRequest
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public string ProfessorId { get; set; }

    }
}
