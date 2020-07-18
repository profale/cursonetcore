using MongoDB.Driver;
using Projeto.Domain.DTOs;
using Projeto.Domain.Interfaces.Caching;
using Projeto.Infra.Caching.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Caching.Persistence
{
    public class ProfessorCaching : IProfessorCaching
    {
        private readonly MongoDBContext mongoDBContext;

        public ProfessorCaching(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }
        public void Add(ProfessorDTO obj)
        {
            mongoDBContext.Professores.InsertOne(obj);
        }

        public void Update(ProfessorDTO obj)
        {
            var filter = Builders<ProfessorDTO>.Filter.Eq(a => a.Id, obj.Id);
            mongoDBContext.Professores.ReplaceOne(filter, obj);
        }

        public void Remove(ProfessorDTO obj)
        {
            var filter = Builders<ProfessorDTO>.Filter.Eq(a => a.Id, obj.Id);
            mongoDBContext.Professores.DeleteOne(filter);
        }

        public List<ProfessorDTO> GetAll()
        {
            var filter = Builders<ProfessorDTO>.Filter.Where(a => true);
            return mongoDBContext.Professores.Find(filter).ToList();
        }

        public ProfessorDTO GetById(Guid id)
        {
            var filter = Builders<ProfessorDTO>.Filter.Eq(a => a.Id, id);
            return mongoDBContext.Professores.Find(filter).FirstOrDefault();
        }
    }
}
