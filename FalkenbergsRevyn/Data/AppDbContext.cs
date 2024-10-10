using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FalkenbergsRevyn.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Response>().ToTable("Responses");

            // Seed data for Posts
            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = 1, Title = "Showen 2024 - Succé!", Content = "En beskrivning av den senaste showen.", DateCreated = DateTime.Now.AddDays(-30) },
                new Post { PostId = 2, Title = "Förberedelser inför Showen 2025", Content = "Förberedelserna är i full gång inför nästa års show.", DateCreated = DateTime.Now.AddDays(-25) },
                new Post { PostId = 3, Title = "Mingelkväll på Falkenbergsrevyn", Content = "En fantastisk kväll med mingel och underhållning.", DateCreated = DateTime.Now.AddDays(-20) },
                new Post { PostId = 4, Title = "Kostymer för showen 2024", Content = "En inblick i design och tillverkning av kostymerna.", DateCreated = DateTime.Now.AddDays(-18) },
                new Post { PostId = 5, Title = "Skådespelarna i årets show", Content = "Presentation av skådespelarna i årets show.", DateCreated = DateTime.Now.AddDays(-15) },
                new Post { PostId = 6, Title = "Bakom kulisserna - Scenbygge", Content = "En exklusiv titt bakom kulisserna under scenbygget.", DateCreated = DateTime.Now.AddDays(-10) },
                new Post { PostId = 7, Title = "Biljettsläpp för Showen 2025", Content = "Biljetter för nästa års show släpps nu.", DateCreated = DateTime.Now.AddDays(-5) },
                new Post { PostId = 8, Title = "Musiken i årets revy", Content = "En presentation av musikerna och låtarna i showen.", DateCreated = DateTime.Now.AddDays(-2) },
                new Post { PostId = 9, Title = "Humor bakom kulisserna", Content = "Hur skådespelarna håller humorn uppe under repetitionerna.", DateCreated = DateTime.Now.AddDays(-1) },
                new Post { PostId = 10, Title = "Skrattfest på Falkenbergsrevyn", Content = "Recensioner och publikens åsikter om årets revy.", DateCreated = DateTime.Now },
                new Post { PostId = 11, Title = "Ny medverkande i showen", Content = "En introduktion av en ny skådespelare i revyn.", DateCreated = DateTime.Now.AddDays(-7) },
                new Post { PostId = 12, Title = "Sponsorer för årets show", Content = "Information om årets huvudsponsorer.", DateCreated = DateTime.Now.AddDays(-12) },
                new Post { PostId = 13, Title = "Mat och dryck på revykvällarna", Content = "En guide till vad som serveras under revyn.", DateCreated = DateTime.Now.AddDays(-14) },
                new Post { PostId = 14, Title = "Showens höjdpunkter", Content = "En sammanfattning av publikens favoritmoment.", DateCreated = DateTime.Now.AddDays(-3) },
                new Post { PostId = 15, Title = "Avslutningsnumret", Content = "Beskrivning av det storslagna avslutningsnumret i revyn.", DateCreated = DateTime.Now.AddDays(-1) }
            );

            // Seed data for Comments
            modelBuilder.Entity<Comment>().HasData(
                // Comments for Post 1
                new Comment { CommentId = 1, Content = "Fantastisk show! Helt klart den bästa jag sett.", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-29), PostId = 1 },
                new Comment { CommentId = 2, Content = "Musiken var så bra, vilken upplevelse!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-29), PostId = 1 },
                new Comment { CommentId = 3, Content = "Tyvärr tyckte jag inte om skämten i showen.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-28), PostId = 1 },
                new Comment { CommentId = 4, Content = "Belysningen var lite för stark under vissa delar.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-28), PostId = 1 },
                new Comment { CommentId = 5, Content = "Fantastiskt avslut på kvällen, jag skrattade så mycket!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-27), PostId = 1 },

                // Comments for Post 2
                new Comment { CommentId = 6, Content = "Ser verkligen fram emot nästa års show!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-24), PostId = 2 },
                new Comment { CommentId = 7, Content = "Jag hoppas att ni har bättre skämt nästa gång.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-24), PostId = 2 },
                new Comment { CommentId = 8, Content = "Bra arrangemang, det märks att ni förbereder er i god tid.", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-23), PostId = 2 },
                new Comment { CommentId = 9, Content = "Ljudet var inte helt perfekt under vissa repetitioner.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-23), PostId = 2 },
                new Comment { CommentId = 10, Content = "Ska definitivt köpa biljetter så snart de släpps!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-22), PostId = 2 },

                // Comments for Post 3
                new Comment { CommentId = 11, Content = "Mingelkvällen var så trevlig, bra jobbat!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-19), PostId = 3 },
                new Comment { CommentId = 12, Content = "Lokalen var lite trång, men annars var det bra.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-19), PostId = 3 },
                new Comment { CommentId = 13, Content = "Mingelmat och dryck var av högsta kvalitet!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-18), PostId = 3 },
                new Comment { CommentId = 14, Content = "Skulle vara trevligt med fler sittplatser under minglet.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-18), PostId = 3 },
                new Comment { CommentId = 15, Content = "Det var fantastiskt att träffa skådespelarna!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-17), PostId = 3 },

                // Comments for Post 4
                new Comment { CommentId = 16, Content = "Kostymerna ser otroligt vackra ut!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-17), PostId = 4 },
                new Comment { CommentId = 17, Content = "Färgerna på kostymerna var fantastiska, snyggt jobbat!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-16), PostId = 4 },
                new Comment { CommentId = 18, Content = "Några kostymer såg lite ofärdiga ut.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-16), PostId = 4 },
                new Comment { CommentId = 19, Content = "Ser fram emot att se dem live på scenen!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-15), PostId = 4 },
                new Comment { CommentId = 20, Content = "Är ni säkra på att alla kostymer är redo för premiären?", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-15), PostId = 4 },

                // Comments for Post 5
                new Comment { CommentId = 21, Content = "Skådespelarna var lysande! Stort tack!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-14), PostId = 5 },
                new Comment { CommentId = 22, Content = "Några av scenerna kändes lite utdragna.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-14), PostId = 5 },
                new Comment { CommentId = 23, Content = "Älskade den nya skådespelaren, grym energi!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-13), PostId = 5 },
                new Comment { CommentId = 24, Content = "Hoppas att ni förkortar vissa scener till nästa år.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-13), PostId = 5 },
                new Comment { CommentId = 25, Content = "Perfekt dynamik mellan skådespelarna, fantastisk kemi!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Now.AddDays(-12), PostId = 5 }
            );

            // Seed data for Responses
            modelBuilder.Entity<Response>().HasData(
                new Response { ResponseId = 1, ResponseContent = "Tack för din feedback! Vi ser över skämten inför nästa show.", DateResponded = DateTime.Now.AddDays(-27), CommentId = 3 },
                new Response { ResponseId = 2, ResponseContent = "Tack för att du påpekade det! Vi kommer att justera belysningen.", DateResponded = DateTime.Now.AddDays(-27), CommentId = 4 },
                new Response { ResponseId = 3, ResponseContent = "Vi är glada att du gillade showen! Tack för ditt fina omdöme!", DateResponded = DateTime.Now.AddDays(-26), CommentId = 5 },
                new Response { ResponseId = 4, ResponseContent = "Nästa år satsar vi på ännu bättre ljud!", DateResponded = DateTime.Now.AddDays(-23), CommentId = 9 },
                new Response { ResponseId = 5, ResponseContent = "Vi ser fram emot att se dig nästa år! Biljetterna släpps snart.", DateResponded = DateTime.Now.AddDays(-22), CommentId = 10 },
                new Response { ResponseId = 6, ResponseContent = "Kul att du trivdes på mingelkvällen! Tack för din feedback.", DateResponded = DateTime.Now.AddDays(-18), CommentId = 11 },
                new Response { ResponseId = 7, ResponseContent = "Vi ser fram emot att du ser kostymerna live på scenen!", DateResponded = DateTime.Now.AddDays(-15), CommentId = 19 },
                new Response { ResponseId = 8, ResponseContent = "Vi håller koll på tidsramarna och ser över de utdragna scenerna.", DateResponded = DateTime.Now.AddDays(-12), CommentId = 22 },
                new Response { ResponseId = 9, ResponseContent = "Tack för dina fina ord om våra skådespelare! Vi uppskattar det.", DateResponded = DateTime.Now.AddDays(-12), CommentId = 23 }
            );
        }
    }
}
