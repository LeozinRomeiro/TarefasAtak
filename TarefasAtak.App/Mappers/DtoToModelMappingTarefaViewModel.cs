using AutoMapper;
using TarefasAtak.Core.Context.Entities;
using TarefasAtak.App.Models;

namespace TarefasAtak.App.Mappers
{
    public class DtoToModelMappingTarefaViewModel : Profile
    {
        public DtoToModelMappingTarefaViewModel()
        {
            TarefaMap();
        }

        private void TarefaMap()
        {
            CreateMap<Tarefa, TarefaViewModel>()
                .ForMember(e=>e.Id, d=>d.MapFrom(x=>x.Id))
                .ForMember(e => e.Titulo, d => d.MapFrom(x => x.Titulo))
                .ForPath(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao.Texto))
                .ForMember(e => e.Status, d => d.MapFrom(x => x.Status));
        }
    }
}
