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

## 7. Jwt Token

## 6. Login In
## 7. active