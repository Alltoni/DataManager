using DataManager.Infrastructure;
using DataManager.Models;

namespace DataManager.Repositories;

public class HumanRepository : IHumanRepository
{
    public HumanRepository(DataManagerContext context)
    {
        _context = context;
    }

    private readonly List<Human> _humans = new List<Human>();
    private readonly DataManagerContext _context;

    //[Obsolete]
    //public ICollection<Human> GetHumans()
    //    => _humans;

    //[Obsolete]
    //public Human AddHuman(Human human)
    //{
    //    _humans.Add(human);

    //    return human;
    //}

    [Obsolete]
    public void DeleteHumanById(int id)
    {
        var human = GetHumanById(id);

        if (human != null)
        {
            _humans.Remove(human);
        }
    }

    //[Obsolete]
    //public Human GetHumanById(int id)
    //{
    //    //Przeczytaj i usuń (alternatywa zapisu LINQ
    //    var result = (from h in _humans
    //                  where h.Id == id
    //                  select h).FirstOrDefault();

    //    // TODO: ta wartość może być nullem
    //    return _humans.FirstOrDefault(h => h.Id == id);
    //}

    //[Obsolete]
    //public Human? UpdateHuman(Human human)
    //{
    //    var existingHuman = GetHumanById(human.Id);

    //    if (existingHuman == null)
    //        throw new ArgumentException(message: $"Human with this id  \"{human.Id}\" already exists.");

    //    existingHuman.Name = human.Name;
    //    existingHuman.Surname = human.Surname;
    //    existingHuman.Description = human.Description;

    //    return existingHuman;
    //}

    public ICollection<Human> GetHumans() => _context.Humans.ToList();

    public Human AddHuman(Human human)
    {
        var humanList = GetHumans();

        humanList.Add(human);
        _context.SaveChanges();

        return human;
    }

    public Human GetHumanById(int id)
    {
        var humans = GetHumans();

        var result = (from h in humans
                      where h.Id == id
                      select h).First();

        return result;
    }

    public Human? UpdateHuman(Human human)
    {
        var existingHuman = GetHumanById(human.Id);

        if (existingHuman == null)
            throw new ArgumentException(message: $"Human with this id  \"{human.Id}\" already exists.");

        existingHuman.Name = human.Name;
        existingHuman.Surname = human.Surname;
        existingHuman.Description = human.Description;

        _context.SaveChanges();

        return existingHuman;
    }
}
