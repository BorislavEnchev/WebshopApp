using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebshopApp.Models
{
    [Serializable]
    public class WebshopAppUser : IdentityUser
    {
        public WebshopAppUser()
        {
            ClientReceipts = new HashSet<ClientReceipt>();
        }

        [Required]
        public string RoleId { get; set; }

        public string Role { get; set; }

        public virtual IEnumerable<ClientReceipt> ClientReceipts { get; set; }
    }
}
