using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.Api.Dtos
{
    public record TarefaDto(string Titulo, Descricao Descricao, Status Status);
}
