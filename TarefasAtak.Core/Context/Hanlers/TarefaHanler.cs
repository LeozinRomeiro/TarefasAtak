using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Repositories.Interfaces;
using TarefasAtak.Core.SharedContext.Hanlers;

namespace TarefasAtak.Core.Context.Hanlers
{
    public class TarefaHanler : IHanlers<CriarTarefaCommand>
    {
        public TarefaHanler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        private readonly ITarefaRepository _tarefaRepository;

        public ICommandResult Hanler(CriarTarefaCommand command)
        {
            //Validar comando

            var tarefa = new Tarefa(command.Titulo, command.Descricao, command.Status);
            _tarefaRepository.Save(tarefa);
            return new CommandResult(true, $"A tarefa {tarefa.Titulo} foi registrada com sucesso", tarefa);
        }
    }
}
