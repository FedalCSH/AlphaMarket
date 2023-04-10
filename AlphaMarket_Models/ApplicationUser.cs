using Microsoft.AspNetCore.Identity;

namespace AlphaMarket_Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
