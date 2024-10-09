using FalkenbergsRevyn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenAI.Chat;
using System.ClientModel;
using System.Diagnostics;

namespace FalkenbergsRevyn.Controllers
{
    public class OpenAIController : Controller
    {
        private readonly ILogger<OpenAIController> _logger;

        public OpenAIController(ILogger<OpenAIController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOpenAI")]
        public async Task<IActionResult> GetOpenAI()
        {
            var model = new OpenAIViewModel();

            try
            {
                var apiKey = "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";
                ChatClient client = new(apiKey: apiKey, model: "gpt-4");

                var chatCompletion = await client.CompleteChatAsync("Say, This as a test");

                // Set the response in the model
                model.Response = chatCompletion.Value.ToString();

                // Return the Index view with the model
                return View("Index", model);
            }
            catch (ClientResultException ex) when (ex.Message.Contains("insufficient_quota"))
            {
                _logger.LogError(ex, "Insufficient quota in OpenAI API");
                return View("Error", "You have insufficient quota to make this request. Please check your OpenAI account.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling OpenAI API");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }


    }
}
