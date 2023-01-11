using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.View.Windows;

namespace BankApp.ViewModels.Base
{
    public class MainWindowViewModel : ViewModel
    {
        #region Title

        private string _title = "Банк";

        public string Title
        {
            get => _title;
            set => SetField(ref _title, _title = value);
        }

        #endregion
        #region OpenNewWindowCommand
        public ICommand OpenNewWindowCommand { get; }

        private void OnOpenNewWindowCommandExecute(object p)
        {
            Workspace ws = new Workspace();
            ws.Show();
            Application.Current.MainWindow?.Close();
        }

        private bool CanOpenNewWindowCommandExecute(object p) => true;

        #endregion 

        #region ComboBoxItems
        private ObservableCollection<string> _Employes;
        private static string sEmploye;

        public ObservableCollection<string> Employes
        {
            get => _Employes;
            set => _Employes = value;
        }
        public static string SEmploye
        {
            get => sEmploye;
            set => sEmploye = value;
        }


        #endregion

        #region Commands

        public MainWindowViewModel()
        {
            OpenNewWindowCommand = new LambdaCommand(OnOpenNewWindowCommandExecute, CanOpenNewWindowCommandExecute);
            Employes = new ObservableCollection<string>() { "Менеджер", "Консультант" };
        }
        #endregion
    }
}