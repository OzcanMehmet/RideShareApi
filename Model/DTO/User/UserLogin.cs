using System.ComponentModel.DataAnnotations;

namespace RideShare.Model.DTO.User
{
    public class UserLogin
    {
        [Required]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email {get;set;}
    }
}