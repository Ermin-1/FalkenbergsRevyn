using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FalkenbergsRevyn.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswered = table.Column<bool>(type: "bit", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateResponded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Responses_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "DateCreated", "Title" },
                values: new object[,]
                {
                    { 1, "En beskrivning av den senaste showen.", new DateTime(2024, 9, 14, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9419), "Showen 2024 - Succé!" },
                    { 2, "Förberedelserna är i full gång inför nästa års show.", new DateTime(2024, 9, 19, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9462), "Förberedelser inför Showen 2025" },
                    { 3, "En fantastisk kväll med mingel och underhållning.", new DateTime(2024, 9, 24, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9465), "Mingelkväll på Falkenbergsrevyn" },
                    { 4, "En inblick i design och tillverkning av kostymerna.", new DateTime(2024, 9, 26, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9466), "Kostymer för showen 2024" },
                    { 5, "Presentation av skådespelarna i årets show.", new DateTime(2024, 9, 29, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9468), "Skådespelarna i årets show" },
                    { 6, "En exklusiv titt bakom kulisserna under scenbygget.", new DateTime(2024, 10, 4, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9470), "Bakom kulisserna - Scenbygge" },
                    { 7, "Biljetter för nästa års show släpps nu.", new DateTime(2024, 10, 9, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9471), "Biljettsläpp för Showen 2025" },
                    { 8, "En presentation av musikerna och låtarna i showen.", new DateTime(2024, 10, 12, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9473), "Musiken i årets revy" },
                    { 9, "Hur skådespelarna håller humorn uppe under repetitionerna.", new DateTime(2024, 10, 13, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9475), "Humor bakom kulisserna" },
                    { 10, "Recensioner och publikens åsikter om årets revy.", new DateTime(2024, 10, 14, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9476), "Skrattfest på Falkenbergsrevyn" },
                    { 11, "En introduktion av en ny skådespelare i revyn.", new DateTime(2024, 10, 7, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9478), "Ny medverkande i showen" },
                    { 12, "Information om årets huvudsponsorer.", new DateTime(2024, 10, 2, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9480), "Sponsorer för årets show" },
                    { 13, "En guide till vad som serveras under revyn.", new DateTime(2024, 9, 30, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9481), "Mat och dryck på revykvällarna" },
                    { 14, "En sammanfattning av publikens favoritmoment.", new DateTime(2024, 10, 11, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9483), "Showens höjdpunkter" },
                    { 15, "Beskrivning av det storslagna avslutningsnumret i revyn.", new DateTime(2024, 10, 13, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9485), "Avslutningsnumret" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Category", "Content", "DatePosted", "IsAnswered", "IsArchived", "PostId" },
                values: new object[,]
                {
                    { 1, "Positiv", "Fantastisk show! Helt klart den bästa jag sett.", new DateTime(2024, 9, 15, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9653), false, false, 1 },
                    { 2, "Positiv", "Musiken var så bra, vilken upplevelse!", new DateTime(2024, 9, 16, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9671), false, false, 1 },
                    { 3, "Negativ", "Tyvärr tyckte jag inte om skämten i showen.", new DateTime(2024, 9, 17, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9726), false, false, 1 },
                    { 4, "Negativ", "Belysningen var lite för stark under vissa delar.", new DateTime(2024, 9, 18, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9739), false, false, 1 },
                    { 5, "Positiv", "Fantastiskt avslut på kvällen, jag skrattade så mycket!", new DateTime(2024, 9, 19, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9753), false, false, 1 },
                    { 6, "Positiv", "Ser verkligen fram emot nästa års show!", new DateTime(2024, 9, 20, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9823), false, false, 2 },
                    { 7, "Övrigt", "Jag hoppas att ni har bättre skämt nästa gång.", new DateTime(2024, 9, 21, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9885), false, false, 2 },
                    { 8, "Positiv", "Bra arrangemang, det märks att ni förbereder er i god tid.", new DateTime(2024, 9, 22, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9899), false, false, 2 },
                    { 9, "Övrigt", "Ljudet var inte helt perfekt under vissa repetitioner.", new DateTime(2024, 9, 23, 11, 6, 3, 253, DateTimeKind.Local).AddTicks(9994), false, false, 2 },
                    { 10, "Övrigt", "Ska definitivt köpa biljetter så snart de släpps!", new DateTime(2024, 9, 24, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(57), false, false, 2 },
                    { 11, "Positiv", "Mingelkvällen var så trevlig, bra jobbat!", new DateTime(2024, 9, 25, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(70), false, false, 3 },
                    { 12, "Negativ", "Lokalen var lite trång, men annars var det bra.", new DateTime(2024, 9, 26, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(128), false, false, 3 },
                    { 13, "Övrigt", "Mingelmat och dryck var av högsta kvalitet!", new DateTime(2024, 9, 27, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(187), false, false, 3 },
                    { 14, "Positiv", "Skulle vara trevligt med fler sittplatser under minglet.", new DateTime(2024, 9, 28, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(204), false, false, 3 },
                    { 15, "Positiv", "Det var fantastiskt att träffa skådespelarna!", new DateTime(2024, 9, 29, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(259), false, false, 3 },
                    { 16, "Positiv", "Kostymerna ser otroligt vackra ut!", new DateTime(2024, 9, 30, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(304), false, false, 4 },
                    { 17, "Positiv", "Färgerna på kostymerna var fantastiska, snyggt jobbat!", new DateTime(2024, 10, 1, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(317), false, false, 4 },
                    { 18, "Negativ", "Några kostymer såg lite ofärdiga ut.", new DateTime(2024, 10, 2, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(348), false, false, 4 },
                    { 19, "Positiv", "Ser fram emot att se dem live på scenen!", new DateTime(2024, 10, 3, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(393), false, false, 4 },
                    { 20, "Fråga", "Är ni säkra på att alla kostymer är redo för premiären?", new DateTime(2024, 10, 4, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(403), false, false, 4 },
                    { 21, "Övrigt", "Skådespelarna var lysande! Stort tack!", new DateTime(2024, 10, 5, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(456), false, false, 5 },
                    { 22, "Övrigt", "Några av scenerna kändes lite utdragna.", new DateTime(2024, 10, 6, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(559), false, false, 5 },
                    { 23, "Positiv", "Älskade den nya skådespelaren, grym energi!", new DateTime(2024, 10, 7, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(574), false, false, 5 },
                    { 24, "Övrigt", "Hoppas att ni förkortar vissa scener till nästa år.", new DateTime(2024, 10, 8, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(635), false, false, 5 },
                    { 25, "Positiv", "Perfekt dynamik mellan skådespelarna, fantastisk kemi!", new DateTime(2024, 10, 9, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(670), false, false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ResponseId", "CommentId", "DateResponded", "ResponseContent" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 9, 17, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(705), "Tack för din feedback! Vi ser över skämten inför nästa show." },
                    { 2, 4, new DateTime(2024, 9, 17, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(708), "Tack för att du påpekade det! Vi kommer att justera belysningen." },
                    { 3, 5, new DateTime(2024, 9, 18, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(710), "Vi är glada att du gillade showen! Tack för ditt fina omdöme!" },
                    { 4, 9, new DateTime(2024, 9, 21, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(712), "Nästa år satsar vi på ännu bättre ljud!" },
                    { 5, 10, new DateTime(2024, 9, 22, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(713), "Vi ser fram emot att se dig nästa år! Biljetterna släpps snart." },
                    { 6, 11, new DateTime(2024, 9, 26, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(715), "Kul att du trivdes på mingelkvällen! Tack för din feedback." },
                    { 7, 19, new DateTime(2024, 9, 29, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(717), "Vi ser fram emot att du ser kostymerna live på scenen!" },
                    { 8, 22, new DateTime(2024, 10, 2, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(718), "Vi håller koll på tidsramarna och ser över de utdragna scenerna." },
                    { 9, 23, new DateTime(2024, 10, 2, 11, 6, 3, 254, DateTimeKind.Local).AddTicks(720), "Tack för dina fina ord om våra skådespelare! Vi uppskattar det." }
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
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CommentId",
                table: "Responses",
                column: "CommentId");
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
                name: "Responses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
