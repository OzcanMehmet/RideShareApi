using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RideShare.Model
{
    public class TravelPlan
    {
        public int Id { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Description  { get; set; }

        [Required]
        public int SeatCount { get; set; }

        public bool Valid { get; set; }

        [Required]
        public User Owner { get; set; }

        public ICollection<TravelGuest> TravelGuest { get; set; }
    }
}
