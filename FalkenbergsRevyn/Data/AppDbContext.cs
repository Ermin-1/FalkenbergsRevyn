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

            // Seed data for Comments using CreateComment method for automatic categorization
            //modelBuilder.Entity<Comment>().HasData(
            //    CreateComment(1, "Fantastisk show! Helt klart den bästa jag sett.", 1),
            //    CreateComment(2, "Musiken var så bra, vilken upplevelse!", 1),
            //    CreateComment(3, "Tyvärr tyckte jag inte om skämten i showen.", 1),
            //    CreateComment(4, "Belysningen var lite för stark under vissa delar.", 1),
            //    CreateComment(5, "Fantastiskt avslut på kvällen, jag skrattade så mycket!", 1),

            //    CreateComment(6, "Ser verkligen fram emot nästa års show!", 2),
            //    CreateComment(7, "Jag hoppas att ni har bättre skämt nästa gång.", 2),
            //    CreateComment(8, "Bra arrangemang, det märks att ni förbereder er i god tid.", 2),
            //    CreateComment(9, "Ljudet var inte helt perfekt under vissa repetitioner.", 2),
            //    CreateComment(10, "Ska definitivt köpa biljetter så snart de släpps!", 2),

            //    CreateComment(11, "Mingelkvällen var så trevlig, bra jobbat!", 3),
            //    CreateComment(12, "Lokalen var lite trång, men annars var det bra.", 3),
            //    CreateComment(13, "Mingelmat och dryck var av högsta kvalitet!", 3),
            //    CreateComment(14, "Skulle vara trevligt med fler sittplatser under minglet.", 3),
            //    CreateComment(15, "Det var fantastiskt att träffa skådespelarna!", 3),

            //    CreateComment(16, "Kostymerna ser otroligt vackra ut!", 4),
            //    CreateComment(17, "Färgerna på kostymerna var fantastiska, snyggt jobbat!", 4),
            //    CreateComment(18, "Några kostymer såg lite ofärdiga ut.", 4),
            //    CreateComment(19, "Ser fram emot att se dem live på scenen!", 4),
            //    CreateComment(20, "Är ni säkra på att alla kostymer är redo för premiären?", 4),

            //    CreateComment(21, "Skådespelarna var lysande! Stort tack!", 5),
            //    CreateComment(22, "Några av scenerna kändes lite utdragna.", 5),
            //    CreateComment(23, "Älskade den nya skådespelaren, grym energi!", 5),
            //    CreateComment(24, "Hoppas att ni förkortar vissa scener till nästa år.", 5),
            //    CreateComment(25, "Perfekt dynamik mellan skådespelarna, fantastisk kemi!", 5)
            //);
            modelBuilder.Entity<Comment>().HasData(
    new Comment
    {
        CommentId = 1,
        Content = "Fantastisk show! Helt klart den bästa jag sett.",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-10 14:17:54.9827208"),
        IsArchived = false,
        PostId = 1
    },
    new Comment
    {
        CommentId = 2,
        Content = "Musiken var så bra, vilken upplevelse!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-10 14:17:54.9827211"),
        IsArchived = false,
        PostId = 1
    },
    new Comment
    {
        CommentId = 4,
        Content = "Belysningen var lite för stark under vissa delar.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-11 14:17:54.9827215"),
        IsArchived = false,
        PostId = 1
    },
    new Comment
    {
        CommentId = 6,
        Content = "Ser verkligen fram emot nästa års show!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-15 14:17:54.9827219"),
        IsArchived = false,
        PostId = 2
    },
    new Comment
    {
        CommentId = 7,
        Content = "Jag hoppas att ni har bättre skämt nästa gång.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-15 14:17:54.9827220"),
        IsArchived = false,
        PostId = 2
    },
    new Comment
    {
        CommentId = 8,
        Content = "Bra arrangemang, det märks att ni förbereder er i god tid.",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-16 14:17:54.9827222"),
        IsArchived = false,
        PostId = 2
    },
    new Comment
    {
        CommentId = 9,
        Content = "Ljudet var inte helt perfekt under vissa repetitioner.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-16 14:17:54.9827224"),
        IsArchived = false,
        PostId = 2
    },
    new Comment
    {
        CommentId = 10,
        Content = "Ska definitivt köpa biljetter så snart de släpps!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-17 14:17:54.9827226"),
        IsArchived = false,
        PostId = 2
    },
    new Comment
    {
        CommentId = 11,
        Content = "Mingelkvällen var så trevlig, bra jobbat!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-20 14:17:54.9827227"),
        IsArchived = false,
        PostId = 3
    },
    new Comment
    {
        CommentId = 12,
        Content = "Lokalen var lite trång, men annars var det bra.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-20 14:17:54.9827229"),
        IsArchived = false,
        PostId = 3
    },
    new Comment
    {
        CommentId = 13,
        Content = "Mingelmat och dryck var av högsta kvalitet!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-21 14:17:54.9827231"),
        IsArchived = false,
        PostId = 3
    },
    new Comment
    {
        CommentId = 14,
        Content = "Skulle vara trevligt med fler sittplatser under minglet.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-21 14:17:54.9827232"),
        IsArchived = false,
        PostId = 3
    },
    new Comment
    {
        CommentId = 15,
        Content = "Det var fantastiskt att träffa skådespelarna!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-22 14:17:54.9827234"),
        IsArchived = false,
        PostId = 3
    },
    new Comment
    {
        CommentId = 16,
        Content = "Kostymerna ser otroligt vackra ut!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-22 14:17:54.9827236"),
        IsArchived = false,
        PostId = 4
    },
    new Comment
    {
        CommentId = 17,
        Content = "Färgerna på kostymerna var fantastiska, snyggt jobbat!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-23 14:17:54.9827237"),
        IsArchived = false,
        PostId = 4
    },
    new Comment
    {
        CommentId = 18,
        Content = "Några kostymer såg lite ofärdiga ut.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-23 14:17:54.9827240"),
        IsArchived = false,
        PostId = 4
    },
    new Comment
    {
        CommentId = 19,
        Content = "Ser fram emot att se dem live på scenen!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-24 14:17:54.9827241"),
        IsArchived = false,
        PostId = 4
    },
    new Comment
    {
        CommentId = 20,
        Content = "Är ni säkra på att alla kostymer är redo för premiären?",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-24 14:17:54.9827243"),
        IsArchived = false,
        PostId = 4
    },
    new Comment
    {
        CommentId = 21,
        Content = "Skådespelarna var lysande! Stort tack!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-25 14:17:54.9827245"),
        IsArchived = false,
        PostId = 5
    },
    new Comment
    {
        CommentId = 22,
        Content = "Några av scenerna kändes lite utdragna.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-25 14:17:54.9827246"),
        IsArchived = false,
        PostId = 5
    },
    new Comment
    {
        CommentId = 23,
        Content = "Älskade den nya skådespelaren, grym energi!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-26 14:17:54.9827248"),
        IsArchived = false,
        PostId = 5
    },
    new Comment
    {
        CommentId = 24,
        Content = "Hoppas att ni förkortar vissa scener till nästa år.",
        Category = "Kritik",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-26 14:17:54.9827249"),
        IsArchived = false,
        PostId = 5
    },
    new Comment
    {
        CommentId = 25,
        Content = "Perfekt dynamik mellan skådespelarna, fantastisk kemi!",
        Category = "Positiva",
        IsAnswered = false,
        DatePosted = DateTime.Parse("2024-09-27 14:17:54.9827251"),
        IsArchived = false,
        PostId = 5
    });


           
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
