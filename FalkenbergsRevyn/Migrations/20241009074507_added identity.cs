using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalkenbergsRevyn.Migrations
{
    /// <inheritdoc />
    public partial class addedidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 9, 10, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 9, 10, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 9, 11, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "DatePosted",
                value: new DateTime(2024, 9, 11, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "DatePosted",
                value: new DateTime(2024, 9, 12, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 6,
                column: "DatePosted",
                value: new DateTime(2024, 9, 15, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 7,
                column: "DatePosted",
                value: new DateTime(2024, 9, 15, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 8,
                column: "DatePosted",
                value: new DateTime(2024, 9, 16, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 9,
                column: "DatePosted",
                value: new DateTime(2024, 9, 16, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 10,
                column: "DatePosted",
                value: new DateTime(2024, 9, 17, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 11,
                column: "DatePosted",
                value: new DateTime(2024, 9, 20, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 12,
                column: "DatePosted",
                value: new DateTime(2024, 9, 20, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 13,
                column: "DatePosted",
                value: new DateTime(2024, 9, 21, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 14,
                column: "DatePosted",
                value: new DateTime(2024, 9, 21, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 15,
                column: "DatePosted",
                value: new DateTime(2024, 9, 22, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 16,
                column: "DatePosted",
                value: new DateTime(2024, 9, 22, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 17,
                column: "DatePosted",
                value: new DateTime(2024, 9, 23, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 18,
                column: "DatePosted",
                value: new DateTime(2024, 9, 23, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 19,
                column: "DatePosted",
                value: new DateTime(2024, 9, 24, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 20,
                column: "DatePosted",
                value: new DateTime(2024, 9, 24, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6440));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 21,
                column: "DatePosted",
                value: new DateTime(2024, 9, 25, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 22,
                column: "DatePosted",
                value: new DateTime(2024, 9, 25, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 23,
                column: "DatePosted",
                value: new DateTime(2024, 9, 26, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6446));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 24,
                column: "DatePosted",
                value: new DateTime(2024, 9, 26, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 25,
                column: "DatePosted",
                value: new DateTime(2024, 9, 27, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 9, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 14, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 19, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 21, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 24, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 9, 29, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 10, 4, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 10, 7, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 10, 8, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 10, 9, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2024, 10, 2, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2024, 9, 27, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2024, 9, 25, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2024, 10, 6, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2024, 10, 8, 9, 45, 6, 467, DateTimeKind.Local).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 1,
                column: "DateResponded",
                value: new DateTime(2024, 9, 12, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 2,
                column: "DateResponded",
                value: new DateTime(2024, 9, 12, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 3,
                column: "DateResponded",
                value: new DateTime(2024, 9, 13, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 4,
                column: "DateResponded",
                value: new DateTime(2024, 9, 16, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 5,
                column: "DateResponded",
                value: new DateTime(2024, 9, 17, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 6,
                column: "DateResponded",
                value: new DateTime(2024, 9, 21, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 7,
                column: "DateResponded",
                value: new DateTime(2024, 9, 24, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 8,
                column: "DateResponded",
                value: new DateTime(2024, 9, 27, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 9,
                column: "DateResponded",
                value: new DateTime(2024, 9, 27, 9, 45, 6, 469, DateTimeKind.Local).AddTicks(3073));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "DatePosted",
                value: new DateTime(2024, 9, 8, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "DatePosted",
                value: new DateTime(2024, 9, 8, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3,
                column: "DatePosted",
                value: new DateTime(2024, 9, 9, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4,
                column: "DatePosted",
                value: new DateTime(2024, 9, 9, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5,
                column: "DatePosted",
                value: new DateTime(2024, 9, 10, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 6,
                column: "DatePosted",
                value: new DateTime(2024, 9, 13, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 7,
                column: "DatePosted",
                value: new DateTime(2024, 9, 13, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 8,
                column: "DatePosted",
                value: new DateTime(2024, 9, 14, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 9,
                column: "DatePosted",
                value: new DateTime(2024, 9, 14, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 10,
                column: "DatePosted",
                value: new DateTime(2024, 9, 15, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 11,
                column: "DatePosted",
                value: new DateTime(2024, 9, 18, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 12,
                column: "DatePosted",
                value: new DateTime(2024, 9, 18, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 13,
                column: "DatePosted",
                value: new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 14,
                column: "DatePosted",
                value: new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 15,
                column: "DatePosted",
                value: new DateTime(2024, 9, 20, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 16,
                column: "DatePosted",
                value: new DateTime(2024, 9, 20, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 17,
                column: "DatePosted",
                value: new DateTime(2024, 9, 21, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 18,
                column: "DatePosted",
                value: new DateTime(2024, 9, 21, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 19,
                column: "DatePosted",
                value: new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 20,
                column: "DatePosted",
                value: new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 21,
                column: "DatePosted",
                value: new DateTime(2024, 9, 23, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 22,
                column: "DatePosted",
                value: new DateTime(2024, 9, 23, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 23,
                column: "DatePosted",
                value: new DateTime(2024, 9, 24, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 24,
                column: "DatePosted",
                value: new DateTime(2024, 9, 24, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 25,
                column: "DatePosted",
                value: new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 9, 7, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 9, 12, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 9, 17, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 9, 27, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 10, 2, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2024, 10, 5, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2024, 10, 6, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2024, 10, 7, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2024, 9, 30, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 12,
                column: "DateCreated",
                value: new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 13,
                column: "DateCreated",
                value: new DateTime(2024, 9, 23, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 14,
                column: "DateCreated",
                value: new DateTime(2024, 10, 4, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 15,
                column: "DateCreated",
                value: new DateTime(2024, 10, 6, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 1,
                column: "DateResponded",
                value: new DateTime(2024, 9, 10, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 2,
                column: "DateResponded",
                value: new DateTime(2024, 9, 10, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 3,
                column: "DateResponded",
                value: new DateTime(2024, 9, 11, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 4,
                column: "DateResponded",
                value: new DateTime(2024, 9, 14, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 5,
                column: "DateResponded",
                value: new DateTime(2024, 9, 15, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 6,
                column: "DateResponded",
                value: new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 7,
                column: "DateResponded",
                value: new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 8,
                column: "DateResponded",
                value: new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Responses",
                keyColumn: "ResponseId",
                keyValue: 9,
                column: "DateResponded",
                value: new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3844));
        }
    }
}
