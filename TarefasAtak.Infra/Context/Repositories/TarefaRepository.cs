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
            return tarefas.FirstOrDefault(x => x.Id == id);
        }

    }
}
