using System;
using System.ComponentModel.DataAnnotations;

namespace RideShare.Model
{
    public class TravelPlanInfo
    {
     
        public int Id { get; set; }
        public string To { get; set; }

        public string From { get; set; }
   
        public DateTime Date { get; set; }

        public string Description  { get; set; }
       
        public int SeatCount { get; set; }
        public bool Valid { get; set; }
    }
}
