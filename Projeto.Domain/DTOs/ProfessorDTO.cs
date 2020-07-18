using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.DTOs
{
    public class ProfessorDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
