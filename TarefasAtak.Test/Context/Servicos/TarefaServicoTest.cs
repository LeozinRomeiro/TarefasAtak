using TarefasAtak.Test.Context.Repositories;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Enums;
using TarefasAtak.Core.Context.Servicos;
using TarefasAtak.Core.Context.ValueObjetcs;
using TarefasAtak.Core.Context.Repositories.Interfaces;

namespace TarefasAtak.Test.Context.Servicos
{
    [TestClass]
    public class TarefaServicoTest
    {
        private readonly ITarefaRepository _fakeTarefaRepository;

        public TarefaServicoTest()
        {
            _fakeTarefaRepository = new FakeTarefaRepository();
        }

        [TestMethod]
        [TestCategory("Servico")]
        public void DadoUmaInsercaoMesmaDeveSerGerada()
        {
            try
            {
                var tarefas = _fakeTarefaRepository.GetAll();

                var quantidade = tarefas.Count();

                var tarefa = new Tarefa("Cozinha", new Descricao("Almoço de domingo"), Status.Nova);

                var servico = new TarefaServico(_fakeTarefaRepository);

                servico.Add(tarefa);

                Assert.AreEqual(tarefas.Count(), quantidade + 1);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void DadoUmaExclusaoMesmaDeveSerRemovida()
        {
            try
            {
                var tarefas = _fakeTarefaRepository.GetAll();

                var quantidade = tarefas.Count();

                var tarefa = new Tarefa("Cozinha", new Descricao("Almoço de domingo"), Status.Nova);

                var servico = new TarefaServico(_fakeTarefaRepository);

                servico.Add(tarefa);

                servico.DeleteById(tarefa.Id);

                Assert.AreEqual(tarefas.Count(), quantidade);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void DadoUmaEdicaoMesmaDeveSerAtualizada()
        {
            try
            {
                var tarefas = _fakeTarefaRepository.GetAll();

                var quantidade = tarefas.Count();

                var tarefaOriginal = new Tarefa("Cozinha", new Descricao("Almoço de domingo"), Status.Nova);

                var servico = new TarefaServico(_fakeTarefaRepository);

                servico.Add(tarefaOriginal);

                var tarefaEditado = new Tarefa("Cozinha macarrao", new Descricao("Almoço de sabado anoite"), Status.Andamento);

                servico.Update(tarefaOriginal.Id, tarefaEditado);

                tarefas = _fakeTarefaRepository.GetAll();

                var tarefaAtualizada = tarefas.FirstOrDefault(t => t.Id.Equals(tarefaOriginal.Id));

                Assert.AreEqual(tarefaAtualizada.Id, tarefaEditado.Id);
                Assert.AreEqual(tarefaAtualizada.Titulo, tarefaEditado.Titulo);
                Assert.AreEqual(tarefaAtualizada.Status, tarefaEditado.Status);
                Assert.AreEqual(tarefaAtualizada.Descricao.Texto, tarefaEditado.Descricao.Texto);
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
