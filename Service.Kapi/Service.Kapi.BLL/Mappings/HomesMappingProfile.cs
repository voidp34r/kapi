using AutoMapper;
using Service.Kapi.BLL.Models;
using Service.Kapi.DAL.MySql.Models;
using System;

namespace Service.Kapi.BLL.Mappings
{
    public class HomesMapping: Profile
    {
        public HomesMapping()
        {
            CreateMap<Home, HomeEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Block, opt => opt.MapFrom(src => src.Block))
                .ForMember(d => d.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(d => d.HomeType, opt => opt.MapFrom(src => src.HomeType))
                .ForMember(d => d.Lives, opt => opt.MapFrom(src => src.Lives))
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(d => d.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn));

            CreateMap<HomeEntity, Home>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
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
