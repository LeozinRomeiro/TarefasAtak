using AutoMapper;
using TarefasAtak.Api.Dtos;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Api.Mappers
{
    public class DtoToModelMappingTarefa : Profile
    {
        public DtoToModelMappingTarefa()
        {
            TarefaMap();
        }

        private void TarefaMap()
        {
            CreateMap<TarefaDto, Tarefa>()
                .ForMember(e=>e.Id, d=>d.Ignore())
                .ForMember(e => e.Titulo, d => d.MapFrom(x => x.Titulo))
                .ForMember(e => e.Descricao, d => d.MapFrom(x => x.Descricao))
                .ForMember(e => e.Status, d => d.MapFrom(x => x.Status));
        }
    }
}
