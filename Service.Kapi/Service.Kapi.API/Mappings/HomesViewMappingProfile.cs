using AutoMapper;

namespace Service.Kapi.API.Mappings
{
    public class HomesViewMappings : Profile
    {
        public HomesViewMappings()
        {
            CreateMap<BLL.Models.Home, Models.Home>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Block, opt => opt.MapFrom(src => src.Block))
                .ForMember(d => d.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(d => d.HomeType, opt => opt.MapFrom(src => src.HomeType))
                .ForMember(d => d.Lives, opt => opt.MapFrom(src => src.Lives))
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(d => d.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn));

            CreateMap<Models.Home, BLL.Models.Home>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Block, opt => opt.MapFrom(src => src.Block))
                .ForMember(d => d.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(d => d.HomeType, opt => opt.MapFrom(src => src.HomeType))
                .ForMember(d => d.Lives, opt => opt.MapFrom(src => src.Lives))
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(d => d.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn));
        }
    }
}
