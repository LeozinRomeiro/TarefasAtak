using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Servicos.Interfaces;
using TarefasAtak.Core.Context.Repositories.Interfaces;

namespace TarefasAtak.Core.Context.Servicos
{
    public class TarefaServico : IServico<Tarefa>, ITarefaServico 
    {
        public TarefaServico(ITarefaRepository tarefaRepository)
        {
            this._tarefaRepository = tarefaRepository;
        }
        private readonly ITarefaRepository _tarefaRepository;

        public ICommandResult Listar()
        {
            var tarefas = _tarefaRepository.Listar();
            return new CommandResult(true,"",tarefas);
        }

        public void Add(Tarefa command)
        {
            //Validar comando

            var tarefa = new Tarefa(command.Titulo, command.Descricao, command.Status);
            _tarefaRepository.Add(tarefa);
            //return new CommandResult(true, $"A tarefa {tarefa.Titulo} foi registrada com sucesso", tarefa);
        }
        public IEnumerable<Tarefa> GetAll()
        {
            throw new NotImplementedException();
        }

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
