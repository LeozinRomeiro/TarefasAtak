using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Core.Context.Repositories.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        public Tarefa GetByID(Guid id);
        bool DeleteById(Guid id);
    }
}
