using System;
using System.ComponentModel.DataAnnotations;

namespace RideShare.Model
{
    public class TravelGuestRequest 
    {
        [Required]
        public int PlanId { get; set; }
        
        [Required]
        public int Seat {get;set;}
    }
}
