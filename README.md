# POC 
## 1. AspNetCore.Identity.EntityFrameworkCore 
      to use "Fluent API" Configuration.
## 2. Migration by below 2 commands (Code first to create Databaase on Sql Server)
      PM> Add-Migration CreateIdentity -Context PocApplicationDbContext
      PM> Update-Database -Context PocApplicationDbContext -verbose

## 3. Add Custome Columns on [AspNetUsers] [ApplicationRoles] 
      public class PocApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>

## 4. Add more entities
      Add [DashboardMenu] [LinkRolesMenus] 
      Join "roles" and "menu" for implement rolebase menus.
      
## 5. Create a Login Dashboard to Poc MVC data connection.
      to Poc MVC, submit, Ajax ==> Controller ==> view 
      to Poc Session etc.
