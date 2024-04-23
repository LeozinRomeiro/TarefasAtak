using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Servicos.Interfaces;
using TarefasAtak.Core.Context.Repositories.Interfaces;

namespace TarefasAtak.Core.Context.Servicos
{
    public class TarefaServico : Servico<Tarefa>, ITarefaServico 
    {
        public TarefaServico(ITarefaRepository tarefaRepository) : base(tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        private readonly ITarefaRepository _tarefaRepository;

        public Tarefa GetById(Guid id)
        {
            return _tarefaRepository.GetByID(id);
        }

        public bool DeleteById(Guid id)
        {
            return _tarefaRepository.DeleteById(id);
        }

        public void Update(Guid id, Tarefa tarefa)
        {
            _tarefaRepository.Update(id, tarefa);
        }
    }
}
