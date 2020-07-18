using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.DTOs
{
    public class TurmaDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataIniciio { get; set; }


        #region Relacionamentos
        public ProfessorDTO Professor { get; set; }
        public List<AlunoDTO>Alunos { get; set; }
        #endregion
    }
}
