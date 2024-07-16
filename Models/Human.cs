﻿namespace DataManager.Models;

public class Human
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Description { get; set; }

    public Human(int id, string name, string surname, string? description = null)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Description = description ?? string.Empty;
    }
}

