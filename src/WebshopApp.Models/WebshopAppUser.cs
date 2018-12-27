using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebshopApp.Models
{
    // Add profile data for application users by adding properties to the WebshopAppUser class
    public class WebshopAppUser : IdentityUser
    {
        [Required]
        public string RoleId { get; set; }

        public string Role { get; set; }
    }
}
