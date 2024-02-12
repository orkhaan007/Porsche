using Porsche.ViewModels.WindowViewModels;
using Porsche.Views.Pages;
using Porsche.Views.Windows;
using System.Windows;
using SimpleInjector;
using Porsche.ViewModels.PageViewModels;
using Porsche.Views.Pages.BuildYourPorschePages;
using Porsche.ViewModels.PageViewModels.BuildYourPorscheViewModels;
using Porsche.ViewModels.PageViewModels.DashBoardPages;
using Porsche.Views.Pages.ConstructYourPorschePages;
using Porsche.ViewModels.PageViewModels.ConstructYourPorscheViewModels;
using DataAccess.Contexts;
using Porsche.ViewModels.PageViewModels.ProfileVievModels;
using Porsche.Views.Pages.ProfilePages;
using System.Linq;

namespace Porsche
{
    public partial class App : Application
    {
        public static Container? _Container;

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            using (var dbContext = new Context())
            {
                var users = dbContext.Users.Where(u => u.IsLoggedIn).ToList();
                foreach (var user in users)
                    user.IsLoggedIn = false;
                dbContext.SaveChanges();
            }
        }
        private void Main(object sender, StartupEventArgs e)
        {
            _Container = new Container();
            var dbContext = new Context();

            _Container.RegisterSingleton<Porsche.Views.Pages.DashBoardView>();
            _Container.RegisterSingleton<FindDealerCenterView>();
            _Container.RegisterSingleton<LoginView>();
            _Container.RegisterSingleton<RegisterEmailConfirmView>();
            _Container.RegisterSingleton<RegisterSetPasswordView>();
            _Container.RegisterSingleton<RegisterView>();
            _Container.RegisterSingleton<BuildYour718View>();
            _Container.RegisterSingleton<BuildYour911View>();
            _Container.RegisterSingleton<BuildYourTaycanView>();
            _Container.RegisterSingleton<BuildYourCayenneView>();
            _Container.RegisterSingleton<BuildYourMacanView>();
            _Container.RegisterSingleton<BuildYourPanameraView>();
            _Container.RegisterSingleton<ContactFormView>();
            _Container.RegisterSingleton<SubscribeView>();
            _Container.RegisterSingleton<ConstructYour718View>();
            _Container.RegisterSingleton<ConstructYour911View>();
            _Container.RegisterSingleton<ConstructYourCayenneView>();
            _Container.RegisterSingleton<ConstructYourPanameraView>();
            _Container.RegisterSingleton<ConstructYourTaycanView>();
            _Container.RegisterSingleton<ConstructYourMacanView>();
            _Container.RegisterSingleton<ProfileView>();

            _Container.RegisterInstance(dbContext);

            _Container.RegisterSingleton<DashboardPageViewModel>();
            _Container.RegisterSingleton<FindDealerCenterViewModel>();
            _Container.RegisterSingleton<LoginPageViewModel>();
            _Container.RegisterSingleton<RegisterEmailConfirmViewModel>();
            _Container.RegisterSingleton<RegisterPageViewModel>();
            _Container.RegisterSingleton<RegisterSetPasswordViewModel>();
            _Container.RegisterSingleton<BuildYour718ViewModel>();
            _Container.RegisterSingleton<BuildYour911ViewModel>();
            _Container.RegisterSingleton<BuildYourTaycanViewModel>();
            _Container.RegisterSingleton<BuildYourMacanViewModel>();
            _Container.RegisterSingleton<BuildYourPanameraViewModel>();
            _Container.RegisterSingleton<BuildYourCayenneViewModel>();
            _Container.RegisterSingleton<ContactFormViewModel>();
            _Container.RegisterSingleton<SubscribeViewModel>();
            _Container.RegisterSingleton<ConstructYour718ViewModel>();
            _Container.RegisterSingleton<ConstructYour911ViewModel>();
            _Container.RegisterSingleton<ConstructYourCayenneViewModel>();
            _Container.RegisterSingleton<ConstructYourPanameraViewModel>();
            _Container.RegisterSingleton<ConstructYourTaycanViewModel>();
            _Container.RegisterSingleton<ConstructYourMacanViewModel>();
            _Container.RegisterSingleton<ProfileViewModel>();

            _Container.RegisterSingleton<MainView>();
            _Container.RegisterSingleton<MainViewModel>();

            _Container.Verify();

            var mainView = _Container.GetInstance<MainView>();
            mainView.DataContext = _Container.GetInstance<MainViewModel>();
            mainView.ShowDialog();
        }
    }
}
