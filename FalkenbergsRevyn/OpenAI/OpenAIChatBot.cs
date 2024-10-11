using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;

namespace FalkenbergsRevyn.OpenAI
{
    public class OpenAIChatBot
    {

        private readonly AppDbContext _context;
        private readonly string _apiKey;
        private readonly string _model;

        public OpenAIChatBot(AppDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _apiKey = configuration["OpenAI:ApiKey"];
            _model = configuration["OpenAI:Model"];
        }

        public async Task ProcessComments(Comment comment)
        {
            try
            {
                ChatClient client = new(model: _model, apiKey: _apiKey);

                if (comment.Category == "Positiva")
                {
                    var textToBeAnswered = string.Join("", comment.Content);

                    // Send the input to ChatGPT and retrieve the response
                    var completion = await client.CompleteChatAsync(textToBeAnswered);

                    // Process the response and store the answers in the database
                    var answers = completion.ToString();

                    // Store the answer in the database
                    _context.Responses.Add(new Response { ResponseContent = answers, DateResponded = DateTime.Now, CommentId = comment.CommentId });

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while processing comment: {ex.Message}");
            }
        }

    }
}