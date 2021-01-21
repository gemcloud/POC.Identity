using Microsoft.AspNetCore.Identity;

namespace POC.Identity.Infrastructure.Entities.AspNetIdentity
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string CustomTag { get; set; }
        public int CompanyId { get; set; }

        //-----------------------------------------------------------------
        //Add LinkUserGroup relationship.
        //public virtual ICollection<AppUserGroup> AppGroups { get; set; }
        ////-----------------------------------------------------------------
        ////NOT need custom LinkUserRoles relationship.
        ////public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }     // get all users with their associated roles.
    }
}
