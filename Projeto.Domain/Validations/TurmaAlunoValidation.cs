﻿using FluentValidation;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Validations
{
    public class TurmaAlunoValidation : AbstractValidator<TurmaAluno>
    {
        public TurmaAlunoValidation()
        {

        }
    }
}
