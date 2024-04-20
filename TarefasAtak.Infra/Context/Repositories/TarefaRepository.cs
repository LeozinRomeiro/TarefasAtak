using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Repositories.Interfaces;

namespace TarefasAtak.Infra.Context.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly string _nomeArquivo;

        public TarefaRepository(string nome)
        {
            _nomeArquivo = nome;
        }

        public List<Tarefa> GetAll()
        {
            if (!File.Exists(_nomeArquivo))
                return new List<Tarefa>();
            var json = File.ReadAllText(_nomeArquivo);
            return JsonSerializer.Deserialize<List<Tarefa>>(json);
        }

        public void Save(List<Tarefa> tarefa)
        {
            var json = JsonSerializer.Serialize(tarefa);
            File.WriteAllText(_nomeArquivo, json);
        }
    }
}
