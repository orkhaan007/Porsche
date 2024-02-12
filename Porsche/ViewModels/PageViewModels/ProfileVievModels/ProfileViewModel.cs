using DataAccess.Contexts;
using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Porsche.Commands;
using Porsche.Services;
using Porsche.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
#nullable disable

namespace Porsche.ViewModels.PageViewModels.ProfileVievModels;

public class ProfileViewModel : NotificationService
{
    private ObservableCollection<Car> _carList;
    private ObservableCollection<ServiceRecord> _serviceRecords;
    private ObservableCollection<InsurancePolicy> _insurancePolicies;

    private readonly Context _dbContext;
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand ChangePersonalDetailsSubmitCommand { get; set; }
    public ICommand ExitCommand { get; set; }

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

    public ObservableCollection<ServiceRecord> ServiceRecords
    {
        get { return _serviceRecords; }
        set
        {
            _serviceRecords = value;
            OnPropertyChanged(nameof(ServiceRecords));
        }
    }

    public ObservableCollection<InsurancePolicy> InsurancePolicies
    {
        get { return _insurancePolicies; }
        set
        {
            _insurancePolicies = value;
            OnPropertyChanged(nameof(InsurancePolicies));
        }
    }

    public ObservableCollection<Car> CarList
    {
        get { return _carList; }
        set
        {
            _carList = value;
            OnPropertyChanged(nameof(CarList));
        }
    }

    public ProfileViewModel(Context dbContext)
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        ExitCommand = new RelayCommand(Exit);
        _dbContext = dbContext;
        ChangePersonalDetailsSubmitCommand = new RelayCommand(ChangePersonalDetails);
        LoadLoggedInUserCars();

        ServiceRecords = new ObservableCollection<ServiceRecord>(_dbContext.ServiceRecords.ToList());
        InsurancePolicies = new ObservableCollection<InsurancePolicy>(_dbContext.InsurancePolicies.ToList());
    }

    //-------------------------------------- Functions --------------------------------------//

    private void ShowDashBoaardPagePage(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<DashBoardView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowLoginPage(object? obj)
    {
        var loggedInUser = _dbContext.Users.FirstOrDefault(u => u.IsLoggedIn);
        if (loggedInUser != null)
        {
            MessageBox.Show("You are already logged in.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<LoginView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private bool IsValidInputs()
    {
        try
        {
            if (!Regex.IsMatch(Password, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$"))
            {
                MessageBox.Show("Invalid Password. It must be at least 8 characters long and contain numbers, uppercase and lowercase letters, and special characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Salutation, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Salutation. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Title, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Title. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(FirstName, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid First Name. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(MiddleInitial, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Middle Initial. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(LastName, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Last Name. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Suffix, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Suffix. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Invalid Email Address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        
    private void ChangePersonalDetails(object? obj)
    {
        if (obj is Page page && IsValidInputs())
        {
            var loggedInUser = _dbContext.Users.FirstOrDefault(u => u.IsLoggedIn);

            if (loggedInUser != null)
            {
                loggedInUser.Salutation = Salutation;
                loggedInUser.Title = Title;
                loggedInUser.FirstName = FirstName;
                loggedInUser.MiddleInitial = MiddleInitial;
                loggedInUser.LastName = LastName;
                loggedInUser.Suffix = Suffix;
                loggedInUser.Email = Email;
                loggedInUser.Password = Password;

                _dbContext.SaveChanges();
            }
        }
    }

    private void Exit(object? obj)
    {
        var loggedInUsers = _dbContext.Users.Where(u => u.IsLoggedIn).ToList();
        foreach (var user in loggedInUsers)
            user.IsLoggedIn = false;
        _dbContext.SaveChanges();

        MessageBox.Show("Logout was successful.", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void LoadLoggedInUserCars()
    {
        var loggedInUser = _dbContext.Users.FirstOrDefault(u => u.IsLoggedIn);
        if (loggedInUser != null)
        {
            var userCars = _dbContext.Cars.Where(c => c.UserId == loggedInUser.Id).ToList();

            CarList = new ObservableCollection<Car>(userCars.Select(c => new Car
            {
                Model = c.Model,
                Seats = c.Seats,
                TotalPrice = c.TotalPrice,
                Color = c.Color
            }));
        }
    }

}
