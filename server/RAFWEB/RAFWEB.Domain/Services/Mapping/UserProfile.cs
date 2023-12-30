using AutoMapper;
using RAFWEB.Data.Models;
using RAFWEB.Domain.Commands.Request.User;
using RAFWEB.Domain.Commands.Response.User;

namespace RAFWEB.Domain.Services.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserInfoResponse>()
        .ForMember(user => user.Email, map => map.MapFrom(userInfoResponse => userInfoResponse.Email))
        .ForMember(user => user.UserName, map => map.MapFrom(userInfoResponse => userInfoResponse.UserName));
        }
    }
}
