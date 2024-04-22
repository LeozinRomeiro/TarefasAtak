using System.Net.Http.Json;
using TarefasAtak.App.Models;
using TarefasAtak.App.Commands;
using TarefasAtak.Core.Context.Entities;
using AutoMapper;

namespace TarefasAtak.App.Servicos
{
    public class TarefaServico(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        public async Task<CommandResult<TarefaViewModel>> CreateAsync(TarefaViewModel tarefaViewModel)
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            var tarefa = mapper.Map<Tarefa>(tarefaViewModel);
            var result = await client.PostAsJsonAsync("Tarefa", tarefa);
            if(result is null)
            {
                return new CommandResult<TarefaViewModel>(false, "Nenhuma resposta da API", null);
            }
            return await result.Content.ReadFromJsonAsync<CommandResult<TarefaViewModel>>();
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
