using System.Net.Http;
using Newtonsoft.Json;

namespace DataManager.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public string Taxonomy { get; set; }
        public string Characteristics { get; set; }
        public string Location { get; set; }
    }
}
