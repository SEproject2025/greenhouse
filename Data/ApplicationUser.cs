using Microsoft.AspNetCore.Identity;

namespace greenhouse.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime UserCurrentDay { get; set; }
    }

}
