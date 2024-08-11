using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Services.AnimalServices
{
    public interface IAnimalService
    {

        Task<Animal?> GetAnimalByName(string name);
        Task<Taxonomy?> GetAnimalTaxonomy(string name);
        Task<Characteristics?> GetAnimalCharacteristics(string name);

    }
}
