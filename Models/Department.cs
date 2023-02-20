using System.Collections.Generic;
using System.Collections.ObjectModel;
using BankApp.ViewModels.Base;

namespace BankApp.Models;

public class Department
{
    public static string Name { get; set; }
    public List<string> Positions { get; set; }

    public Department(string name)
    {
        Positions = new List<string>();
        foreach (var emp in MainWindowViewModel.Employes)
        {
            Positions!.Add(emp);
        }
        Name = name;
    }

}



