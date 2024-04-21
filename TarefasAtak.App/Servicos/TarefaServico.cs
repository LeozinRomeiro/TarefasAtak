using System.Net.Http.Json;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.App.Commands;

namespace TarefasAtak.App.Servicos
{
    public class TarefaServico(IHttpClientFactory httpClientFactory)
    {
        public async Task CreateAsync(Tarefa tarefa)
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            await client.PostAsJsonAsync("Tarefa", tarefa);
        }

        public async Task<List<Tarefa>> GetAsync()
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            var result = await client.GetFromJsonAsync<CommandResult<List<Tarefa>>>("Tarefa") ?? new CommandResult<List<Tarefa>>(false,"Falha no retorno da API",null);
            return result.Data;
        }
    }
}
