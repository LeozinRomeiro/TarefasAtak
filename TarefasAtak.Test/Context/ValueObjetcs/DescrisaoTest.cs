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
    public void DadoUmaDescrisaoVaziaDeveRetornarExcecao()
    {
        var descrisao = new Descricao("");
        var tarefa = new Tarefa("Tarefa invalida", descrisao, Status.Nova);
    }
}