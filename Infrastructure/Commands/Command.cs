using System;
using System.Windows.Input;

namespace BankApp.Infrastructure.Commands
{
    public abstract class Command : ICommand
    {
        public abstract void Execute(object parameter);

        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}