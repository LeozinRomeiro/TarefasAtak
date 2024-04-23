using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.Exceptions;
using TarefasAtak.Core.Context.ValueObjetcs;
using TarefasAtak.Test.Context.Enums;

namespace TarefasAtak.Test.Context.Entities
{
    [TestClass]
    public class TarefaTest
    {
        [TestMethod]
        [ExpectedException(typeof(TarefaInvalidaException))]
        //[DataRow("Titulo valido",FakeStatus.Completa)]
        [DataRow(null, Status.Nova)]
        [DataRow("W", Status.Nova)]
        [DataRow("Apesar de simples, o Contador de Caracteres tem várias aplicações", Status.Nova)]
        public void DadoUmaTarefaInvalidaDeveRetornarExcecao(string titulo, Status status)
        {
            new Tarefa(titulo, new Descricao("O foco é apenas a entidade tarefa"), status);
        }

    }
}
