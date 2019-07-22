using AutoMapper;

namespace Service.Kapi.API.Mappings
{
    public class UsersViewMappings : Profile
    {
        public UsersViewMappings()
        {
            CreateMap<BLL.Models.User, Models.User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
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

            CreateMap<Models.User, BLL.Models.User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
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
        }
    }
}
