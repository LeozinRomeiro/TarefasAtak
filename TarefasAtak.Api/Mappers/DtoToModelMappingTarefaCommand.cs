using AutoMapper;
using TarefasAtak.Core.Context.Commands;
using TarefasAtak.Core.Context.Entities;

namespace TarefasAtak.Api.Mappers
{
    public class DtoToModelMappingTarefaCommand : Profile
    {
        public DtoToModelMappingTarefaCommand()
        {
            TarefaMap();
        }

        private void TarefaMap()
        {
            CreateMap<Tarefa, TarefaCommand>()
                .ForMember(e=>e.Id, d=>d.MapFrom(x=>x.Id))
                .ForMember(e => e.Titulo, d => d.MapFrom(x => x.Titulo))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao.Texto))
                .ForMember(e => e.Status, d => d.MapFrom(x => x.Status));
        }
    }
}
