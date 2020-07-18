using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Models
{
    public class Turma
    {
        public Guid Id { get; set; }
        public string  Descricao { get; set; }
        public DateTime DataIniciio { get; set; }
        public Turma() { }

        public Turma(Guid id, string descricao, DateTime dataIniciio)
        {
            Id = id;
            Descricao = descricao;
            DataIniciio = dataIniciio;
        }

        #region Professor
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        #endregion

        #region Aluno
        public List<TurmaAluno> Alunos { get; set; }
        #endregion
    }
}
