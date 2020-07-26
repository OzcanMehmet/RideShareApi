using RideShare.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RideShare.Data.Concrete
{
    public class TravelPlanRepo : ITravelPlanRepo
    {
        ApiContext _context {get;set;} 
        public TravelPlanRepo(ApiContext context)
        {
            _context     = context;
        }
        public TravelPlan GetById(int id)
        {
            return _context.TravelPlan.FirstOrDefault(x=>x.Id==id);
        }
        public void Add(TravelPlan plan)
        {
            _context.TravelPlan.Add(plan);
            _context.SaveChanges();           
        }
        public void SetValid(TravelPlan plan)
        {
            plan.Valid = true;
            _context.TravelPlan.Update(plan);
            _context.SaveChanges(); 
        }
        public void SetInValid(TravelPlan plan)
        {
            plan.Valid = false;
            _context.TravelPlan.Update(plan);
            _context.SaveChanges(); 
        }

        public IEnumerable<TravelPlan> GetTravelPlansByEmail(string email)
        {
            return _context.TravelPlan.Where(x=>x.Owner.Email==email).ToList();
        }

        public IEnumerable<TravelPlan> List(Expression<Func<TravelPlan, bool>> predicate)
        {
            return _context.TravelPlan.Where(predicate).AsEnumerable();
        }

        public void Update(TravelPlan plan)
        {
            _context.Update(plan);
            _context.SaveChanges();
        }

        public IEnumerable<TravelPlan> ListWithGuests(Expression<Func<TravelPlan, bool>> predicate)
        {
            return _context.TravelPlan.Include("TravelGuest").Where(predicate).AsEnumerable();
        }
    }
}