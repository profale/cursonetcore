using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Models
{
    public class Aluno
    {
        //prop + 2x[tab]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        //ctor + 2x[tab]
        public Aluno()
        {

        }

        //sobrecarga (overloading) de construtores
        public Aluno(Guid id, string nome, string matricula, string cpf, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        #region Turmas
        public List<TurmaAluno> Turmas { get; set; }
        #endregion
    }
}
