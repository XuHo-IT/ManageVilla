using Microsoft.AspNetCore.Identity;

namespace VillaManage_VillaAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
