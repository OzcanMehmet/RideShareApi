using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RideShare.Model
{
    public class TravelGuest
    {
        
        public int Id { get; set;}

        
        public TravelPlan Plan {get;set;}

   
        public User Guest { get; set; }

     
        public int RezervedSeatCount {get;set;}
    }
}
