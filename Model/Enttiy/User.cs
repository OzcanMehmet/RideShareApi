using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RideShare.Model
{
    public class User
    {
        
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email {get;set;}
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }

        public string Token { get; set; }

        public ICollection<TravelPlan> TravelPlans { get; set; }
    }
}
