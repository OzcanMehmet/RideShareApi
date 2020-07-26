using System;
using System.ComponentModel.DataAnnotations;

namespace RideShare.Model
{
    public class TravelPlanCreate
    {
        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        public string Description  { get; set; }
        
        [Required]
        public int SeatCount { get; set; }
    }
}
