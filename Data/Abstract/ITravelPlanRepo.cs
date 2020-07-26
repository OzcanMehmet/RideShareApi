using RideShare.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RideShare.Data
{
    public interface ITravelPlanRepo
    {
        IEnumerable<TravelPlan> GetTravelPlansByEmail(string email);
        IEnumerable<TravelPlan> List(Expression<Func<TravelPlan, bool>> predicate);
        IEnumerable<TravelPlan> ListWithGuests(Expression<Func<TravelPlan, bool>> predicate);
        void Add(TravelPlan plan);
        void Update(TravelPlan plan);
        void SetValid(TravelPlan plan);     
        void SetInValid(TravelPlan plan);
        TravelPlan GetById(int id);
    }
}