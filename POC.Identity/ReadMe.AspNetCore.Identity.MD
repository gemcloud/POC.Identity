## 1. install Nuget
	"Microsoft.AspNetCore.Identity.EntityFrameworkCore"
	"Microsoft.EntityFrameworkCore.SqlServer"
	"Microsoft.EntityFrameworkCore.Tools"    ==> Add-Migration

## 2. set connectionString on appsettings.json
	"SqlServerContextConnection": "Server=DESKTOP-CRRG55B\\MSSQLSERVER01;database=PocIdentity001;User Id=sa;Password=Password@!234"

## 3. Migration by below 2 command
PM> Add-Migration CreateIdentity -Context PocApplicationDbContext

PM> Update-Database -Context PocApplicationDbContext -verbose


## 4. Add more entity (Address , Category), Migration

PM> Add-Migration AddAddressCategory -Context PocApplicationDbContext

PM> Update-Database -Context PocApplicationDbContext -verbose

## 5. Add Custome Columns on [AspNetUsers] [ApplicationRoles] 
      Add [DashboardMenu] [LinkRolesMenus] 
	  Join "roles" and "menu"
	  "Fluent API" Configuration

PM> Add-Migration AddLinkRolesMenu -Context PocApplicationDbContext


## 6. Add Seed
	To add class "ModelBuilderSeedDataExtensions.cs"
	To add entity "ApplicationUserRole : IdentityUserRole<string> "

	PM> Add-Migration AddSeed -Context PocApplicationDbContext
	PM> Update-Database -Context PocApplicationDbContext -verbose
	if there are some issue, remove them.
	PM> Remove-Migration 

## Remove all of Migration and Dataabase. Redo.
PM> Add-Migration CreateMigrationInit -Context PocApplicationDbContext
PM> Update-Database -Context PocApplicationDbContext -verbose
Worked!

## 7. Login In

Login :  Pass@1234
manager@gmail.com / P@ssw0rd
				Dashboad 
						Admins | Create Admins
						Admins | Manage Admins
						Roles  | Create Role
						Roles  | Manage Role
Supervisor@gmail.com  / P@ssw0rd 
				Dashboad 
						Admins | Manage Admins
						Roles  | Create Role
						Roles  | Manage Role
Developer@gmail.com / P@ssw0rd  
				Dashboad 
					  Admins | Manage Admins

## 8. Add Dashboard shown menu

