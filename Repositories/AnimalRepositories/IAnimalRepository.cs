using DataManager.Enums;
using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Repositories.AnimalRepositories
{
    public interface IAnimalRepository
    {
        Task<Animal?> GetAnimalByName(string name);


    }
}
