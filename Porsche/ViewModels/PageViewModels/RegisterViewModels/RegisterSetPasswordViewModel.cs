using Porsche.Services;
using System;
using Porsche.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Porsche.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Concretes;

namespace Porsche.ViewModels.PageViewModels;

public class RegisterSetPasswordViewModel : NotificationService
{

    private readonly Context _dbContext;

    private string? _salutation;
    public string? Salutation
    {
        get { return _salutation; }
        set
        {
            if (_salutation != value)
            {
                _salutation = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _title;
    public string? Title
    {
        get { return _title; }
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _firstName;
    public string? FirstName
    {
        get { return _firstName; }
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _middleInitial;
    public string? MiddleInitial
    {
        get { return _middleInitial; }
        set
        {
            if (_middleInitial != value)
            {
                _middleInitial = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _lastName;
    public string? LastName
    {
        get { return _lastName; }
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _suffix;
    public string? Suffix
    {
        get { return _suffix; }
        set
        {
            if (_suffix != value)
            {
                _suffix = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _email;
    public string? Email
    {
        get { return _email; }
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _password;
    public string? Password
    {
        get { return _password; }
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }

    private string _passwordInput;
    public string PasswordInput
    {
        get { return _passwordInput; }
        set
        {
            _passwordInput = value;
            OnPropertyChanged(nameof(PasswordInput));
        }
    }

    //-------------------------------------- Commands --------------------------------------//

    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand SetPasswordPageCommand { get; set; }

    public RegisterSetPasswordViewModel(Context dbContext)
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        SetPasswordPageCommand = new RelayCommand(ShowDashBoaardPagePageWithPasswordControl);
        _dbContext = dbContext;
    }

    //-------------------------------------- Functions --------------------------------------//

    private void ShowLoginPage(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<LoginView>();
            page.NavigationService.Navigate(goPage);
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
    private void ShowDashBoaardPagePageWithPasswordControl(object? obj)
    {
        if (obj is Page page && IsValidInputs())
        {
            var newUser = new User
            {
                Salutation = _salutation,
                Title = _title,
                FirstName = _firstName,
                MiddleInitial = _middleInitial,
                LastName = _lastName,
                Suffix = _suffix,
                Email = _email,
                Password = _passwordInput,
                IsLoggedIn = true
            };


            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            var goPage = App._Container?.GetInstance<DashBoardView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private bool IsValidInputs()
    {
        try
        {
            if (!Regex.IsMatch(PasswordInput, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$"))
            {
                MessageBox.Show("Invalid Password. It must be at least 8 characters long and contain numbers, uppercase and lowercase letters, and special characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
    }
}
