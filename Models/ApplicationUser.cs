using Microsoft.AspNetCore.Identity;
using System;
namespace SmallEcommerceProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
