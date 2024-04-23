using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.Exceptions;
using TarefasAtak.Core.Context.ValueObjetcs;

namespace TarefasAtak.Test.Context.ValueObjetcs;

[TestClass]
public class DescrisaoTest
{
    [TestMethod]
    [ExpectedException(typeof(TarefaInvalidaException))]
    [DataRow(null)]
    [DataRow("")]
    [DataRow("aperfeiçoou minhas habilidades em C# com web em principal usando ASP.NET, Blazor e Razor Pages, mas já desenvolvi com Windows Forms e Xamarin. Resultando em pratica com Java Script, CSS e HTML básico e total fundamentos de SQL Server(Conhecimento em T-SQL)")]
    public void DadoUmaDescrisaoInvalidaDeveRetornarExcecao(string texto)
    {
        new Tarefa("Tarefa invalida", new Descricao(texto), Status.Nova);
    }
}