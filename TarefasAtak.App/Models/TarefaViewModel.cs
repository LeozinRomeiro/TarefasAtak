using TarefasAtak.Core.Context.Enums;

namespace TarefasAtak.App.Models
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.Nova;
    }
}
