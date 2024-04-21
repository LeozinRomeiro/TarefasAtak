using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TarefasAtak.Api.Dtos;
using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Servicos;
using TarefasAtak.Core.Context.Servicos.Interfaces;
using TarefasAtak.Infra.Context.Repositories;
using TarefasAtak.Infra.Data;

namespace TarefasAtak.Api.Controllers
{
    public class TarefaController : ControllerBase 
    {
        private readonly ITarefaServico servico;
        private readonly IMapper mapper;

        public TarefaController(ITarefaServico servico, IMapper mapper)
        {
            this.servico = servico;
            this.mapper = mapper;
        }

        [Route("[controller]")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {

            var tarefas = servico.GetAll();
            var tarefasDto = mapper.Map<List <TarefaDto>>(tarefas.ToList());

            //var tarefa = new Tarefa("teste", new Core.Context.ValueObjetcs.Descricao("teste"), Core.Context.Enums.Status.Andamento);

            //hanler.Add(tarefa);

            return Ok(new CommandResult(true, "Resultado da busca...", tarefasDto));
        }

        [Route("[controller]")]
        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {

            var tarefa = new Tarefa("teste", new Core.Context.ValueObjetcs.Descricao("teste"), Core.Context.Enums.Status.Andamento);

            servico.Add(tarefa);

            return Ok(new CommandResult(true, $"A tarefa {tarefa.Titulo} foi registrada com sucesso", tarefa));
        }
    }
}
