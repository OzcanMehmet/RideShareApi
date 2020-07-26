using RideShare.Model;
using RideShare.Model.DTO;
using AutoMapper;

namespace RideShare.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,UserDTO>();
        }
    }
}