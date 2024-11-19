using _06_demo_basicauth_asp.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _06_demo_basicauth_asp.Services
{
    public class BeerService : IBeerService
    {
        string path = @"C:\Users\Miguel\Desktop\practicas-csharp\06-demo-basicauth-asp\06-demo-basicauth-asp\beers.json";

        public async Task<List<Beer>> Get()
        {
            string content = await File.ReadAllTextAsync(path);
            var beers = JsonSerializer.Deserialize<List<Beer>>(content);
            return beers;
        }
    }
}
