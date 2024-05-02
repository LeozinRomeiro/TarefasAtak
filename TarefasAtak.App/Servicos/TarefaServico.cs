using System.Net.Http.Json;
using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Entities;
using AutoMapper;

namespace TarefasAtak.App.Servicos
{
    public class TarefaServico(IHttpClientFactory httpClientFactory)
    {
        public async Task<CommandResult<TarefaCommand>> CreateAsync(TarefaCommand tarefaViewModel)
        {
            try
            {
                var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
                var result = await client.PostAsJsonAsync("Tarefa", tarefaViewModel);
                return await result.Content.ReadFromJsonAsync<CommandResult<TarefaCommand>>();
            }
            catch (Exception e)
            {
                return new CommandResult<TarefaCommand>(false, $"Nenhuma resposta da API - {e.Message}", null);
            }

        }

        public async Task<CommandResult<List<TarefaCommand>>> GetAsync()
        {
            try
            {
                var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
                var result = await client.GetFromJsonAsync<CommandResult<List<TarefaCommand>>>("Tarefa") ?? new CommandResult<List<TarefaCommand>>(false, "Falha no retorno da API", null);

                return result;
            }
            catch (Exception e)
            {
                return new CommandResult<List<TarefaCommand>>(false, $"Nenhuma resposta da API - {e.Message}", null);
            }
        }

        public async Task<CommandResult<TarefaCommand>> UpdateAsync(TarefaCommand tarefaViewModel)
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            var result = await client.PutAsJsonAsync($"Tarefa/{tarefaViewModel.Id}", tarefaViewModel);
            if (result is null)
            {
                return new CommandResult<TarefaCommand>(false, "Nenhuma resposta da API", null);
            }
            return await result.Content.ReadFromJsonAsync<CommandResult<TarefaCommand>>();
        }
        public async Task<CommandResult<TarefaCommand>> DeleteAsync(Guid id)
        {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
            var result = await client.DeleteAsync($"Tarefa/{id}");
            if (result is null)
            {
                return new CommandResult<TarefaCommand>(false, "Nenhuma resposta da API", null);
            }
            return await result.Content.ReadFromJsonAsync<CommandResult<TarefaCommand>>();
        }
        public async Task<CommandResult<TarefaCommand>> GetJsonAsync()
        {
            try
            {
            var client = httpClientFactory.CreateClient(Configuration.HttpClientName);
                await client.GetAsync("Tarefa/json");

                return new CommandResult<TarefaCommand>(true,"Iniciado download da base de dados JSON",null);
            }
            catch (Exception e)
            {
                return new CommandResult<TarefaCommand>(false, $"Erro para baixar o arquivo - {e.Message}", null);
            }
        }
    }
}
