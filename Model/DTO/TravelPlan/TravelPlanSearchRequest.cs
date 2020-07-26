using System.ComponentModel.DataAnnotations;

namespace RideShare.Model.DTO.TravelPlan
{
    public class TravelPlanSearchRequest
    {
        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }
    }
}