using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Commands.Interfaces;
using TarefasAtak.Core.Context.Servicos.Interfaces;
using TarefasAtak.Core.Context.Repositories.Interfaces;
using TarefasAtak.Core.SharedContext.Entities;

namespace TarefasAtak.Core.Context.Servicos
{
    public class Servico<T> : IServico<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Servico(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
