using System.Collections.Generic;

namespace BankApp.Models;

internal class Manager : User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Client> Clients { get; set; }
    public int PositionId { get; set; }

    public Manager(string name, string position) : base(name, position)
    {
    }
}