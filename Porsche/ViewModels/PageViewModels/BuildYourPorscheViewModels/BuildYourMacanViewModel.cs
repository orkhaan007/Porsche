using Porsche.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Porsche.Commands;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Porsche.Services;
using Porsche.Views.Pages.BuildYourPorschePages;
using Porsche.Views.Pages.ConstructYourPorschePages;

namespace Porsche.ViewModels.PageViewModels.BuildYourPorscheViewModels;

public class BuildYourMacanViewModel : NotificationService
{
    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand openMacanConfigurationCommand { get; set; }

    public BuildYourMacanViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        openMacanConfigurationCommand = new RelayCommand(openMacanConfiguration);
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

    private void openMacanConfiguration(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourMacanView>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
