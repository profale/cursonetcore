using MongoDB.Driver;
using Projeto.Domain.DTOs;
using Projeto.Infra.Caching.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Caching.Contexts
{
    public class MongoDBContext
    {
        //atributos
        private readonly MongoDBSettings mongoDBSettings;
        private IMongoDatabase mongoDatabase; //acessar a base de dados mongodb
        //injecao de dependencia
        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            this.mongoDBSettings = mongoDBSettings;
            Initialize();
        }

        //metodo para inicializar uma conexao com o banco de dados mongo
        private void Initialize()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(mongoDBSettings.ConnectingString));

            if (mongoDBSettings.IsSSL)
            {
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase(mongoDBSettings.DatabaseName);
        }

        //Configurar as Collections que serão criadas no MongoDB
        public IMongoCollection<AlunoDTO> Alunos { 
            get { return mongoDatabase.GetCollection<AlunoDTO>("Alunos"); } 
        }

        public IMongoCollection<ProfessorDTO> Professores {
            get { return mongoDatabase.GetCollection<ProfessorDTO>("Professores"); }
        }

        public IMongoCollection<TurmaDTO> Turmas
        {
            get { return mongoDatabase.GetCollection<TurmaDTO>("Turmas"); }
        }
    }
}
