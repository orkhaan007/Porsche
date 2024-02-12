using Porsche.Views.Pages;
using Porsche.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Porsche.Services;
using Porsche.Views.Pages.BuildYourPorschePages;
using Porsche.Views.Pages.ConstructYourPorschePages;

namespace Porsche.ViewModels.PageViewModels.BuildYourPorscheViewModels;

public class BuildYour911ViewModel : NotificationService
{
    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand open911ConfigurationCommand { get; set; }

    public BuildYour911ViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        open911ConfigurationCommand = new RelayCommand(open911Configuration);
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

    private void open911Configuration(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYour911View>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
