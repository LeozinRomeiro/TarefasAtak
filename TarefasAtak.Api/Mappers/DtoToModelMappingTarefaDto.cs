using AutoMapper;
using TarefasAtak.Api.Dtos;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Api.Mappers
{
    public class DtoToModelMappingTarefaDto : Profile
    {
        public DtoToModelMappingTarefaDto()
        {
            TarefaMap();
        }

        private void TarefaMap()
        {
            CreateMap<Tarefa, TarefaDto>()
                .ForMember(e => e.Titulo, d => d.MapFrom(x => x.Titulo))
                .ForMember(e => e.Status, d => d.MapFrom(x => x.Status))
                .ForMember(e => e.Descricao, d => d.MapFrom(x => x.Descricao));
        }
    }
}
