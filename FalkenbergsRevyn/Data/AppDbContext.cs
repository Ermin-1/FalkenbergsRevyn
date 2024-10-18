using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

            // Definiera tabellerna
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Response>().ToTable("Responses");

            // Konfigurera relationen mellan Comments och Responses
            modelBuilder.Entity<Comment>()
                .HasMany(c => c.Responses)
                .WithOne(r => r.Comment)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

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
                new Comment { CommentId = 1, Content = "Fantastisk show! Helt klart den bästa jag sett.", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Parse("2024-09-10"), IsArchived = false, PostId = 1 },
                new Comment { CommentId = 3, Content = "Mingelmat och dryck var av högsta kvalitet!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Parse("2024-09-21"), IsArchived = false, PostId = 3 },
                new Comment { CommentId = 5, Content = "Skådespelarna var lysande! Stort tack!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Parse("2024-09-25"), IsArchived = false, PostId = 5 },
                new Comment { CommentId = 19, Content = "Ser fram emot att se dem live på scenen!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Parse("2024-09-24"), IsArchived = false, PostId = 4 },
                new Comment { CommentId = 22, Content = "Några av scenerna kändes lite utdragna.", Category = "Kritik", IsAnswered = false, DatePosted = DateTime.Parse("2024-09-25"), IsArchived = false, PostId = 5 },
                new Comment { CommentId = 23, Content = "Älskade den nya skådespelaren, grym energi!", Category = "Positiva", IsAnswered = false, DatePosted = DateTime.Parse("2024-09-26"), IsArchived = false, PostId = 5 }
            );

            // Seed data for Responses
            modelBuilder.Entity<Response>().HasData(
                new Response { ResponseId = 1, ResponseContent = "Tack för din feedback! Vi ser över skämten inför nästa show.", DateResponded = DateTime.Now.AddDays(-27), CommentId = 3 },
            
                new Response { ResponseId = 3, ResponseContent = "Vi är glada att du gillade showen! Tack för ditt fina omdöme!", DateResponded = DateTime.Now.AddDays(-26), CommentId = 5 },
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
                "🥰","fixat", "fram i mot", "framemot", "🎉", "💖", "framemot", "roligt", "rolig", "roliga", "❤", "😊", "beundransvärda", "kör hårt", "flitiga","rekommendera","yay", "proffsig", "länktar", "ska vi bara se", "🌹", "hurra", "fröjd", "länktar",
            };

            if (content.Contains("?"))
            {
                return "Fråga";
            }

            foreach (var keyword in negativeKeywords)
            {
                if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Negativ";
                }
            }

            foreach (var keyword in questionKeywords)
            {
                if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Fråga";
                }
            }

            foreach (var keyword in positiveKeywords)
            {
                if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return "Positiva";
                }
            }

            return "Övrigt";
        }
    }
}
