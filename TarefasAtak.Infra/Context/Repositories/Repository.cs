    using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Repositories.Interfaces;
using TarefasAtak.Core.SharedContext.Entities;
using TarefasAtak.Infra.Data;

namespace TarefasAtak.Infra.Context.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext<T> _context;

        public Repository(AppDbContext<T> context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Add(obj);
        }

        public List<T> GetAll()
        {
            var entities = _context.GetAll();
            return entities;
        }
    }
}
