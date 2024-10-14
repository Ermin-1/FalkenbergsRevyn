using FalkenbergsRevyn.Data;
using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OpenAI.Chat;  // Ensure this is the correct namespace for the chat functionality
using System.Text.Json;

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
                // Initialize the OpenAI client with the provided model and API key
                var client = new ChatClient( apiKey: _apiKey, model : _model );

                if (comment.Category == "Positiva")
                {
                    var textToBeAnswered = comment.Content;

                    // Assuming the method is called CompleteAsync or something similar
                    var completion = await client.CompleteChatAsync(textToBeAnswered);

                    var rawResponse = completion.GetRawResponse().Content.ToString();

                    using (JsonDocument doc = JsonDocument.Parse(rawResponse))
                    {
                        var root = doc.RootElement;

                        // Navigate the JSON structure to get the first "content" field
                        var answer = root.GetProperty("choices")[0]
                                         .GetProperty("message")
                                         .GetProperty("content")
                                         .GetString();

                        // Store the extracted answer in the database
                        _context.Responses.Add(new Response
                        {
                            ResponseContent = answer,
                            DateResponded = DateTime.Now,
                            CommentId = comment.CommentId
                        });

                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while processing the comment: {ex.Message}");
            }
        }
    }
}
