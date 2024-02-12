using DataAccess.Contexts;
using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Porsche.Commands;
using Porsche.Services;
using Porsche.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Porsche.ViewModels.PageViewModels.DashBoardPages;

public class LoginPageViewModel : NotificationService
{

    private readonly Context _dbContext;

    private string? _LoginInput;
    public string? LoginInput
    {
        get { return _LoginInput; }
        set
        {
            if (_LoginInput != value)
            {
                _LoginInput = value;
                OnPropertyChanged();
            }
        }
    }

    //-------------------------------------- Commands --------------------------------------//

    public ICommand ShowRegisterPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand LoginCommand { get; set; }

    public LoginPageViewModel(Context dbContext)
    {
        ShowRegisterPageCommand = new RelayCommand(ShowRegisterPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        LoginCommand = new RelayCommand(Login);
        _dbContext = dbContext;
    }

    //-------------------------------------- Functions --------------------------------------//

    private void ShowRegisterPage(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<RegisterView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void Login(object? obj)
    {
        string enteredEmail = LoginInput;

        User user = _dbContext.Users.FirstOrDefault(u => u.Email == enteredEmail);

        if (user != null)
        {
            user.IsLoggedIn = true;
            _dbContext.SaveChanges();
            ShowDashBoaardPagePage(obj);
        }
        else
        {
            MessageBox.Show("User not found. Please sign up.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ShowDashBoaardPagePage(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<DashBoardView>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
