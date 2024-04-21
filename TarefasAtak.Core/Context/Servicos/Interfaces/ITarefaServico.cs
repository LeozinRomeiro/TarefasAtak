using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Core.Context.Servicos.Interfaces
{
    public interface ITarefaServico : IServico<Tarefa>
    {
        Tarefa GetById(Guid id);

        bool DeleteById(Guid id);
        void Update(Guid id, Tarefa tarefa);
    }
}
