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

        //public void Add(Tarefa command)
        //{
        //    //Validar comando

        //    var tarefa = new Tarefa(command.Titulo, command.Descricao, command.Status);
        //    _tarefaRepository.Add(tarefa);
        //    //return new CommandResult(true, $"A tarefa {tarefa.Titulo} foi registrada com sucesso", tarefa);
        //}

        public void Update(Tarefa obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(Tarefa obj)
        {
            throw new NotImplementedException();
        }


        public Tarefa GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
