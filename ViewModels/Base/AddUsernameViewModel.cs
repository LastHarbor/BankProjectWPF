using System.Windows.Input;
using BankApp.Infrastructure.Commands;
using BankApp.Models;

namespace BankApp.ViewModels.Base;

public class AddUserNameViewModel
{
    private string _username;

    public string Username
    {
        get => _username; 
        set => _username = value;
    }

    #region Добавление имени пользхователя


    #endregion
    public ICommand AddUsernameCommand { get; }
    private void OnAddUsernameCommand(object p)
    {
        if (MainWindowViewModel.SEmploye == "Менеджер")
        {
            WorkSpaceWindowViewModel.Managers.Add(new User(Username, MainWindowViewModel.SEmploye));
        }
        else if (MainWindowViewModel.SEmploye == "Консультант")
        {
            WorkSpaceWindowViewModel.Consultants.Add(new User(Username, MainWindowViewModel.SEmploye));
        }
    }
    private bool CanAddUsernameCommand(object p) => true;
    public AddUserNameViewModel()
    {
        AddUsernameCommand = new LambdaCommand(OnAddUsernameCommand, CanAddUsernameCommand);
    }
}
