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


        public async Task AnimalScan(string animalName)
        {
            try
            {
                var animalData = await GetAnimalData(animalName);


                foreach (var animal in animalData)
                {
                    Console.WriteLine($"Animal: {animal.Name}");
                    Console.WriteLine($"Scientific Name: {animal.Taxonomy.ScientificName}");
                    Console.WriteLine($"Class: {animal.Taxonomy.Class}");
                    Console.WriteLine($"Habitat: {animal.Characteristics.Habitat}");
                    break;
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
