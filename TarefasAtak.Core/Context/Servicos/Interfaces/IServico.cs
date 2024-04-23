using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.SharedContext.Entities;

namespace TarefasAtak.Core.Context.Servicos.Interfaces
{
    public interface IServico<T> where T : class
    {
        void Add(T obj);

        void Update(T obj);

        void DeleteById(T obj);

        List<T> GetAll();

    }
}
