using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.View.Windows;

namespace BankApp.ViewModels.Base
{
    public class MainWindowViewModel : ViewModel
    {
        #region OtherProperties

        #endregion
        #region Title

        private string _title = "Банк";

        public string Title
        {
            get => _title;
            set => SetField(ref _title, _title = value);
        }

        #endregion
        #region ComboBoxItems
        
        public static ObservableCollection<string> Employes
        {
            get;
            set;
        }
        public static string SEmploye
        {
            get;
            set;
        }

        #endregion

        #region OpenWorkSpaceWindowCommand
        public ICommand OpenDialogsCommand { get; }
        private void OnOpenDialogsCommandCommand(object p)
        {
            Workspace workspace = new Workspace();
            string path ="..\\..\\..\\Data\\Database.json";
            if (!File.Exists(path))
            {
                MessageBox.Show("Первый запуск");
                File.Create(path);
                Application.Current.MainWindow?.Close();
                SetCenterPositionAndOpen(workspace);
            }
            else
            {
                Application.Current.MainWindow?.Close();
                SetCenterPositionAndOpen(workspace);
            }
        }
        private bool CanOpenDialogsCommandCommand(object p) => true;

        #endregion
        #region Commands

        public MainWindowViewModel()
        {
            OpenDialogsCommand = new LambdaCommand(OnOpenDialogsCommandCommand, CanOpenDialogsCommandCommand);
            Employes = new ObservableCollection<string>() { "Менеджер", "Консультант" };
        }
        #endregion
        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        
    }
}