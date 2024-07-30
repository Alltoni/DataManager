using DataManager.Infrastructure;
using DataManager.Models;

namespace DataManager.Repositories.HumanRepositories;

public class HumanRepository : IHumanRepository
{
    public HumanRepository(DataManagerContext context)
    {
        _context = context;
    }

    private readonly DataManagerContext _context;

    public ICollection<Human> GetHumans() => _context.Humans.ToList();


    public Human AddHuman(Human human)
    {
        var humanList = GetHumans();

        humanList.Add(human);

        _context.Add(human);
        _context.SaveChanges();

        return human;
    }

    public Human GetHumanById(int id)
    {
        var humans = GetHumans();

        return humans.First(h => h.Id == id);
    }

    public Human? UpdateHuman(Human human)
    {
        var existingHuman = GetHumanById(human.Id);

        if (existingHuman == null)
            throw new ArgumentException(message: $"Human with this id  \"{human.Id}\" already exists.");

        existingHuman.Name = human.Name;
        existingHuman.Surname = human.Surname;
        existingHuman.Description = human.Description;

        _context.Update(existingHuman);
        _context.SaveChanges();

        return existingHuman;
    }

    public void DeleteHumanById(int id)
    {
        var human = GetHumanById(id);

        if (human == null)
            throw new ArgumentNullException(paramName: "id", message: $"There's no human with id: \"{id}\".");

        _context.Remove(human);
        _context.SaveChanges();
    }
}
