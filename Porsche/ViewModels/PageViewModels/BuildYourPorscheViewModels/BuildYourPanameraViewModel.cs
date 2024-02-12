using Porsche.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using Porsche.Commands;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Porsche.Services;
using Porsche.Views.Pages.BuildYourPorschePages;
using Porsche.Views.Pages.ConstructYourPorschePages;

namespace Porsche.ViewModels.PageViewModels.BuildYourPorscheViewModels;

public class BuildYourPanameraViewModel : NotificationService
{
    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand openPanameraConfigurationCommand { get; set; }

    public BuildYourPanameraViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        openPanameraConfigurationCommand = new RelayCommand(openPanameraConfiguration);
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

    private void openPanameraConfiguration(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourPanameraView>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
