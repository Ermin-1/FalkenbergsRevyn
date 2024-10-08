﻿// <auto-generated />
using System;
using FalkenbergsRevyn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FalkenbergsRevyn.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241009083953_added identity roles")]
    partial class addedidentityroles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FalkenbergsRevyn.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAnswered")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            Category = "Positiva",
                            Content = "Fantastisk show! Helt klart den bästa jag sett.",
                            DatePosted = new DateTime(2024, 9, 10, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7100),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 2,
                            Category = "Positiva",
                            Content = "Musiken var så bra, vilken upplevelse!",
                            DatePosted = new DateTime(2024, 9, 10, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7103),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 3,
                            Category = "Kritik",
                            Content = "Tyvärr tyckte jag inte om skämten i showen.",
                            DatePosted = new DateTime(2024, 9, 11, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7105),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 4,
                            Category = "Kritik",
                            Content = "Belysningen var lite för stark under vissa delar.",
                            DatePosted = new DateTime(2024, 9, 11, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7107),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 5,
                            Category = "Positiva",
                            Content = "Fantastiskt avslut på kvällen, jag skrattade så mycket!",
                            DatePosted = new DateTime(2024, 9, 12, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7109),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 1
                        },
                        new
                        {
                            CommentId = 6,
                            Category = "Positiva",
                            Content = "Ser verkligen fram emot nästa års show!",
                            DatePosted = new DateTime(2024, 9, 15, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7110),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 7,
                            Category = "Kritik",
                            Content = "Jag hoppas att ni har bättre skämt nästa gång.",
                            DatePosted = new DateTime(2024, 9, 15, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7112),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 8,
                            Category = "Positiva",
                            Content = "Bra arrangemang, det märks att ni förbereder er i god tid.",
                            DatePosted = new DateTime(2024, 9, 16, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7115),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 9,
                            Category = "Kritik",
                            Content = "Ljudet var inte helt perfekt under vissa repetitioner.",
                            DatePosted = new DateTime(2024, 9, 16, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7117),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 10,
                            Category = "Positiva",
                            Content = "Ska definitivt köpa biljetter så snart de släpps!",
                            DatePosted = new DateTime(2024, 9, 17, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7118),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 2
                        },
                        new
                        {
                            CommentId = 11,
                            Category = "Positiva",
                            Content = "Mingelkvällen var så trevlig, bra jobbat!",
                            DatePosted = new DateTime(2024, 9, 20, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7120),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 12,
                            Category = "Kritik",
                            Content = "Lokalen var lite trång, men annars var det bra.",
                            DatePosted = new DateTime(2024, 9, 20, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7122),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 13,
                            Category = "Positiva",
                            Content = "Mingelmat och dryck var av högsta kvalitet!",
                            DatePosted = new DateTime(2024, 9, 21, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7124),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 14,
                            Category = "Kritik",
                            Content = "Skulle vara trevligt med fler sittplatser under minglet.",
                            DatePosted = new DateTime(2024, 9, 21, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7125),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 15,
                            Category = "Positiva",
                            Content = "Det var fantastiskt att träffa skådespelarna!",
                            DatePosted = new DateTime(2024, 9, 22, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7127),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 3
                        },
                        new
                        {
                            CommentId = 16,
                            Category = "Positiva",
                            Content = "Kostymerna ser otroligt vackra ut!",
                            DatePosted = new DateTime(2024, 9, 22, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7129),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 17,
                            Category = "Positiva",
                            Content = "Färgerna på kostymerna var fantastiska, snyggt jobbat!",
                            DatePosted = new DateTime(2024, 9, 23, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7130),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 18,
                            Category = "Kritik",
                            Content = "Några kostymer såg lite ofärdiga ut.",
                            DatePosted = new DateTime(2024, 9, 23, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7132),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 19,
                            Category = "Positiva",
                            Content = "Ser fram emot att se dem live på scenen!",
                            DatePosted = new DateTime(2024, 9, 24, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7134),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 20,
                            Category = "Kritik",
                            Content = "Är ni säkra på att alla kostymer är redo för premiären?",
                            DatePosted = new DateTime(2024, 9, 24, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7135),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 4
                        },
                        new
                        {
                            CommentId = 21,
                            Category = "Positiva",
                            Content = "Skådespelarna var lysande! Stort tack!",
                            DatePosted = new DateTime(2024, 9, 25, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7137),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 5
                        },
                        new
                        {
                            CommentId = 22,
                            Category = "Kritik",
                            Content = "Några av scenerna kändes lite utdragna.",
                            DatePosted = new DateTime(2024, 9, 25, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7139),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 5
                        },
                        new
                        {
                            CommentId = 23,
                            Category = "Positiva",
                            Content = "Älskade den nya skådespelaren, grym energi!",
                            DatePosted = new DateTime(2024, 9, 26, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7140),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 5
                        },
                        new
                        {
                            CommentId = 24,
                            Category = "Kritik",
                            Content = "Hoppas att ni förkortar vissa scener till nästa år.",
                            DatePosted = new DateTime(2024, 9, 26, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7143),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 5
                        },
                        new
                        {
                            CommentId = 25,
                            Category = "Positiva",
                            Content = "Perfekt dynamik mellan skådespelarna, fantastisk kemi!",
                            DatePosted = new DateTime(2024, 9, 27, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7145),
                            IsAnswered = false,
                            IsArchived = false,
                            PostId = 5
                        });
                });

            modelBuilder.Entity("FalkenbergsRevyn.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("PostId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Content = "En beskrivning av den senaste showen.",
                            DateCreated = new DateTime(2024, 9, 9, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6938),
                            Title = "Showen 2024 - Succé!"
                        },
                        new
                        {
                            PostId = 2,
                            Content = "Förberedelserna är i full gång inför nästa års show.",
                            DateCreated = new DateTime(2024, 9, 14, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6977),
                            Title = "Förberedelser inför Showen 2025"
                        },
                        new
                        {
                            PostId = 3,
                            Content = "En fantastisk kväll med mingel och underhållning.",
                            DateCreated = new DateTime(2024, 9, 19, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6980),
                            Title = "Mingelkväll på Falkenbergsrevyn"
                        },
                        new
                        {
                            PostId = 4,
                            Content = "En inblick i design och tillverkning av kostymerna.",
                            DateCreated = new DateTime(2024, 9, 21, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6982),
                            Title = "Kostymer för showen 2024"
                        },
                        new
                        {
                            PostId = 5,
                            Content = "Presentation av skådespelarna i årets show.",
                            DateCreated = new DateTime(2024, 9, 24, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6983),
                            Title = "Skådespelarna i årets show"
                        },
                        new
                        {
                            PostId = 6,
                            Content = "En exklusiv titt bakom kulisserna under scenbygget.",
                            DateCreated = new DateTime(2024, 9, 29, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6985),
                            Title = "Bakom kulisserna - Scenbygge"
                        },
                        new
                        {
                            PostId = 7,
                            Content = "Biljetter för nästa års show släpps nu.",
                            DateCreated = new DateTime(2024, 10, 4, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6987),
                            Title = "Biljettsläpp för Showen 2025"
                        },
                        new
                        {
                            PostId = 8,
                            Content = "En presentation av musikerna och låtarna i showen.",
                            DateCreated = new DateTime(2024, 10, 7, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6988),
                            Title = "Musiken i årets revy"
                        },
                        new
                        {
                            PostId = 9,
                            Content = "Hur skådespelarna håller humorn uppe under repetitionerna.",
                            DateCreated = new DateTime(2024, 10, 8, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6990),
                            Title = "Humor bakom kulisserna"
                        },
                        new
                        {
                            PostId = 10,
                            Content = "Recensioner och publikens åsikter om årets revy.",
                            DateCreated = new DateTime(2024, 10, 9, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6991),
                            Title = "Skrattfest på Falkenbergsrevyn"
                        },
                        new
                        {
                            PostId = 11,
                            Content = "En introduktion av en ny skådespelare i revyn.",
                            DateCreated = new DateTime(2024, 10, 2, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6993),
                            Title = "Ny medverkande i showen"
                        },
                        new
                        {
                            PostId = 12,
                            Content = "Information om årets huvudsponsorer.",
                            DateCreated = new DateTime(2024, 9, 27, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6994),
                            Title = "Sponsorer för årets show"
                        },
                        new
                        {
                            PostId = 13,
                            Content = "En guide till vad som serveras under revyn.",
                            DateCreated = new DateTime(2024, 9, 25, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6996),
                            Title = "Mat och dryck på revykvällarna"
                        },
                        new
                        {
                            PostId = 14,
                            Content = "En sammanfattning av publikens favoritmoment.",
                            DateCreated = new DateTime(2024, 10, 6, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6998),
                            Title = "Showens höjdpunkter"
                        },
                        new
                        {
                            PostId = 15,
                            Content = "Beskrivning av det storslagna avslutningsnumret i revyn.",
                            DateCreated = new DateTime(2024, 10, 8, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(6999),
                            Title = "Avslutningsnumret"
                        });
                });

            modelBuilder.Entity("FalkenbergsRevyn.Models.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseId"));

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateResponded")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponseContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResponseId");

                    b.HasIndex("CommentId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            ResponseId = 1,
                            CommentId = 3,
                            DateResponded = new DateTime(2024, 9, 12, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7171),
                            ResponseContent = "Tack för din feedback! Vi ser över skämten inför nästa show."
                        },
                        new
                        {
                            ResponseId = 2,
                            CommentId = 4,
                            DateResponded = new DateTime(2024, 9, 12, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7173),
                            ResponseContent = "Tack för att du påpekade det! Vi kommer att justera belysningen."
                        },
                        new
                        {
                            ResponseId = 3,
                            CommentId = 5,
                            DateResponded = new DateTime(2024, 9, 13, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7175),
                            ResponseContent = "Vi är glada att du gillade showen! Tack för ditt fina omdöme!"
                        },
                        new
                        {
                            ResponseId = 4,
                            CommentId = 9,
                            DateResponded = new DateTime(2024, 9, 16, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7177),
                            ResponseContent = "Nästa år satsar vi på ännu bättre ljud!"
                        },
                        new
                        {
                            ResponseId = 5,
                            CommentId = 10,
                            DateResponded = new DateTime(2024, 9, 17, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7178),
                            ResponseContent = "Vi ser fram emot att se dig nästa år! Biljetterna släpps snart."
                        },
                        new
                        {
                            ResponseId = 6,
                            CommentId = 11,
                            DateResponded = new DateTime(2024, 9, 21, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7180),
                            ResponseContent = "Kul att du trivdes på mingelkvällen! Tack för din feedback."
                        },
                        new
                        {
                            ResponseId = 7,
                            CommentId = 19,
                            DateResponded = new DateTime(2024, 9, 24, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7182),
                            ResponseContent = "Vi ser fram emot att du ser kostymerna live på scenen!"
                        },
                        new
                        {
                            ResponseId = 8,
                            CommentId = 22,
                            DateResponded = new DateTime(2024, 9, 27, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7203),
                            ResponseContent = "Vi håller koll på tidsramarna och ser över de utdragna scenerna."
                        },
                        new
                        {
                            ResponseId = 9,
                            CommentId = 23,
                            DateResponded = new DateTime(2024, 9, 27, 10, 39, 52, 945, DateTimeKind.Local).AddTicks(7205),
                            ResponseContent = "Tack för dina fina ord om våra skådespelare! Vi uppskattar det."
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FalkenbergsRevyn.Models.Comment", b =>
                {
                    b.HasOne("FalkenbergsRevyn.Models.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FalkenbergsRevyn.Models.Response", b =>
                {
                    b.HasOne("FalkenbergsRevyn.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FalkenbergsRevyn.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
