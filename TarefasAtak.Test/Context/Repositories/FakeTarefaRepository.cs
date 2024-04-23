using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.Repositories.Interfaces;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.Test.Context.Repositories
{
    public class FakeTarefaRepository : ITarefaRepository
    {
        private IList<Tarefa> tarefas = new List<Tarefa>();
        public void Add(Tarefa obj)
        {
            tarefas.Add(obj);
        }

        public bool DeleteById(Guid id)
        {
            var tarefa = tarefas.FirstOrDefault(x => x.Id == id);
            if (tarefa is not null || tarefas.Contains(tarefa))
            {
                tarefas.Remove(tarefa);
                return true;
            }
            return false;
        }

        public IEnumerable<Tarefa> GetAll()
        {
            tarefas.Add(new Tarefa("Cozinhar",new Descricao("Fazer almoço as 12h"),Status.Nova));
            tarefas.Add(new Tarefa("Caminhar", new Descricao("Corrida no parque amanha"), Status.Nova));
            tarefas.Add(new Tarefa("Desenvolver", new Descricao("Projeto C#"), Status.Nova));

            return tarefas;
        }

        public Tarefa GetByID(Guid id)
        {
            var tarefa = new Tarefa("Cozinhar", new Descricao("Fazer almoço as 12h"), Status.Nova);
            return tarefa;
        }

        public void Update(Guid id, Tarefa tarefa)
        {
            var tarefaAtualizar = tarefas.FirstOrDefault(t => t.Id.Equals(id));
            tarefa.Id = tarefaAtualizar.Id;
            if (tarefa is not null)
            {
                tarefas.Remove(tarefaAtualizar);
                tarefas.Add(tarefa);
            }
        }
    }
}
