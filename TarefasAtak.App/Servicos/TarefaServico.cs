using System.Net.Http.Json;
using TarefasAtak.App.Models;
using TarefasAtak.App.Commands;
using TarefasAtak.Core.Context.Entities;
using AutoMapper;

namespace TarefasAtak.App.Servicos
{
    public class TarefaServico(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        public async Task CreateAsync(TarefaViewModel tarefa)
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            await client.PostAsJsonAsync("Tarefa", tarefa);
        }

        public async Task<List<TarefaViewModel>> GetAsync()
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            var result = await client.GetFromJsonAsync<CommandResult<List<Tarefa>>>("Tarefa") ?? new CommandResult<List<Tarefa>>(false,"Falha no retorno da API",null);

            var tarefas = mapper.Map<List<TarefaViewModel>>(result.Data);

            return tarefas;
        }
    }
}
