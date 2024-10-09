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
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
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
                    { 1, "En beskrivning av den senaste showen.", new DateTime(2024, 9, 7, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3579), "Showen 2024 - Succé!" },
                    { 2, "Förberedelserna är i full gång inför nästa års show.", new DateTime(2024, 9, 12, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3646), "Förberedelser inför Showen 2025" },
                    { 3, "En fantastisk kväll med mingel och underhållning.", new DateTime(2024, 9, 17, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3650), "Mingelkväll på Falkenbergsrevyn" },
                    { 4, "En inblick i design och tillverkning av kostymerna.", new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3652), "Kostymer för showen 2024" },
                    { 5, "Presentation av skådespelarna i årets show.", new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3653), "Skådespelarna i årets show" },
                    { 6, "En exklusiv titt bakom kulisserna under scenbygget.", new DateTime(2024, 9, 27, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3655), "Bakom kulisserna - Scenbygge" },
                    { 7, "Biljetter för nästa års show släpps nu.", new DateTime(2024, 10, 2, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3657), "Biljettsläpp för Showen 2025" },
                    { 8, "En presentation av musikerna och låtarna i showen.", new DateTime(2024, 10, 5, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3658), "Musiken i årets revy" },
                    { 9, "Hur skådespelarna håller humorn uppe under repetitionerna.", new DateTime(2024, 10, 6, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3660), "Humor bakom kulisserna" },
                    { 10, "Recensioner och publikens åsikter om årets revy.", new DateTime(2024, 10, 7, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3662), "Skrattfest på Falkenbergsrevyn" },
                    { 11, "En introduktion av en ny skådespelare i revyn.", new DateTime(2024, 9, 30, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3663), "Ny medverkande i showen" },
                    { 12, "Information om årets huvudsponsorer.", new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3665), "Sponsorer för årets show" },
                    { 13, "En guide till vad som serveras under revyn.", new DateTime(2024, 9, 23, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3666), "Mat och dryck på revykvällarna" },
                    { 14, "En sammanfattning av publikens favoritmoment.", new DateTime(2024, 10, 4, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3668), "Showens höjdpunkter" },
                    { 15, "Beskrivning av det storslagna avslutningsnumret i revyn.", new DateTime(2024, 10, 6, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3669), "Avslutningsnumret" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Category", "Content", "DatePosted", "IsAnswered", "IsArchived", "PostId" },
                values: new object[,]
                {
                    { 1, "Positiva", "Fantastisk show! Helt klart den bästa jag sett.", new DateTime(2024, 9, 8, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3761), false, false, 1 },
                    { 2, "Positiva", "Musiken var så bra, vilken upplevelse!", new DateTime(2024, 9, 8, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3764), false, false, 1 },
                    { 3, "Kritik", "Tyvärr tyckte jag inte om skämten i showen.", new DateTime(2024, 9, 9, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3766), false, false, 1 },
                    { 4, "Kritik", "Belysningen var lite för stark under vissa delar.", new DateTime(2024, 9, 9, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3768), false, false, 1 },
                    { 5, "Positiva", "Fantastiskt avslut på kvällen, jag skrattade så mycket!", new DateTime(2024, 9, 10, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3769), false, false, 1 },
                    { 6, "Positiva", "Ser verkligen fram emot nästa års show!", new DateTime(2024, 9, 13, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3771), false, false, 2 },
                    { 7, "Kritik", "Jag hoppas att ni har bättre skämt nästa gång.", new DateTime(2024, 9, 13, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3773), false, false, 2 },
                    { 8, "Positiva", "Bra arrangemang, det märks att ni förbereder er i god tid.", new DateTime(2024, 9, 14, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3776), false, false, 2 },
                    { 9, "Kritik", "Ljudet var inte helt perfekt under vissa repetitioner.", new DateTime(2024, 9, 14, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3777), false, false, 2 },
                    { 10, "Positiva", "Ska definitivt köpa biljetter så snart de släpps!", new DateTime(2024, 9, 15, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3779), false, false, 2 },
                    { 11, "Positiva", "Mingelkvällen var så trevlig, bra jobbat!", new DateTime(2024, 9, 18, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3781), false, false, 3 },
                    { 12, "Kritik", "Lokalen var lite trång, men annars var det bra.", new DateTime(2024, 9, 18, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3783), false, false, 3 },
                    { 13, "Positiva", "Mingelmat och dryck var av högsta kvalitet!", new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3784), false, false, 3 },
                    { 14, "Kritik", "Skulle vara trevligt med fler sittplatser under minglet.", new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3786), false, false, 3 },
                    { 15, "Positiva", "Det var fantastiskt att träffa skådespelarna!", new DateTime(2024, 9, 20, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3788), false, false, 3 },
                    { 16, "Positiva", "Kostymerna ser otroligt vackra ut!", new DateTime(2024, 9, 20, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3790), false, false, 4 },
                    { 17, "Positiva", "Färgerna på kostymerna var fantastiska, snyggt jobbat!", new DateTime(2024, 9, 21, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3792), false, false, 4 },
                    { 18, "Kritik", "Några kostymer såg lite ofärdiga ut.", new DateTime(2024, 9, 21, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3794), false, false, 4 },
                    { 19, "Positiva", "Ser fram emot att se dem live på scenen!", new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3795), false, false, 4 },
                    { 20, "Kritik", "Är ni säkra på att alla kostymer är redo för premiären?", new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3797), false, false, 4 },
                    { 21, "Positiva", "Skådespelarna var lysande! Stort tack!", new DateTime(2024, 9, 23, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3799), false, false, 5 },
                    { 22, "Kritik", "Några av scenerna kändes lite utdragna.", new DateTime(2024, 9, 23, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3800), false, false, 5 },
                    { 23, "Positiva", "Älskade den nya skådespelaren, grym energi!", new DateTime(2024, 9, 24, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3802), false, false, 5 },
                    { 24, "Kritik", "Hoppas att ni förkortar vissa scener till nästa år.", new DateTime(2024, 9, 24, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3804), false, false, 5 },
                    { 25, "Positiva", "Perfekt dynamik mellan skådespelarna, fantastisk kemi!", new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3806), false, false, 5 }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ResponseId", "CommentId", "DateResponded", "ResponseContent" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 9, 10, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3831), "Tack för din feedback! Vi ser över skämten inför nästa show." },
                    { 2, 4, new DateTime(2024, 9, 10, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3833), "Tack för att du påpekade det! Vi kommer att justera belysningen." },
                    { 3, 5, new DateTime(2024, 9, 11, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3835), "Vi är glada att du gillade showen! Tack för ditt fina omdöme!" },
                    { 4, 9, new DateTime(2024, 9, 14, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3836), "Nästa år satsar vi på ännu bättre ljud!" },
                    { 5, 10, new DateTime(2024, 9, 15, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3838), "Vi ser fram emot att se dig nästa år! Biljetterna släpps snart." },
                    { 6, 11, new DateTime(2024, 9, 19, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3840), "Kul att du trivdes på mingelkvällen! Tack för din feedback." },
                    { 7, 19, new DateTime(2024, 9, 22, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3841), "Vi ser fram emot att du ser kostymerna live på scenen!" },
                    { 8, 22, new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3843), "Vi håller koll på tidsramarna och ser över de utdragna scenerna." },
                    { 9, 23, new DateTime(2024, 9, 25, 13, 48, 15, 544, DateTimeKind.Local).AddTicks(3844), "Tack för dina fina ord om våra skådespelare! Vi uppskattar det." }
                });

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
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
