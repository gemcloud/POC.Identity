using Microsoft.EntityFrameworkCore;
using POC.Identity.Infrastructure.Entities;
using POC.Identity.Infrastructure.Entities.AspNetIdentity;
using System;

namespace POC.Identity.Infrastructure.Seed
{
    public static class ModelBuilderSeedDataExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Added Menu items:
            modelBuilder.Entity<DashboardMenu>().HasData(
                //new DashboardMenu(1, "Dashboard", "fa fa-dashboard", "/", 0, DateTime.UtcNow),
                new DashboardMenu(1, "Dashboard", "nav-icon fas fa-th cyan", "/", 0, DateTime.UtcNow),

                new DashboardMenu(2, "Admins", "nav-icon fas fa-users", "#", 0, DateTime.UtcNow),
                new DashboardMenu(3, "Create Admin", "nav-icon fas fa-user-plus", "/Admins/Create", 2, DateTime.UtcNow),
                new DashboardMenu(4, "Manage Admins", "nav-icon fas fa-lightbulb", "/Admins/Index", 2, DateTime.UtcNow),
                new DashboardMenu(5, "Roles", "nav-icon fas fa-user-md", "#", 0, DateTime.UtcNow),
                new DashboardMenu(6, "Create Role", "nav-icon fas fa-plus", "/RolesAdmin/Create", 5, DateTime.UtcNow),
                new DashboardMenu(7, "Manage Roles", "nav-icon far fa-lightbulb", "/RolesAdmin/Index", 5, DateTime.UtcNow)
             );

            //<i class="far fa-plus"></i>
            //// Add users
            string userId1 = Guid.NewGuid().ToString();
            string userId2 = Guid.NewGuid().ToString();
            string userId3 = Guid.NewGuid().ToString();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { Id = userId1, Email = "manager@gmail.com", NormalizedEmail = "MANAGER@GMAIL.COM", UserName = "ManagerTiger", NormalizedUserName = "MANAGERTIGER", PasswordHash = "AQAAAAEAACcQAAAAEBUNskNj7w/UjmTY4/uHSZMvzFup6o+Zxu5qA7yALQKnbx0tOctfS9L08r0vm2A3Yg==", SecurityStamp = "TSBT2JIVTL3HKCHKTKNDYGJMQXXPGEYQ" },
                new ApplicationUser() { Id = userId2, Email = "Supervisor@gmail.com", NormalizedEmail = "SUPERVISOR@GMAIL.COM", UserName = "SuperTiger", NormalizedUserName = "SUPERTIGER", PasswordHash = "AQAAAAEAACcQAAAAEBUNskNj7w/UjmTY4/uHSZMvzFup6o+Zxu5qA7yALQKnbx0tOctfS9L08r0vm2A3Yg==", SecurityStamp = "TSBT2JIVTL3HKCHKTKNDYGJMQXXPGEYQ" },
                new ApplicationUser() { Id = userId3, Email = "Developer@gmail.com", NormalizedEmail = "DEVELOPER@GMAIL.COM", UserName = "DevTiger", NormalizedUserName = "DEVTIGER", PasswordHash = "AQAAAAEAACcQAAAAEBUNskNj7w/UjmTY4/uHSZMvzFup6o+Zxu5qA7yALQKnbx0tOctfS9L08r0vm2A3Yg==", SecurityStamp = "TSBT2JIVTL3HKCHKTKNDYGJMQXXPGEYQ" }
            );

            //// Add Roles
            string roleId1 = Guid.NewGuid().ToString();
            string roleId2 = Guid.NewGuid().ToString();
            string roleId3 = Guid.NewGuid().ToString();
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole() { Id = roleId1, Name = "Manager", NormalizedName = "MANAGER", Description = "Super Admin with all rights..." },
                new ApplicationRole() { Id = roleId2, Name = "Supervisor", NormalizedName = "SUPERVISOR", Description = "Can View Dashboard, Admins & Roles" },
                new ApplicationRole() { Id = roleId3, Name = "Developer", NormalizedName = "DEVELOPER", Description = "Can View Dashboard &  Admins List" }
            );

            // Add UserRole
            modelBuilder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole() { UserId = userId1, RoleId = roleId1 },
                new ApplicationUserRole() { UserId = userId2, RoleId = roleId2 },
                new ApplicationUserRole() { UserId = userId3, RoleId = roleId3 }
            );

            //// Add linkRolesMenus
            modelBuilder.Entity<LinkRolesMenu>().HasData(
                new LinkRolesMenu() { Id = 47, AppRoleId = roleId2, MenuId = 1 },
                new LinkRolesMenu() { Id = 48, AppRoleId = roleId2, MenuId = 2 },
                new LinkRolesMenu() { Id = 49, AppRoleId = roleId2, MenuId = 4 },
                new LinkRolesMenu() { Id = 50, AppRoleId = roleId2, MenuId = 5 },
                new LinkRolesMenu() { Id = 51, AppRoleId = roleId2, MenuId = 6 },
                new LinkRolesMenu() { Id = 52, AppRoleId = roleId2, MenuId = 7 },
                new LinkRolesMenu() { Id = 65, AppRoleId = roleId1, MenuId = 1 },
                new LinkRolesMenu() { Id = 66, AppRoleId = roleId1, MenuId = 2 },
                new LinkRolesMenu() { Id = 67, AppRoleId = roleId1, MenuId = 3 },
                new LinkRolesMenu() { Id = 68, AppRoleId = roleId1, MenuId = 4 },
                new LinkRolesMenu() { Id = 69, AppRoleId = roleId1, MenuId = 5 },
                new LinkRolesMenu() { Id = 70, AppRoleId = roleId1, MenuId = 6 },
                new LinkRolesMenu() { Id = 71, AppRoleId = roleId1, MenuId = 7 },
                new LinkRolesMenu() { Id = 76, AppRoleId = roleId3, MenuId = 1 },
                new LinkRolesMenu() { Id = 77, AppRoleId = roleId3, MenuId = 2 },
                new LinkRolesMenu() { Id = 78, AppRoleId = roleId3, MenuId = 4 }
            );

        }
    }
}
