using System;
using System.Collections.Generic;

namespace POC.Identity.Infrastructure.Entities
{
    public class DashboardMenu
    {
        private DashboardMenu() { }

        public DashboardMenu(int id, string name, string icon, string url, int parentid, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            Icon = icon;
            Url = url;
            ParentId = parentid;
            DateCreated = dateCreated;
            LinkRolesMenus = new HashSet<LinkRolesMenu>();
        }

        public int Id { get; private set; }
        //[StringLength(2500)]
        public string Name { get; private set; }
        public string Icon { get; private set; }
        public string Url { get; private set; }
        public int ParentId { get; private set; }
        public DateTime DateCreated { get; set; }

        //-----------------------------------------------------------------------
        // IEnumerable vs ICollection on EF Core?
        public ICollection<LinkRolesMenu> LinkRolesMenus { get; set; }

    }
}
