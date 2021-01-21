using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Infrastructure.Entities.AspNetIdentity
{
    // Custom IdentityRole<string>
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }

        //-----------------------------------------------------------------
        //Custom your properties.
        public string Description { get; set; }

        //-----------------------------------------------------------------
        //Add Link tables relationship.
        public virtual ICollection<LinkRolesMenu> LinkRolesMenus { get; set; }
        //public virtual ICollection<AppGroupRole> AppGroups { get; set; }

        //-----------------------------------------------------------------
        //NOT need custom LinkUserRoles relationship.
        //public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }     // get all users with their associated roles.

    }
}
