using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TarefasAtak.Core.SharedContext.Entities
{
    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    public abstract class Entity : IEquatable<Guid>
    {
        public Guid Id { get; set; }
        public bool Equals(Guid id) => Id == id;
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public virtual void NewGuid()
        {
            if(Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }
    }
}
