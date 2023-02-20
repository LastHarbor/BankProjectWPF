using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BankApp.Infrastructure.Commands;
using BankApp.View.Windows;
using BankApp.Models;

namespace BankApp.ViewModels.Base;

public class AddDepartmentViewModel 
{

    #region Department name

    private string _departmentName;

    public string DepartmentName
    {
        get { return _departmentName; }
        set { _departmentName = value; }
    }

    public ObservableCollection<Department> Departments
    {
        get => WorkSpaceWindowViewModel.Departments;
        set => WorkSpaceWindowViewModel.Departments = value;
    }

    #endregion
    #region Добавление департамента
    public ICommand AddDepartmentCommand { get; }
    private void OnAddDepartmentCommand(object p)
    {
        try
        {
            Departments.Add(new Department(DepartmentName));
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Error", MessageBoxButton.OK);
        }
        
    }
    private bool CanAddDepartmentCommand(object p) => true;
    #endregion

    public AddDepartmentViewModel()
    {
        AddDepartmentCommand = new LambdaCommand(OnAddDepartmentCommand, CanAddDepartmentCommand);
    }

}