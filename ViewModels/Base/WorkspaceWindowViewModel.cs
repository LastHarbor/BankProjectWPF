using BankApp.View.Windows;

namespace BankApp.ViewModels.Base
{
    public class WorkSpaceWindowViewModel : ViewModel
    {
        string _sEmploye = MainWindowViewModel.SEmploye;
        public string Title
        {
            get => _sEmploye;
            set
            {
               
                SetField(ref _sEmploye, _sEmploye =value);
            }
        }
    }

   
}