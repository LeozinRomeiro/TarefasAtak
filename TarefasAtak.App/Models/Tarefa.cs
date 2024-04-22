using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.App.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Titulo { get; set; } = string.Empty;
        public Descricao? Descricao { get; set; }
        public Status Status { get; set; } = Status.Nova;
    }
}
