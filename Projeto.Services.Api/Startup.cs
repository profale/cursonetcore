using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto.CrossCutting.IoC;
using Projeto.Services.Api.Configurations;

namespace Projeto.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Setup para configuração do Swagger
            SwaggerSetup.AddSwaggerSetup(services);
            
            //Setup para configuração do EF
            EntityFrameworkSetup.AddEntityFrameworkSetup(services, Configuration);

            //Setup para o JWT
            JwtBearerSetup.AddJwtBearerSetup(services, Configuration);

            //Setup para MongoDB
            MongoDbSetup.AddMongoDbSetup(services, Configuration);

            //Injecao de dependencia
            DependenxyInjection.Register(services);

            //Setup para MediatR
            MediatRSetup.AddMediatRSetup(services);

            //Setup para AutoMapper
            AutoMapperSetup.AddAutoMapperSetup(services);

            //Setup para o CORS
            CorsSetup.AddCorsSetup(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Setup para configuração do CORS
            CorsSetup.UseCorsSetup(app);

            JwtBearerSetup.UseJwtBearerSetup(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Setup para configuração do Swagger
            SwaggerSetup.UseSwaggerSetup(app);
            
        }
    }
}
