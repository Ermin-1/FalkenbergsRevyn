using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

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

            // Seed data for Comments using CreateComment method for automatic categorization
            modelBuilder.Entity<Comment>().HasData(
                CreateComment(1, "Fantastisk show! Helt klart den bästa jag sett.", 1),
                CreateComment(2, "Musiken var så bra, vilken upplevelse!", 1),
                CreateComment(3, "Tyvärr tyckte jag inte om skämten i showen.", 1),
                CreateComment(4, "Belysningen var lite för stark under vissa delar.", 1),
                CreateComment(5, "Fantastiskt avslut på kvällen, jag skrattade så mycket!", 1),

                CreateComment(6, "Ser verkligen fram emot nästa års show!", 2),
                CreateComment(7, "Jag hoppas att ni har bättre skämt nästa gång.", 2),
                CreateComment(8, "Bra arrangemang, det märks att ni förbereder er i god tid.", 2),
                CreateComment(9, "Ljudet var inte helt perfekt under vissa repetitioner.", 2),
                CreateComment(10, "Ska definitivt köpa biljetter så snart de släpps!", 2),

                CreateComment(11, "Mingelkvällen var så trevlig, bra jobbat!", 3),
                CreateComment(12, "Lokalen var lite trång, men annars var det bra.", 3),
                CreateComment(13, "Mingelmat och dryck var av högsta kvalitet!", 3),
                CreateComment(14, "Skulle vara trevligt med fler sittplatser under minglet.", 3),
                CreateComment(15, "Det var fantastiskt att träffa skådespelarna!", 3),

                CreateComment(16, "Kostymerna ser otroligt vackra ut!", 4),
                CreateComment(17, "Färgerna på kostymerna var fantastiska, snyggt jobbat!", 4),
                CreateComment(18, "Några kostymer såg lite ofärdiga ut.", 4),
                CreateComment(19, "Ser fram emot att se dem live på scenen!", 4),
                CreateComment(20, "Är ni säkra på att alla kostymer är redo för premiären?", 4),

                CreateComment(21, "Skådespelarna var lysande! Stort tack!", 5),
                CreateComment(22, "Några av scenerna kändes lite utdragna.", 5),
                CreateComment(23, "Älskade den nya skådespelaren, grym energi!", 5),
                CreateComment(24, "Hoppas att ni förkortar vissa scener till nästa år.", 5),
                CreateComment(25, "Perfekt dynamik mellan skådespelarna, fantastisk kemi!", 5)
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
        private static Comment CreateComment(int id, string content, int postId)
        {
            return new Comment
            {
                CommentId = id,
                Content = content,
                Category = CommentCategorizer.CategorizeComment(content),
                IsAnswered = false,
                DatePosted = DateTime.Now.AddDays(-30 + id),
                PostId = postId
            };
        }
    }
    // Kategoriseringsklass för kommentarer
    public static class CommentCategorizer
    {
        public static string CategorizeComment(string content)
        {
            var negativeKeywords = new List<string> { "tyvärr", "inte bra", "ofärdiga", "trång", "för stark", "för högt" };
            var questionKeywords = new List<string> { "är ni säkra", "kommer ni att", "kan ni", "ska ni", "varför" };
            var positiveKeywords = new List<string> {"fantastisk", "bra", "grym", "älskade", "trevlig", "lyckad", "jättebra", "Lycka", "lyckatill", "bäst", "❤️", "🤩", "skratt", "skrattar", "gott", "guld", "längtar",
            "guld kant", "mycket skratt", "längtar redan", "ha det gott", "världssuccé", "härligt gäng", "bokad", "premiären", "hjärtligt grattis", "lycka till", "bäst", "kram", "grattis","bokat","😁", "🌝", "kul",
                "😎", "😃", "🤗", "😉", "😂", "👍", "💫", "💎", "✨", "💜", "💞", "🙏", "🎶", "🌅", "💯", "☘️", "🌤", "🎵", "🎸", "🎤", "🎹", "🌼", "💃🏾", "👏", "fram emot","vi har bokat", "vi kommer", "fram mot",
                "🥰","fixat", "fram i mot", "framemot", "🎉", "💖", "framemot", "roligt", "❤", "😊", "beundransvärda", "kör hårt", "flitiga","rekommendera","yay", "proffsig", "länktar", "ska vi bara se", "🌹", "hurra", "fröjd", "länktar", 
            };


            // Kontrollera om det finns ett frågetecken - klassas direkt som "Fråga" om sant
            if (content.Contains("?"))
            {
                return "Fråga";
            }

            // Prioritet 1: Kontrollera negativa nyckelord först
            foreach (var keyword in negativeKeywords)
            {
                if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Negativ";
                }
            }

            // Prioritet 2: Kontrollera frågor utifrån nyckelord
            foreach (var keyword in questionKeywords)
            {
                if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Fråga";
                }
            }

            // Prioritet 3: Kontrollera positiva nyckelord sist
            foreach (var keyword in positiveKeywords)
            {
                if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Positiv";
                }
            }

            // Om ingen matchning, returnera "Övrigt"
            return "Övrigt";
        }
    }


}
