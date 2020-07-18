using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Context
{
    //Regra 1: Herdar DBCOntext
    public class SqlContext : DbContext
    {
        //Regra 2: Construtor para receber as configurações
        //para acesso ao banco de dados do SqlServer
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        //Regra 3: Declara DBSet(CRUD) para cada modelo de dados
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaAluno> TurmasAlunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        //Regra 4: Sobrescrita (OVERRIDE) do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar as classes de mapeamento
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaAlunoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            //adicionar indices na tabela
            //modelBuilder.Entity<Aluno>().HasIndex(a => a.Cpf).IsUnique();
            modelBuilder.Entity<Aluno>(entity => {
                entity.HasIndex(a => a.Cpf).IsUnique();
                entity.HasIndex(a => a.Matricula).IsUnique();
            });

            modelBuilder.Entity<Professor>(entity => {
                entity.HasIndex(a => a.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
