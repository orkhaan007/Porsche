using Porsche.ViewModels.PageViewModels.ProfileVievModels;
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

namespace Porsche.Views.Pages.ProfilePages
{
    public partial class ProfileView : Page
    {
        public ProfileView()
        {
            InitializeComponent();
            DataContext = App._Container?.GetInstance<ProfileViewModel>();
        }
    }
}
