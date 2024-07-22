namespace DataManager.Models;

public class Human
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Description { get; set; }

    public Human(string name, string surname, string? description = null)
    {
        Name = name;
        Surname = surname;
        Description = description ?? string.Empty;
    }
}

