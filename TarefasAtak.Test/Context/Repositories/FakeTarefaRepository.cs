using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Repositories.Interfaces;

namespace TarefasAtak.Test.Context.Repositories
{
    public class FakeTarefaRepository : ITarefaRepository
    {
        public void Add(Tarefa obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarefa> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tarefa GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Tarefa tarefa)
        {
            throw new NotImplementedException();
        }
    }
}
