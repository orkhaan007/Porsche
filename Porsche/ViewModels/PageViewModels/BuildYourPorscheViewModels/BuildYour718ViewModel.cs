using Porsche.Commands;
using Porsche.Services;
using Porsche.Views.Pages;
using Porsche.Views.Pages.BuildYourPorschePages;
using Porsche.Views.Pages.ConstructYourPorschePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Porsche.ViewModels.PageViewModels;

public class BuildYour718ViewModel : NotificationService
{
    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand open718ConfigurationCommand { get; set; }

    public BuildYour718ViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        open718ConfigurationCommand = new RelayCommand(open718Configuration);
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

    private void open718Configuration(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYour718View>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
