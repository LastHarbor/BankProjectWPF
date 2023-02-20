using System.Collections.Generic;

namespace BankApp.Models;

public class User
{
    public string Name { get; set; }
    public string Position { get; set; }


    public User(string name, string position)
    {
        Name = name;
        Position = position;
    }
}