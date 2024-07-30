using DataManager.Models;
using DataManager.Repositories.HumanRepositories;

namespace DataManager.Services.HumanServices;

public class HumanService : IHumanService
{
    private readonly IHumanRepository _repository;

    public HumanService(IHumanRepository repository)
        => _repository = repository;

    public Human AddHuman(Human human)
    {
        if (human == null)
            throw new ArgumentNullException(nameof(human));

        if (string.IsNullOrWhiteSpace(human.Name))
            throw new ArgumentException(message: $"Name cannot be empty");

        if (string.IsNullOrEmpty(human.Surname))
            throw new ArgumentException(message: $"Surname cannot be empty.");

        return _repository.AddHuman(human);
    }

    public void DeleteHumanById(int id)
        => _repository.DeleteHumanById(id);

    public Human GetHumanById(int id)
        => _repository.GetHumanById(id);

    public ICollection<Human> GetHumans()
        => _repository.GetHumans();

    public Human UpdateHuman(Human human)
        => _repository.UpdateHuman(human);

    public void ClearHumans()
    {
        var humans = _repository.GetHumans().ToList();

        foreach (var human in humans)
        {
            _repository.DeleteHumanById(human.Id);
        }
    }
}