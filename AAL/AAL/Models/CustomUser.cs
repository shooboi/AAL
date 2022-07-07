using Microsoft.AspNetCore.Identity;

namespace AAL.Models
{
    public class CustomUser : IdentityUser
    {
        public UserInfo UserInfo { get; set; }
    }
}
