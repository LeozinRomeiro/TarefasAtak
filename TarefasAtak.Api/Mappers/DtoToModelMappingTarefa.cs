using AutoMapper;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.Core.Context.Commands;

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
            CreateMap<TarefaCommand, Tarefa>()
                .ForMember(e=>e.Id, d=>d.MapFrom(x=>x.Id))
                .ForMember(e => e.Titulo, d => d.MapFrom(x => x.Titulo))
                .ForPath(dest => dest.Descricao.Texto, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(e => e.Status, d => d.MapFrom(x => x.Status));
        }
    }
}
