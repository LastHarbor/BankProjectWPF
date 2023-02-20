using System.Collections.Generic;

namespace BankApp.Models;

public class Consultant : User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Client> Clients { get; set; }
    public int PositionId { get; set; }


    public Consultant(string name, string position) : base(name, position)
    {

    }
}