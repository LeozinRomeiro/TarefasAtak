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
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext<Tarefa> _context;

        public TarefaRepository(AppDbContext<Tarefa> context)
        {
            _context = context;
        }

        public List<Tarefa> GetAll()
        {
            var tarefas = _context.GetAll();
            return tarefas;
        }

        public void Add(Tarefa tarefa)
        {
            _context.Add(tarefa);
        }

        public List<Tarefa> Listar()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Tarefa> IRepository<Tarefa>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
