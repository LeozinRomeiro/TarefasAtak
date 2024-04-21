using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Repositories.Interfaces;
using TarefasAtak.Infra.Data;

namespace TarefasAtak.Infra.Context.Repositories
{
    public class TarefaRepository : Repository<Tarefa>,ITarefaRepository
    {
        private readonly AppDbContext<Tarefa> _context;

        public TarefaRepository(AppDbContext<Tarefa> context):base(context)
        {
            _context = context;
        }

        public Tarefa GetByID(Guid id)
        {
            var tarefas = _context.GetAll();

            return tarefas.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Tarefa GetByID(List<Tarefa> tarefas,Guid id)
        {
            return tarefas.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Add(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            _context.Add(tarefa);
        }

        public List<Tarefa> GetAll()
        {
            var entities = _context.GetAll();
            return entities;
        }

        public bool DeleteById(Guid id)
        {
            var tarefas = GetAll();
            var tarefa = GetByID(tarefas, id);
            return _context.Delete(tarefas, tarefa);
        }
        public void Update(Guid id, Tarefa tarefa)
        {
            var tarefas = GetAll();
            var _tarefa = tarefas.FirstOrDefault(x=>x.Id.Equals(id));
            tarefa.Id = id; 
            if(_tarefa != null)
                _context.Update(tarefas, _tarefa, tarefa);
        }
    }
}
