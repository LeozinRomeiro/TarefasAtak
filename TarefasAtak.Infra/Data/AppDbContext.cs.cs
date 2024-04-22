using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.ValueObjetcs;
using TarefasAtak.Core.SharedContext.Entities;

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

            var options = new JsonSerializerOptions
            {
                PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate
            };

            return JsonSerializer.Deserialize<List<T>>(json, options);
        }

        public void Add(T entity)
        {
            var entities = GetAll();
            entities.Add(entity);
            Save(entities);
        }

        public void Update(List<T> entities, T entity, T entityUpdate)
        {
            entities.Remove(entity);
            entities.Add(entityUpdate);
            Save(entities);
        }

        public bool Delete(List<T> entities,T entity)
        {
            if (entities.Remove(entity))
            {
                Save(entities);
                return true;
            }
            return false;
        }

        private void Save(List<T> entities)
        {
            var json = JsonSerializer.Serialize(entities);
            File.WriteAllText(_nomeArquivo, json);
        }

    }
}
