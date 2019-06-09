using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leadzum.Framework.Data.Migrations
{
    public partial class LeadzumFramework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventLogTypes",
                columns: table => new
                {
                    LogTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogCategory = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    FriendlyName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    LoggingIsActive = table.Column<bool>(nullable: false),
                    KeepMostRecent = table.Column<int>(nullable: true),
                    EmailNotificationIsActive = table.Column<bool>(nullable: true),
                    MailToAddress = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogTypes", x => x.LogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    EntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListName = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 100, nullable: false),
                    Text = table.Column<string>(maxLength: 256, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedByUserId = table.Column<int>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_Lists_Lists_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Lists",
                        principalColumn: "EntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    IconFile = table.Column<string>(maxLength: 100, nullable: true),
                    IsClickable = table.Column<bool>(nullable: false),
                    ViewOrder = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedByUserId = table.Column<int>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_Modules_Modules_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    RoleCode = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    UserCategory = table.Column<int>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedByUserId = table.Column<int>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    ConfigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfigCategory = table.Column<string>(maxLength: 100, nullable: false),
                    ConfigName = table.Column<string>(maxLength: 100, nullable: false),
                    DataType = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    ValidationExpression = table.Column<string>(maxLength: 1000, nullable: true),
                    DefaultValue = table.Column<string>(nullable: true),
                    ConfigValue = table.Column<string>(nullable: true),
                    ViewOrder = table.Column<int>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    LastModifiedByUserId = table.Column<int>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.ConfigId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 256, nullable: false),
                    UserTypeId = table.Column<int>(nullable: false),
                    PasswordChangeStatus = table.Column<int>(nullable: false),
                    IsAuthorized = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedByUserId = table.Column<int>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    EventLogId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogTypeId = table.Column<int>(nullable: false),
                    LogUserId = table.Column<int>(nullable: true),
                    LogUserName = table.Column<string>(maxLength: 256, nullable: true),
                    LogCreatedDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    LogMachineName = table.Column<string>(maxLength: 256, nullable: false),
                    LogDetail = table.Column<string>(nullable: false),
                    LogNotificationPending = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.EventLogId);
                    table.ForeignKey(
                        name: "FK_EventLogs_EventLogTypes_LogTypeId",
                        column: x => x.LogTypeId,
                        principalTable: "EventLogTypes",
                        principalColumn: "LogTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleId = table.Column<int>(nullable: false),
                    PermissionCode = table.Column<string>(maxLength: 50, nullable: true),
                    PermissionKey = table.Column<string>(maxLength: 50, nullable: false),
                    PermissionName = table.Column<string>(maxLength: 50, nullable: false),
                    IsConfigurable = table.Column<bool>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permissions_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RolePermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PermissionId = table.Column<int>(nullable: false),
                    AllowAccess = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()"),
                    LastModifiedByUserId = table.Column<int>(nullable: true),
                    LastModifiedOnDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EventLogTypes",
                columns: new[] { "LogTypeId", "Description", "EmailNotificationIsActive", "FriendlyName", "KeepMostRecent", "Key", "LogCategory", "LoggingIsActive", "MailToAddress" },
                values: new object[,]
                {
                    { 1, null, null, "User Login Success", null, "LOGIN_SUCCESS", 1, true, null },
                    { 2003, null, null, "Database Exception", null, "DB_EXCEPTION", 3, true, null },
                    { 2002, null, null, "Task Scheduler Exception", null, "TASK_SCHEDULER_EXCEPTION", 3, true, null },
                    { 2001, null, null, "Web Service Exception", null, "WEB_SERVICE_EXCEPTION", 3, true, null },
                    { 2000, null, null, "General Exception", null, "GENERAL_EXCEPTION", 3, true, null },
                    { 1000, null, null, "Task Scheduler Started", null, "TASK_SCHEDULER_START", 2, true, null },
                    { 18, null, null, "Module Deleted", null, "MODULE_DELETED", 1, true, null },
                    { 17, null, null, "Module Updated", null, "MODULE_REGISTERED", 1, true, null },
                    { 16, null, null, "New Module Created", null, "MODULE_CREATED", 1, true, null },
                    { 15, null, null, "Role Deleted", null, "ROLE_DELETED", 1, true, null },
                    { 14, null, null, "Role Updated", null, "ROLE_REGISTERED", 1, true, null },
                    { 13, null, null, "New Role Created", null, "ROLE_CREATED", 1, true, null },
                    { 1001, null, null, "Task Scheduler Stopped", null, "TASK_SCHEDULER_STOP", 2, true, null },
                    { 11, null, null, "User Removed", null, "USER_REMOVED", 1, true, null },
                    { 12, null, null, "User Password Changed", null, "USER_PSW_CHANGED", 1, true, null },
                    { 2, null, null, "User Login Failure", null, "LOGIN_FAILURE", 1, true, null },
                    { 3, null, null, "User Logout", null, "LOGOUT", 1, true, null },
                    { 5, null, null, "Data Synchronized", null, "DATA_SYNCED", 1, true, null },
                    { 4, null, null, "System Configuration Updated", null, "SYSTEM_CONFIG_UPDATED", 1, true, null },
                    { 7, null, null, "New User Registered", null, "USER_REGISTERED", 1, true, null },
                    { 8, null, null, "User Updated", null, "USER_UPDATED", 1, true, null },
                    { 9, null, null, "User Deleted", null, "USER_DELETED", 1, true, null },
                    { 10, null, null, "User Restored", null, "USER_RESTORED", 1, true, null },
                    { 6, null, null, "New User Created", null, "USER_CREATED", 1, true, null }
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "EntryId", "CreatedByUserId", "CreatedOnDate", "LastModifiedByUserId", "LastModifiedOnDate", "ListName", "ParentId", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 18, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2994), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2994), "ShortTimeFormat", null, 3, "HH:mm", "4" },
                    { 22, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3215), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3215), "DataType", null, 3, "Boolean", "3" },
                    { 19, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3100), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3100), "DataType", null, 0, "Undefined", "0" },
                    { 20, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3132), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3136), "DataType", null, 1, "Integer", "1" },
                    { 21, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3207), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3211), "DataType", null, 2, "Text", "2" },
                    { 23, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3219), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3223), "DataType", null, 4, "DateTime", "4" },
                    { 29, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3571), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3571), "LogCategory", null, 1, "SystemAdmin", "2" },
                    { 25, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3278), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3282), "LogCategory", null, 0, "Admin Log", "1" },
                    { 26, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3361), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3365), "LogCategory", null, 1, "Maintenance Log", "2" },
                    { 27, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3417), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3417), "LogCategory", null, 2, "Exception Log", "3" },
                    { 28, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3511), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3515), "LogCategory", null, 0, "WebServiceUser", "1" },
                    { 30, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3602), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3602), "LogCategory", null, 2, "SystemUser", "3" },
                    { 17, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2942), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2946), "ShortTimeFormat", null, 2, "H:mm", "3" },
                    { 24, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3227), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(3227), "DataType", null, 5, "Image", "5" },
                    { 16, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2895), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2895), "ShortTimeFormat", null, 1, "hh:mm tt", "2" },
                    { 13, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2579), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2579), "LongTimeFormat", null, 2, "H:mm:ss", "3" },
                    { 14, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2674), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2674), "LongTimeFormat", null, 3, "HH:mm:ss", "4" },
                    { 15, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2808), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2812), "ShortTimeFormat", null, 0, "h:mm tt", "1" },
                    { 12, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2528), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2528), "LongTimeFormat", null, 1, "hh:mm:ss tt", "2" },
                    { 11, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2421), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2421), "LongTimeFormat", null, 0, "h:mm:ss tt", "1" },
                    { 10, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2212), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2212), "DateFormat", null, 9, "dd-MMM-yyyy", "10" },
                    { 9, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2156), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2156), "DateFormat", null, 8, "dd MMM, yyyy", "9" },
                    { 8, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2109), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2109), "DateFormat", null, 7, "d MMM, yyyy", "8" },
                    { 7, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2057), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(2057), "DateFormat", null, 6, "dd/MM/yyyy", "7" },
                    { 6, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1998), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1998), "DateFormat", null, 5, "d/M/yyyy", "6" },
                    { 5, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1892), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1896), "DateFormat", null, 4, "MMM dd, yyyy", "5" },
                    { 4, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1836), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1840), "DateFormat", null, 3, "MMM d, yyyy", "4" },
                    { 3, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1777), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1777), "DateFormat", null, 2, "MM/dd/yyyy", "3" },
                    { 2, null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1615), null, new DateTime(2019, 6, 8, 20, 24, 43, 4, DateTimeKind.Local).AddTicks(1623), "DateFormat", null, 1, "M/d/yyyy", "2" },
                    { 1, null, new DateTime(2019, 6, 8, 20, 24, 43, 3, DateTimeKind.Local).AddTicks(6507), null, new DateTime(2019, 6, 8, 20, 24, 43, 3, DateTimeKind.Local).AddTicks(7166), "DateFormat", null, 0, "yyyy-MM-dd", "1" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Code", "CreatedByUserId", "CreatedOnDate", "Description", "IconFile", "IsClickable", "LastModifiedByUserId", "LastModifiedOnDate", "Name", "ParentId", "Type", "Url", "ViewOrder" },
                values: new object[,]
                {
                    { 2, "ADMIN_USER_AND_PERMISSIOIN", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3580), "User, role and permission management", "fa fa-users", false, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3587), "User & Permission", null, 1, "", 2 },
                    { 3, "ADMIN_SYSTEM", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3631), "System configuration", "fa fa-cogs", false, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3631), "System", null, 1, "", 3 },
                    { 1, "DASHBOARD", null, new DateTime(2019, 6, 8, 20, 24, 43, 10, DateTimeKind.Local).AddTicks(6491), "Dashboard", "fa fa-tachometer", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 10, DateTimeKind.Local).AddTicks(7120), "Dashboard", null, 1, "Home/Index", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedByUserId", "CreatedOnDate", "Description", "LastModifiedByUserId", "LastModifiedOnDate", "Name", "NormalizedName", "RoleCode", "UserCategory" },
                values: new object[,]
                {
                    { 101, "ad12519d-0c1f-4a61-93c7-df654d8e983a", null, new DateTime(2019, 6, 8, 20, 24, 42, 995, DateTimeKind.Local).AddTicks(8687), "Admin", null, new DateTime(2019, 6, 8, 20, 24, 42, 995, DateTimeKind.Local).AddTicks(8687), "Admin", null, "ADMIN", 2 },
                    { 100, "368ed497-4294-4058-82d1-154d60e1d0a8", null, new DateTime(2019, 6, 8, 20, 24, 42, 995, DateTimeKind.Local).AddTicks(8364), "Super Admin", null, new DateTime(2019, 6, 8, 20, 24, 42, 995, DateTimeKind.Local).AddTicks(8367), "Super Admin", null, "SUPER_ADMIN", 2 },
                    { 1, "079e0657-6e15-4083-a78c-710d4c613faf", null, new DateTime(2019, 6, 8, 20, 24, 42, 993, DateTimeKind.Local).AddTicks(4525), "Web Service Client", null, new DateTime(2019, 6, 8, 20, 24, 42, 994, DateTimeKind.Local).AddTicks(981), "Web Service Client", null, "SERVICE_CLIENT", 1 },
                    { 200, "9918143a-e079-4f6a-b20d-9cd8ec77aeba", null, new DateTime(2019, 6, 8, 20, 24, 42, 995, DateTimeKind.Local).AddTicks(8826), "Member", null, new DateTime(2019, 6, 8, 20, 24, 42, 995, DateTimeKind.Local).AddTicks(8826), "Member", null, "MEMBER", 3 }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "ConfigId", "ConfigCategory", "ConfigName", "ConfigValue", "DataType", "DefaultValue", "IsVisible", "LastModifiedByUserId", "LastModifiedOnDate", "Length", "ValidationExpression", "ViewOrder" },
                values: new object[,]
                {
                    { 5, "SYS_SMTP", "Port", "25", 1, "25", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3322), 0, null, 0 },
                    { 6, "SYS_SMTP", "RequireAuthentication", "False", 3, "False", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3330), 0, null, 0 },
                    { 7, "SYS_SMTP", "UserName", "", 2, "", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3330), 30, null, 0 },
                    { 3, "SYS_GENERAL", "LongTimeFormat", "HH:mm:ss", 2, "HH:mm:ss", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3318), 15, null, 0 },
                    { 9, "SYS_SMTP", "EnableSSL", "False", 2, "False", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3334), 0, null, 0 },
                    { 10, "SYS_SMTP", "MailFrom", "", 2, "", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3338), 30, null, 0 },
                    { 11, "SYS_SMTP", "DisplayName", "", 2, "", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3342), 30, null, 0 },
                    { 12, "SYS_SMTP", "Activated", "False", 3, "False", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3342), 0, null, 0 },
                    { 2, "SYS_GENERAL", "ShortTimeFormat", "HH:mm", 2, "HH:mm", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3278), 15, null, 0 },
                    { 1, "SYS_GENERAL", "DateFormat", "dd-MMM-yyyy", 2, "dd-MMM-yyyy", true, null, new DateTime(2019, 6, 8, 20, 24, 42, 999, DateTimeKind.Local).AddTicks(7368), 15, null, 0 },
                    { 4, "SYS_SMTP", "Server", "", 2, "", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3322), 30, null, 0 },
                    { 8, "SYS_SMTP", "Password", "", 2, "", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 0, DateTimeKind.Local).AddTicks(3334), 30, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedByUserId", "DisplayName", "Email", "EmailConfirmed", "IsAuthorized", "IsDeleted", "LastModifiedByUserId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordChangeStatus", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserTypeId" },
                values: new object[] { 1, 0, "42529d69-4914-493f-ab33-4c26551a56de", null, "Super Admin", "superadmin@mail.com", false, false, false, null, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", 0, "AQAAAAEAACcQAAAAEPhWm0uODTRr5IlIyi319vgw9L7KHJIV4N33MbYaTWkdtOUd0Drl2XM4wwmuOk2FLw==", null, false, "", false, "superadmin@mail.com", 0 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Code", "CreatedByUserId", "CreatedOnDate", "Description", "IconFile", "IsClickable", "LastModifiedByUserId", "LastModifiedOnDate", "Name", "ParentId", "Type", "Url", "ViewOrder" },
                values: new object[,]
                {
                    { 4, "ADMIN_USER_MANAGEMENT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3785), "User management", "fa fa-tachometer", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3785), "Users", 2, 1, "Admin/User/Index", 1 },
                    { 5, "ADMIN_ROLE_MANAGEMENT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3789), "Role management", "fa fa-users", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3789), "Roles", 2, 1, "Admin/Role/Index", 2 },
                    { 6, "ADMIN_PERMISSION_MANAGEMENT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3793), "Permission management", "fa fa-cogs", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3793), "Permissions", 2, 1, "Admin/Permission/Index", 3 },
                    { 7, "ADMIN_SYSTEM_CONFIG", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3903), "System configuration", "fa fa-tachometer", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3903), "Configuration", 3, 1, "Admin/System/Index", 1 },
                    { 8, "ADMIN_SYSTEM_MODULE", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3907), "System module management", "fa fa-users", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3907), "Modules", 3, 1, "Admin/Moudle/Index", 2 },
                    { 9, "ADMIN_SYSTEM_AUDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3907), "System audit logs", "fa fa-cogs", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3907), "Audit Logs", 3, 1, "Admin/Audit/Index", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 100 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Code", "CreatedByUserId", "CreatedOnDate", "Description", "IconFile", "IsClickable", "LastModifiedByUserId", "LastModifiedOnDate", "Name", "ParentId", "Type", "Url", "ViewOrder" },
                values: new object[,]
                {
                    { 14, "ACTION_USER_ADD", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3927), "Add User", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3927), "Add User", 4, 3, "Admin/User/Add", 1 },
                    { 15, "ACTION_USER_EDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3927), "Edit User", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3927), "Edit User", 4, 3, "Admin/User/Edit", 2 },
                    { 16, "ACTION_USER_DELETE", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3931), "Delete User", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3931), "Delete User", 4, 3, "Admin/User/Delete", 3 },
                    { 17, "ACTION_ROLE_ADD", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3935), "Add Role", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3935), "Add Role", 5, 3, "Admin/Role/Add", 1 },
                    { 18, "ACTION_ROLE_EDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3935), "Edit Role", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3935), "Edit Role", 5, 3, "Admin/Role/Edit", 2 },
                    { 19, "ACTION_ROLE_DELETE", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3939), "Delete Role", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3939), "Delete Role", 5, 3, "Admin/Role/Delete", 3 },
                    { 20, "ACTION_PERMISSION_ADD", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3943), "Add Permission", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3943), "Add Permission", 6, 3, "Admin/Permission/Add", 1 },
                    { 21, "ACTION_PERMISSION_EDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3943), "Edit Permission", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3943), "Edit Permission", 6, 3, "Admin/Permission/Edit", 2 },
                    { 22, "ACTION_PERMISSION_DELETE", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3947), "Delete Permission", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3947), "Delete Permission", 6, 3, "Admin/Permission/Delete", 3 },
                    { 10, "ADMIN_SYSTEM_GENERAL", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3911), "System general settings", "fa fa-tachometer", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3915), "General", 7, 1, "Admin/System/General", 1 },
                    { 11, "ADMIN_SYSTEM_ADVANCED", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3915), "System advanced settings", "fa fa-users", true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3915), "Advanced", 7, 1, "Admin/System/Advanced", 2 },
                    { 23, "ACTION_MODULE_ADD", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3947), "Add Module", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3951), "Add Module", 8, 3, "Admin/Module/Add", 1 },
                    { 24, "ACTION_MODULE_EDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3951), "Edit Module", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3951), "Edit Module", 8, 3, "Admin/Module/Edit", 2 },
                    { 25, "ACTION_MODULE_DELETE", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3955), "Delete Module", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3955), "Delete Module", 8, 3, "Admin/Module/Delete", 3 }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Code", "CreatedByUserId", "CreatedOnDate", "Description", "IconFile", "IsClickable", "LastModifiedByUserId", "LastModifiedOnDate", "Name", "ParentId", "Type", "Url", "ViewOrder" },
                values: new object[] { 12, "ACTION_SYSTEM_GENERAL_EDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3919), "Edit system general settings", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3919), "Edit", 10, 1, "Admin/System/GeneralEdit", 1 });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "ModuleId", "Code", "CreatedByUserId", "CreatedOnDate", "Description", "IconFile", "IsClickable", "LastModifiedByUserId", "LastModifiedOnDate", "Name", "ParentId", "Type", "Url", "ViewOrder" },
                values: new object[] { 13, "ACTION_SYSTEM_ADVANCED_EDIT", null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3923), "Edit system advanced settings", null, true, null, new DateTime(2019, 6, 8, 20, 24, 43, 11, DateTimeKind.Local).AddTicks(3923), "Edit", 11, 1, "Admin/System/AdvancedEdit", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_LogTypeId",
                table: "EventLogs",
                column: "LogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_ParentId",
                table: "Lists",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ParentId",
                table: "Modules",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ModuleId",
                table: "Permissions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_UserId",
                table: "RolePermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemConfigs_ConfigName",
                table: "SystemConfigs",
                column: "ConfigName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SystemConfigs");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "EventLogTypes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
