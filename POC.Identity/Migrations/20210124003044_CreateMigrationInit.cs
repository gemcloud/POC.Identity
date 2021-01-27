using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POC.Identity.Migrations
{
    public partial class CreateMigrationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkRolesMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRoleId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRolesMenus", x => x.Id);
                    table.ForeignKey(
                        name: "link_roles_menus_ibfk_1",
                        column: x => x.MenuId,
                        principalTable: "DashboardMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "link_roles_menus_ibfk_2",
                        column: x => x.AppRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", "8fd9396a-4cf4-440e-a3ee-8630e84657c5", "Super Admin with all rights...", "Manager", "MANAGER" },
                    { "29738c82-0148-4ab9-89fe-da5eb23ede74", "66e61c0d-0885-426c-9ba3-dea009d8572f", "Can View Dashboard, Admins & Roles", "Supervisor", "SUPERVISOR" },
                    { "d324de18-2453-4d6c-b807-85d090c8bec5", "50ba023a-926a-4236-b7bf-fa93569e6e23", "Can View Dashboard &  Admins List", "Developer", "DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CustomTag", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1fcdfddc-3eed-43a1-b34b-2c082c185de0", 0, 0, "0172a50a-3974-4e0d-a281-ebe2570b634a", null, "manager@gmail.com", false, false, null, "MANAGER@GMAIL.COM", "MANAGERTIGER", "AQAAAAEAACcQAAAAEBUNskNj7w/UjmTY4/uHSZMvzFup6o+Zxu5qA7yALQKnbx0tOctfS9L08r0vm2A3Yg==", null, false, "TSBT2JIVTL3HKCHKTKNDYGJMQXXPGEYQ", false, "ManagerTiger" },
                    { "a01f0f1f-3542-4950-9c3f-98064b9ca69a", 0, 0, "f48a7cd7-f14b-4e87-b219-3d8ee9a17cfa", null, "Supervisor@gmail.com", false, false, null, "SUPERVISOR@GMAIL.COM", "SUPERTIGER", "AQAAAAEAACcQAAAAEBUNskNj7w/UjmTY4/uHSZMvzFup6o+Zxu5qA7yALQKnbx0tOctfS9L08r0vm2A3Yg==", null, false, "TSBT2JIVTL3HKCHKTKNDYGJMQXXPGEYQ", false, "SuperTiger" },
                    { "cd5f6cec-60c7-461a-9825-f074c2dcd757", 0, 0, "cce71711-e6f5-4694-abcf-5c4ffca6fbdf", null, "Developer@gmail.com", false, false, null, "DEVELOPER@GMAIL.COM", "DEVTIGER", "AQAAAAEAACcQAAAAEBUNskNj7w/UjmTY4/uHSZMvzFup6o+Zxu5qA7yALQKnbx0tOctfS9L08r0vm2A3Yg==", null, false, "TSBT2JIVTL3HKCHKTKNDYGJMQXXPGEYQ", false, "DevTiger" }
                });

            migrationBuilder.InsertData(
                table: "DashboardMenus",
                columns: new[] { "Id", "DateCreated", "Icon", "Name", "ParentId", "url" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(1452), "fa fa-dashboard", "Dashboard", 0, "/" },
                    { 2, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(5436), "fa fa-users", "Admins", 0, "#" },
                    { 3, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(5498), "fa fa-plus", "Create Admin", 2, "/Admins/Create" },
                    { 4, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(5501), "fa fa-users", "Manage Admins", 2, "/Admins/Index" },
                    { 5, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(5502), "fa fa-lock", "Roles", 0, "#" },
                    { 6, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(5503), "fa fa-loc", "Create Role", 5, "/RolesAdmin/Create" },
                    { 7, new DateTime(2021, 1, 24, 0, 30, 44, 316, DateTimeKind.Utc).AddTicks(5504), "fa fa-lock", "Manage Roles", 5, "/RolesAdmin/Index" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", "1fcdfddc-3eed-43a1-b34b-2c082c185de0", "ApplicationUserRole" },
                    { "29738c82-0148-4ab9-89fe-da5eb23ede74", "a01f0f1f-3542-4950-9c3f-98064b9ca69a", "ApplicationUserRole" },
                    { "d324de18-2453-4d6c-b807-85d090c8bec5", "cd5f6cec-60c7-461a-9825-f074c2dcd757", "ApplicationUserRole" }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesMenus",
                columns: new[] { "Id", "AppRoleId", "MenuId" },
                values: new object[,]
                {
                    { 70, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 6 },
                    { 51, "29738c82-0148-4ab9-89fe-da5eb23ede74", 6 },
                    { 69, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 5 },
                    { 50, "29738c82-0148-4ab9-89fe-da5eb23ede74", 5 },
                    { 78, "d324de18-2453-4d6c-b807-85d090c8bec5", 4 },
                    { 68, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 4 },
                    { 49, "29738c82-0148-4ab9-89fe-da5eb23ede74", 4 },
                    { 67, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 3 },
                    { 77, "d324de18-2453-4d6c-b807-85d090c8bec5", 2 },
                    { 66, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 2 },
                    { 48, "29738c82-0148-4ab9-89fe-da5eb23ede74", 2 },
                    { 76, "d324de18-2453-4d6c-b807-85d090c8bec5", 1 },
                    { 65, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 1 },
                    { 47, "29738c82-0148-4ab9-89fe-da5eb23ede74", 1 },
                    { 52, "29738c82-0148-4ab9-89fe-da5eb23ede74", 7 },
                    { 71, "0a94202f-4f4d-4121-b6fd-23ef58e5f02f", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_AppRoleId",
                table: "LinkRolesMenus",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkRolesMenus_MenuId",
                table: "LinkRolesMenus",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "LinkRolesMenus");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DashboardMenus");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
