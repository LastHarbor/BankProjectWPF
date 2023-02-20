using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BankApp.Infrastructure.Commands;
using BankApp.Models;
using BankApp.View.Windows;

namespace BankApp.ViewModels.Base
{
    internal class DepartmentListViewModel
    {

        public ObservableCollection<Department> Departments
        {
            get => WorkSpaceWindowViewModel.Departments;
            set => WorkSpaceWindowViewModel.Departments = value;
        }

        public ICommand FillDepartmentListCommand { get; }
        private void OnFillDepartmentListCommand(object p)
        {
           
        }
        private bool CanFillDepartmentListCommand(object p) => true;

        public DepartmentListViewModel()
        {
            FillDepartmentListCommand = new LambdaCommand(OnFillDepartmentListCommand, CanFillDepartmentListCommand);
        }
    }
}
