using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Projeto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Services.Api.Configurations
{
    public static class EntityFrameworkSetup
    {
        public static void AddEntityFrameworkSetup(this IServiceCollection services, IConfiguration configuration)
        {
            /*
             * Estamos configurando a classe SqlContext criada no Projeto Infra
             * passando para esta classe o caminho da connectionstring do BD
             */
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("CursoNetCore")));
        }
    }
}
