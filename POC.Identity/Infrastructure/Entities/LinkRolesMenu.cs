using POC.Identity.Infrastructure.Entities.AspNetIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Infrastructure.Entities
{
    public class LinkRolesMenu
    {
        public int Id { get; set; }
        public string AppRoleId { get; set; }         // do NOT need, because there is property DashboardMenus  AspNetRoleId
        public ApplicationRole AppRole { get; set; }
        public int MenuId { get; set; }            // do NOT need, because there is property AspNetRole  DashboardMenusId

        public DashboardMenu Menu { get; set; }
    }
}
