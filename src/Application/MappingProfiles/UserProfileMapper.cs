using Application.Common.DTOs;
using AutoMapper;
using Domain.Entities.UserEntity;

namespace Application.MappingProfiles
{
    public class UserProfileMapper : Profile
    {
        public UserProfileMapper()
        {
            CreateMap<User, UserDto>();
        }
    }
}