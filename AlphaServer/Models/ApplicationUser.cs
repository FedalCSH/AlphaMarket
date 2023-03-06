using Microsoft.AspNetCore.Identity;

namespace AlphaServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
