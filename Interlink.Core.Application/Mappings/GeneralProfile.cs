using AutoMapper;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Domain.Entities;


namespace Interlink.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
           
            #region UserProfile
            CreateMap<User, UserViewModel>()
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<User, SaveUserViewModel>()
            .ForMember(x => x.ConfirmPassword, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<SavePostViewModel, Post>()
           .ForMember(dest => dest.UserId, opt => opt.Ignore()) 
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) 
           .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)); 
            #endregion

        }
    }
}
