using RideShare.Data;
using RideShare.Data.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace RideShare.Utils.Helper
{
    public static class DIHelper
    {
        public static IServiceCollection UseDI(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo,UserRepo>();
            services.AddTransient<ITravelPlanRepo,TravelPlanRepo>();
            return services;
        }
    }
}