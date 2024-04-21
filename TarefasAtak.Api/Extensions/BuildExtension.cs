using System;
using TarefasAtak.Api.Mappers;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Repositories.Interfaces;
using TarefasAtak.Core.Context.Servicos;
using TarefasAtak.Core.Context.Servicos.Interfaces;
using TarefasAtak.Infra.Context.Repositories;
using TarefasAtak.Infra.Data;

namespace TarefasAtak.Api.Extensions
{
    public static class BuildExtension
    {
        public static void AddTarefaContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
            builder.Services.AddScoped<ITarefaServico, TarefaServico>();
            builder.Services.AddAutoMapper(typeof(DtoToModelMappingTarefa));

        }
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {

        }
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(x=>new AppDbContext<Tarefa>());
        }
    }
}
