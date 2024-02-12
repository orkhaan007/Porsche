using Porsche.ViewModels.PageViewModels;
using Porsche.ViewModels.PageViewModels.ConstructYourPorscheViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Porsche.Views.Pages.ConstructYourPorschePages;

public partial class ConstructYourTaycanView : Page
{
    public ConstructYourTaycanView()
    {
        InitializeComponent();
        DataContext = App._Container?.GetInstance<ConstructYourTaycanViewModel>();
    }
}
