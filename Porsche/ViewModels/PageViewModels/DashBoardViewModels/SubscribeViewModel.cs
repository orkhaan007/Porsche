using Porsche.Commands;
using Porsche.Services;
using Porsche.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Porsche.ViewModels.PageViewModels.DashBoardPages;

public class SubscribeViewModel : NotificationService
{

    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }

    public SubscribeViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
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
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<LoginView>();
            page.NavigationService.Navigate(goPage);
        }
    }
}
