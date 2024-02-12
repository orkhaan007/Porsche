using Porsche.Views.Pages;
using System;
using Porsche.Commands;
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

public class BuildYourCayenneViewModel : NotificationService
{
    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand openCayenneConfigurationCommand { get; set; }

    public BuildYourCayenneViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        openCayenneConfigurationCommand = new RelayCommand(openCayenneConfiguration);
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

    private void openCayenneConfiguration(object? obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourCayenneView>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
