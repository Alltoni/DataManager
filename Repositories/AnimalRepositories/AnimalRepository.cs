using DataManager.Infrastructure;
using DataManager.Models;
using Newtonsoft.Json;


namespace DataManager.Repositories.AnimalRepositories
{
    public class AnimalRepository : IAnimalRepository
    {
        public static readonly HttpClient client = new HttpClient();
        public const string apiKey = "zp81RtZ0/jhnqn0eJNtHXA==9hcY4Bqg0H03FcTL";
        public const string apiUrl = "https://api.api-ninjas.com/v1/animals";

        private readonly DataManagerContext _context;

        public AnimalRepository(DataManagerContext context)
        {
            _context = context;

        }

        public async Task<Animal?> GetAnimalByName(string animalName)
        {
            if (!client.DefaultRequestHeaders.Contains("X-Api-Key"))
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
            }

            var response = await client.GetAsync($"{apiUrl}?name={animalName}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var animals = JsonConvert.DeserializeObject<List<Animal>>(responseString);

            return animals?.FirstOrDefault();
        }
    }


}

