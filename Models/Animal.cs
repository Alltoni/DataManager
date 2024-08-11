using System.Net.Http;
using Newtonsoft.Json;


namespace DataManager.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public List<string> Locations { get; set; }
        public Characteristics Characteristics { get; set; }
    }

    public class Taxonomy
        {
        public string Kingdom { get; set; }
        public string Phylum { get; set; }
        public string Class { get; set; }
        public string Order { get; set; }
        public string Family { get; set; }
        public string Genus { get; set; }

        [JsonProperty(propertyName: "scientific_name")]
        public string ScientificName { get; set; }
        }

    public class Characteristics
    {
        [JsonProperty(propertyName: "main_prey")]
        public string Prey { get; set; }

        [JsonProperty(propertyName: "name_of_young")]
        public string NameOfYoung { get; set; }

        [JsonProperty(propertyName: "group_behavior")]
        public string GroupBehavior { get; set; }
        public string EstimatedPopulationSize { get; set; }
        public string BiggestThreat { get; set; }
        public string MostDistinctiveFeature { get; set; }
        public string GestationPeriod { get; set; }
        public string Habitat { get; set; }
        public string Diet { get; set; }
        public string AverageLitterSize { get; set; }
        public string Lifestyle { get; set; }
        public string CommonName { get; set; }
        public string NumberOfSpecies { get; set; }
        public string Location { get; set; }
        public string Slogan { get; set; }
        public string Group { get; set; }
        public string Color { get; set; }

        [JsonProperty(propertyName: "skin_type")]
        public string SkinType { get; set; }
        public string TopSpeed { get; set; }
        public string Lifespan { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string AgeOfSexualMaturity { get; set; }
        public string AgeOfWeaning { get; set; }
    }
}
