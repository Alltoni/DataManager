using DataManager.Models;

namespace DataManager.Repositories;

public class HumanRepository : IHumanRepository
{
    private readonly List<Human> _humans = new List<Human>();

    public ICollection<Human> GetHumans()
        => _humans;

    public Human AddHuman(Human human)
    {
        _humans.Add(human);

        return human;
    }

    public void DeleteHumanById(int id)
    {
        var human = GetHumanById(id);

        if (human != null)
        {
            _humans.Remove(human);
        }
    }

    public Human GetHumanById(int id)
    {
        //Przeczytaj i usuń (alternatywa zapisu LINQ
        var result = (from h in _humans
                      where h.Id == id
                      select h).FirstOrDefault();

        // TODO: ta wartość może być nullem
        return _humans.FirstOrDefault(h => h.Id == id);
    }

    public Human? UpdateHuman(Human human)
    {
        var existingHuman = GetHumanById(human.Id);

        if (existingHuman == null)
            throw new ArgumentException(message: $"Human with this id  \"{human.Id}\" already exists.");

        existingHuman.Name = human.Name;
        existingHuman.Surname = human.Surname;
        existingHuman.Description = human.Description;

        return existingHuman;
    }
}


