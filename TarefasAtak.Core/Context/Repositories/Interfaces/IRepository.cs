using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Core.Context.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();

        public void Add(T obj);
    }
}
