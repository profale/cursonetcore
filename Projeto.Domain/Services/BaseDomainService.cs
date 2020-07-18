using Projeto.Domain.Interfaces.IServices;
using Projeto.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        //atributo - DIP (Inversao de Dependencia)
        private readonly IBaseRepository<TEntity> repository;

        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public virtual List<TEntity> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return repository.GetById(id);
        }

        //public virtual void Dispose()
        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
