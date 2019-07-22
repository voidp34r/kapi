using AutoMapper;
using Service.Kapi.BLL.Models;
using Service.Kapi.DAL.MySql.Models;
using System;

namespace Service.Kapi.BLL.Mappings
{
    public class UsersMapping: Profile
    {
        public UsersMapping()
        {
            CreateMap<User, UserEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.UserType, opt => opt.MapFrom(src => src.UserType))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(d => d.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(d => d.Birth, opt => opt.MapFrom(src => src.Birth))
                .ForMember(d => d.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(d => d.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(d => d.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
                .ForMember(d => d.DeletedOn, opt => opt.MapFrom(src => src.DeletedOn));

            CreateMap<UserEntity, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.UserType, opt => opt.MapFrom(src => src.UserType))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(d => d.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(d => d.Birth, opt => opt.MapFrom(src => src.Birth))
                .ForMember(d => d.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(d => d.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(d => d.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(d => d.ModifiedOn, opt => opt.MapFrom(src => src.ModifiedOn))
                .ForMember(d => d.DeletedOn, opt => opt.MapFrom(src => src.DeletedOn)); ;
        }       
    }
}
