using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Core.Context.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        public void Save(List<Tarefa> tarefa);
    }
}
