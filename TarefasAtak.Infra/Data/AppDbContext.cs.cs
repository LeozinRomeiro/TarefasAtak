using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Infra.Data
{
    public class AppDbContext<T>
    {
        private readonly string _nomeArquivo;

        public AppDbContext(string nomeArquivo = "C:\\dev\\TarefasAtak\\TarefasAtak.Infra\\Data\\dataBase.json")
        {
            _nomeArquivo = nomeArquivo;
        }


        public List<T> GetAll()
        {
            if (!File.Exists(_nomeArquivo))
                return new List<T>();

            var json = File.ReadAllText(_nomeArquivo);

            if (string.IsNullOrEmpty(json) || json== "{}")
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void Add(T entity)
        {
            var entities = GetAll();
            entities.Add(entity);
            Save(entities);
        }

        //public void Update(T entity)
        //{
        //    var entities = GetAll();
        //    var existingEntity = entities.Find(e => /* lógica para encontrar a entidade a ser atualizada */);
        //    Save(entities);
        //}

        //public void Delete(/* parâmetros para identificar a entidade a ser excluída */)
        //{
        //    var entities = GetAll();
        //    Save(entities);
        //}

        private void Save(List<T> entities)
        {
            var json = JsonSerializer.Serialize(entities);
            File.WriteAllText(_nomeArquivo, json);
        }

    }
}
