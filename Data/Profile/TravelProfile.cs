using RideShare.Model;
using AutoMapper;

namespace RideShare.Profiles
{
    public class TravelProfile : Profile
    {
        public TravelProfile()
        {
            CreateMap<TravelPlanCreate,TravelPlan>();
            CreateMap<TravelPlan,TravelPlanInfo>();
        }
    }
}