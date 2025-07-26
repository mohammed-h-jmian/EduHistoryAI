using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.GoogleGeminiServices
{
    public class GoogleGeminiService : IGoogleGeminiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyDXe-cFdVIbi4lN6vVhYqgQdwsHuR5adAY";
        private readonly string _apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key=";

        public GoogleGeminiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateContentAsync(string userMessage)
        {
            var payload = new
            {
                contents = new[]
                {
                new
                {
                    role = "user",
                    parts = new[]
                    {
                        new { text = userMessage }
                    }
                }
            }
            };

            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl + _apiKey, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);

            var result = doc.RootElement
                            .GetProperty("candidates")[0]
                            .GetProperty("content")
                            .GetProperty("parts")[0]
                            .GetProperty("text")
                            .GetString();

            return result;
        }
    }
}
