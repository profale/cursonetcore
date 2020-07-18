using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributo -> DIP (Inversao de Dependecia)
        private readonly SqlContext _context;

        //atributo para armazenar as transacoes criadas
        private IDbContextTransaction transaction;

        //construtor para injecao de dependencia
        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public IAlunoRepository AlunoRepository => new AlunoRepository(_context);

        public IProfessorRepository ProfessorRepository => new ProfessorRepository(_context);

        public ITurmaRepository TurmaRepository => new TurmaRepository(_context);

        public ITurmaAlunoRepository TurmaAlunoRepository => new TurmaAlunoRepository(_context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
