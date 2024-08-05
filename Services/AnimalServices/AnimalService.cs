using System;
using System.Net.Http;
using System.Threading.Tasks;
using DataManager.Models;
using Newtonsoft.Json;


namespace DataManager.Services.AnimalServices
{
    public class AnimalService
    {
        public static readonly HttpClient client = new HttpClient();
        public const string apiKey = "zp81RtZ0/jhnqn0eJNtHXA==9hcY4Bqg0H03FcTL";
        public const string apiUrl = "https://api.api-ninjas.com/v1/animals";


        public static async Task AnimalScan(string[] args)
        {
            try
            {
                string animalName = "cheetah";
                var animalData = await GetAnimalData(animalName);

                // ScientificName nie dziala ale to chyba wina api bo reszta dziala

                foreach (var animal in animalData)
                {
                    Console.WriteLine($"Animal: {animal.Name}");
                    Console.WriteLine($"Scientific Name: {animal.Taxonomy.ScientificName}");
                    Console.WriteLine($"Class: {animal.Taxonomy.Class}");
                    Console.WriteLine($"Habitat: {animal.Characteristics.Habitat}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd: {e.Message}");
            }
        }

        public static async Task<List<Animal>> GetAnimalData(string animalName)
        {
            client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

            var response = await client.GetAsync($"{apiUrl}?name={animalName}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Animal>>(responseString);
        }
    }
}
