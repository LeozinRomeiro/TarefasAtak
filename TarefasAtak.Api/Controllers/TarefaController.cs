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
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase 
    {
        private readonly ITarefaServico servico;
        private readonly IMapper mapper;

        public TarefaController(ITarefaServico servico, IMapper mapper)
        {
            this.servico = servico;
            this.mapper = mapper;
        }
        [HttpGet("json")]
        public async Task<ActionResult> GetJsonAsync()
        {
            try
            {
                var filePath = "C:\\dev\\TarefasAtak\\TarefasAtak.Infra\\Data\\dataBase.json";

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                var fileBytes = System.IO.File.ReadAllBytes(filePath);

                HttpContext.Response.ContentType = "application/json";
                var fileName = "dataJson.json";
                HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");

                return File(fileBytes, HttpContext.Response.ContentType, "dataJson.json");
            }
            catch (Exception e)
            {
                return StatusCode(500, new CommandResult<Tarefa>(false, $"Falha interna! - {e.Message}", null));
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var tarefas = servico.GetAll();
                var tarefasCommand = mapper.Map<List <TarefaCommand>>(tarefas.ToList());

                return Ok(new CommandResult<List<TarefaCommand>>(true, "Resultado da busca...", tarefasCommand));
            }
            catch(Exception e)
            {
                return StatusCode(500, new CommandResult<Tarefa>(false, $"Falha interna! - {e.Message}",null));
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] Guid id)
        {

            var tarefa = servico.GetById(id);
            //var tarefasDto = mapper.Map<TarefaDto>(tarefa);

            return Ok(new CommandResult<Tarefa>(true, "Resultado da busca...", tarefa));
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] TarefaDto tarefaDto)
        {
            if (tarefaDto is null)
                return NotFound();

            var tarefa = mapper.Map<Tarefa>(tarefaDto);

            servico.Add(tarefa);

            return Ok(new CommandResult<Tarefa>(true, $"A tarefa {tarefa.Titulo} foi registrada com sucesso", null));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {

            var tarefa = servico.GetById(id);
            if (servico.DeleteById(tarefa.Id))
            {
                return Ok(new CommandResult<Tarefa>(true, $"A tarefa {tarefa.Titulo} foi deletada com sucesso", null));
            }
            return StatusCode(500,new CommandResult<Tarefa>(false, $"Erro na exclusão da tarefa {tarefa.Titulo}", null));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] TarefaDto tarefaDto)
        {
            try
            {
                var tarefa = mapper.Map<Tarefa>(tarefaDto);
                servico.Update(id, tarefa);
                return Ok(new CommandResult<Tarefa>(true, $"A tarefa {tarefa.Titulo} foi atualizada com sucesso", null));
            }
            catch
            {
                return StatusCode(500, new CommandResult<Tarefa>(false, $"Erro na atualização da tarefa", null));
                throw;
            }
        }
    }
}
