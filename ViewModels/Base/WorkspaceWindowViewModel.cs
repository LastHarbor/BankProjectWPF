using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.View.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankApp.ViewModels.Base
{
    public class WorkSpaceWindowViewModel : ViewModel
    {

        public string path = "..\\..\\..\\Data\\Database.json";
        #region Properties to work with

        private static ObservableCollection<Department> _departments;

        public static ObservableCollection<Department> Departments
        {
            get => _departments;
            set => _departments = value;
        }

        private static ObservableCollection<User> _consultants;
        public static ObservableCollection<User> Consultants
        {
           get => _consultants;
           set => _consultants = value;
        }
        private static ObservableCollection<User> _managers;

        public static ObservableCollection<User> Managers
        {
            get => _managers;
            set => _managers = value;
        }

        //свойства для выделенных элементов
        public ListView SelectedClient { get; set; }
        public User SelectedUser { get; set; }
        public Department SelectedDepartment { get; set; }

        //Свойства для клиента 
        //public  int ClientId { get; set; }
        //public string ClientName { get; set; }
        //public string ClientLastName { get; set; }
        //public string ClientPatronimyc { get; set; }
        //public string ClientMobileNumber { get; set; }
        //public string ClientPassport { get; set; }

        public List<Client> Clients { get; set; }
        #endregion
        #region Title

        string _sEmploye = MainWindowViewModel.SEmploye;

        public string Title
        {
            get => _sEmploye;
            set => SetField(ref _sEmploye, _sEmploye = value);
        }

        #endregion

        #region Commands

        public ICommand AddDepartmentCommand { get; }
        private void OnAddDepatrmentCommand(object p)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.ShowDialog();
        }
        private bool CanAdddepartmentCommand(object p) => true;
        #region RefreshKey

        public ICommand RefreshDataCommand { get; }
        private void OnRefreshDataCommand(object p)
        {

        }
        private bool CanRefreshDataCommand(object p) => true;


        public ICommand ShowDepartmentsCommand { get; }
        private void OnShowDepartmentsCommand(object p)
        {
            DepartmentList departmentList = new DepartmentList();
            departmentList.ShowDialog();
        }
        private bool CanShowDepartmentsCommand(object p) => true;

        #endregion

        #endregion

        public WorkSpaceWindowViewModel()
        {
            //FillDb();
            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommand, CanRefreshDataCommand);
            AddDepartmentCommand = new LambdaCommand(OnAddDepatrmentCommand, CanAdddepartmentCommand);
            ShowDepartmentsCommand = new LambdaCommand(OnShowDepartmentsCommand, CanShowDepartmentsCommand);
            Managers = new ObservableCollection<User>();
            Consultants = new ObservableCollection<User>();
            Departments = new ObservableCollection<Department>();
            try
            {
                Departments.Add(new Department("Zero"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        private void FillDb()
        {
            var json = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<List<Department>>(json);

            foreach (var department in data)
            {
                    Departments.Add(department);
            }
        }
    }

}
