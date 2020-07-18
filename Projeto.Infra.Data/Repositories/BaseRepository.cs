using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Interfaces.Repositories;
using Projeto.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        //Inversao de Dependencia - DIP
        protected readonly SqlContext _context;
        protected readonly DbSet<TEntity> dbSet; //CRUD

        public BaseRepository(SqlContext context) //IoC - Injeção de Dependência
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            dbSet.Add(obj);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            dbSet.Update(obj);
            _context.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            dbSet.Remove(obj);
            _context.SaveChanges();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual void Dispose()
        {
            //fechando o contexto
            _context.Dispose();
        }
    }
}
