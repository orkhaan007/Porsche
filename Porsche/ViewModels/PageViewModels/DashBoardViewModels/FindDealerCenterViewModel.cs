using Porsche.Services;
using Porsche.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Porsche.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace Porsche.ViewModels.PageViewModels.DashBoardPages;

public class FindDealerCenterViewModel : NotificationService
{
    //-------------------------------------- Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }

    public FindDealerCenterViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
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
}
