using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Porsche.Commands;
using Porsche.Services;
using Porsche.Views.Pages;
using Porsche.Views.Pages.BuildYourPorschePages;
using Porsche.Views.Pages.ConstructYourPorschePages;
using Porsche.Views.Pages.ProfilePages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
#nullable disable

namespace Porsche.ViewModels.PageViewModels.DashBoardPages;

public class DashboardPageViewModel : NotificationService
{

    private readonly Context _dbContext;

    //-------------------------------------- Header Button Commands --------------------------------------//

    public ICommand PlayCommand { get; set; }
    public ICommand StopCommand { get; set; }

    //-------------------------------------- Page Control Commands --------------------------------------//
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand FindDealerCenterCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }
    public ICommand ShowBuildYour718PageCommand { get; set; }
    public ICommand ShowBuildYourCayennePageCommand { get; set; }
    public ICommand ShowBuildYour911PageCommand { get; set; }
    public ICommand ShowBuildYourTaycanPageCommand { get; set; }
    public ICommand ShowBuildYourPanameraPageCommand { get; set; }
    public ICommand ShowBuildYourMacanPageCommand { get; set; }
    public ICommand showContactFormCommand { get; set; }
    public ICommand showSubscribeCommand { get; set; }
    public ICommand showConstructYour718Command { get; set; }
    public ICommand showConstructYour911Command { get; set; }
    public ICommand showConstructYourTaycanCommand { get; set; }
    public ICommand showConstructYourMacanCommand { get; set; }
    public ICommand showConstructYourCayenneCommand { get; set; }
    public ICommand showConstructYourPanameraCommand { get; set; }

    //-------------------------------------- Shop Container Commands --------------------------------------//

    public ICommand OpenWCCPageCommand { get; set; }
    public ICommand OpenWatchPageCommand { get; set; }
    public ICommand OpenEBikePageCommand { get; set; }
    public ICommand OpenGCSPageCommand { get; set; }

    //-------------------------------------- Discover Container Commands --------------------------------------//

    public ICommand OpenTAEPageCommand { get; set; }
    public ICommand OpenPAPageCommand { get; set; }
    public ICommand OpenMEPageCommand { get; set; }

    //-------------------------------------- Footer Button Commands --------------------------------------//

    public ICommand OpenFacebookPageCommand { get; set; }
    public ICommand OpenInstagramPageCommand { get; set; }
    public ICommand OpenPinterestPageCommand { get; set; }
    public ICommand OpenYoutubePageCommand { get; set; }
    public ICommand OpenTwitterPageCommand { get; set; }
    public ICommand OpenLinkedinPageCommand { get; set; }

    //-------------------------------------- Footer Label Commands --------------------------------------//

    public ICommand OpenLNPageCommand { get; set; }
    public ICommand OpenPPPageCommand { get; set; }
    public ICommand OpenCPPageCommand { get; set; }
    public ICommand OpenASPageCommand { get; set; }
    public ICommand OpenOPSNPageCommand { get; set; }
    public ICommand OpenPIPageCommand { get; set; }
    public ICommand OpenWSPageCommand { get; set; }
    public ICommand OpenERGPageCommand { get; set; }
    public ICommand OpenRIPageCommand { get; set; }
    public ICommand Open3WTFPageCommand { get; set; }

    public DashboardPageViewModel(Context dbContext)
    {
        StopCommand = new RelayCommand(StopMediaElement);

        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        FindDealerCenterCommand = new RelayCommand(ShowFindDealerCenterPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        ShowBuildYourCayennePageCommand = new RelayCommand(ShowBuildYourCayennePage);
        ShowBuildYour911PageCommand = new RelayCommand(ShowBuildYour911Page);
        ShowBuildYourTaycanPageCommand = new RelayCommand(ShowBuildYourTaycanPage);
        ShowBuildYourPanameraPageCommand = new RelayCommand(ShowBuildYourPanameraPage);
        ShowBuildYourMacanPageCommand = new RelayCommand(ShowBuildYourMacanPage);
        ShowBuildYour718PageCommand = new RelayCommand(ShowBuildYour718Page);
        showContactFormCommand = new RelayCommand(showContactForm);
        showSubscribeCommand = new RelayCommand(showSubscribe);
        showConstructYour718Command = new RelayCommand(showConstructYour718);
        showConstructYour911Command = new RelayCommand(showConstructYour911);
        showConstructYourTaycanCommand = new RelayCommand(showConstructYourTaycan);
        showConstructYourMacanCommand = new RelayCommand(showConstructYourMacan);
        showConstructYourPanameraCommand = new RelayCommand(showConstructYourPanamera);
        showConstructYourCayenneCommand = new RelayCommand(showConstructYourCayenne);

        OpenWCCPageCommand = new RelayCommand(OpenWCCPage);
        OpenWatchPageCommand = new RelayCommand(OpenWatchPage);
        OpenEBikePageCommand = new RelayCommand(OpenEBikePage);
        OpenGCSPageCommand = new RelayCommand(OpenGCSPage);

        OpenTAEPageCommand = new RelayCommand(OpenTAEPage);
        OpenPAPageCommand = new RelayCommand(OpenPAPage);
        OpenMEPageCommand = new RelayCommand(OpenMEPage);

        OpenFacebookPageCommand = new RelayCommand(OpenFacebookPage);
        OpenInstagramPageCommand = new RelayCommand(OpenInstagramPage);
        OpenPinterestPageCommand = new RelayCommand(OpenPinterestPage);
        OpenYoutubePageCommand = new RelayCommand(OpenYoutubePage);
        OpenTwitterPageCommand = new RelayCommand(OpenTwitterPage);
        OpenLinkedinPageCommand = new RelayCommand(OpenLinkedinPage);

        OpenLNPageCommand = new RelayCommand(OpenLNPage);
        OpenPPPageCommand = new RelayCommand(OpenPPPage);
        OpenCPPageCommand = new RelayCommand(OpenCPPage);
        OpenASPageCommand = new RelayCommand(OpenASPage);
        OpenOPSNPageCommand = new RelayCommand(OpenOPSNPage);
        OpenPIPageCommand = new RelayCommand(OpenPIPage);
        OpenWSPageCommand = new RelayCommand(OpenWSPage);
        OpenERGPageCommand = new RelayCommand(OpenERGPage);
        OpenRIPageCommand = new RelayCommand(OpenRIPage);
        Open3WTFPageCommand = new RelayCommand(Open3WTFPage);

        _dbContext = dbContext;
    }

    //-------------------------------------- Functions --------------------------------------//

    private void OpenFacebookPage(object parameter)
    {
        string facebookUrl = "https://www.facebook.com/porsche/";

        Process.Start(new ProcessStartInfo
        {
            FileName = facebookUrl,
            UseShellExecute = true,
        });
    }

    private void OpenInstagramPage(object parameter)
    {
        string instagramUrl = "https://www.instagram.com/porsche/";

        Process.Start(new ProcessStartInfo
        {
            FileName = instagramUrl,
            UseShellExecute = true,
        });
    }

    private void OpenPinterestPage(object parameter)
    {
        string pinterestUrl = "https://www.pinterest.com/porsche/";

        Process.Start(new ProcessStartInfo
        {
            FileName = pinterestUrl,
            UseShellExecute = true,
        });
    }

    private void OpenYoutubePage(object parameter)
    {
        string youtubeUrl = "https://www.youtube.com/user/Porsche";

        Process.Start(new ProcessStartInfo
        {
            FileName = youtubeUrl,
            UseShellExecute = true,
        });
    }

    private void OpenTwitterPage(object parameter)
    {
        string twitterUrl = "https://twitter.com/Porsche";

        Process.Start(new ProcessStartInfo
        {
            FileName = twitterUrl,
            UseShellExecute = true,
        });
    }

    private void OpenLinkedinPage(object parameter)
    {
        string linkedinUrl = "https://www.linkedin.com/company/porsche-ag/";

        Process.Start(new ProcessStartInfo
        {
            FileName = linkedinUrl,
            UseShellExecute = true,
        });
    }

    private void OpenLNPage(object parameter)
    {
        string LNUrl = "https://www.porsche.com/usa/legal-notice/";

        Process.Start(new ProcessStartInfo
        {
            FileName = LNUrl,
            UseShellExecute = true,
        });
    }

    private void OpenPPPage(object parameter)
    {
        string PPUrl = "https://www.porsche.com/usa/privacy-policy/";

        Process.Start(new ProcessStartInfo
        {
            FileName = PPUrl,
            UseShellExecute = true,
        });
    }

    private void OpenCPPage(object parameter)
    {
        string CPUrl = "https://www.porsche.com/usa/privacy-policy/#california";

        Process.Start(new ProcessStartInfo
        {
            FileName = CPUrl,
            UseShellExecute = true,
        });
    }

    private void OpenASPage(object parameter)
    {
        string ASUrl = "https://www.porsche.com/usa/accessibilitystatement/";

        Process.Start(new ProcessStartInfo
        {
            FileName = ASUrl,
            UseShellExecute = true,
        });
    }

    private void OpenOPSNPage(object parameter)
    {
        string OPSUrl = "https://www.porsche.com/licenses";

        Process.Start(new ProcessStartInfo
        {
            FileName = OPSUrl,
            UseShellExecute = true,
        });
    }

    private void OpenPIPage(object parameter)
    {
        string PIUrl = "https://www.porsche.com/usa/privacy-policy/contact/";

        Process.Start(new ProcessStartInfo
        {
            FileName = PIUrl,
            UseShellExecute = true,
        });
    }

    private void OpenWSPage(object parameter)
    {
        string WSUrl = "https://www.porsche.com/usa/aboutporsche/overview/compliance/whistleblower-system/";

        Process.Start(new ProcessStartInfo
        {
            FileName = WSUrl,
            UseShellExecute = true,
        });
    }

    private void OpenERGPage(object parameter)
    {
        string ERGUrl = "https://www.porsche.com/usa/accessoriesandservices/porscheservice/vehicleinformation/emergencyresponseguides/";

        Process.Start(new ProcessStartInfo
        {
            FileName = ERGUrl,
            UseShellExecute = true,
        });
    }

    private void OpenRIPage(object parameter)
    {
        string RIUrl = "https://recall.porsche.com/prod/pag/vinrecalllookup_V3.nsf/VIN?ReadForm&c=usa";

        Process.Start(new ProcessStartInfo
        {
            FileName = RIUrl,
            UseShellExecute = true,
        });
    }

    private void Open3WTFPage(object parameter)
    {
        string WTFnUrl = "https://www.porsche.com/usa/faq-3g-sunset/";

        Process.Start(new ProcessStartInfo
        {
            FileName = WTFnUrl,
            UseShellExecute = true,
        });
    }

    private void StopMediaElement(object parameter)
    {
        if (parameter is Grid gr)
        {
            var Media = gr.Children[0] as MediaElement;
            Media.LoadedBehavior = MediaState.Stop;
        }
    }


    private bool IsUserLoggedIn()
    {
        return _dbContext.Users.Any(u => u.IsLoggedIn);
    }

    private void ShowLoginPage(object obj)
    {
        if (obj is Page page)
        {
            if (IsUserLoggedIn())
            {
                var goPage = App._Container?.GetInstance<ProfileView>();
                page.NavigationService.Navigate(goPage);
            }
            else
            {
                var goPage = App._Container?.GetInstance<LoginView>();
                page.NavigationService.Navigate(goPage);
            }
        }
    }
    private void ShowFindDealerCenterPage(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<FindDealerCenterView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowDashBoaardPagePage(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<DashBoardView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showContactForm(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ContactFormView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showSubscribe(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<SubscribeView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showConstructYour718(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYour718View>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showConstructYour911(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYour911View>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showConstructYourCayenne(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourCayenneView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showConstructYourMacan(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourMacanView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showConstructYourPanamera(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourPanameraView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void showConstructYourTaycan(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<ConstructYourTaycanView>();
            page.NavigationService.Navigate(goPage);
        }
    }
    private void OpenWCCPage(object obj)
    {
        string WCCUrl = "https://shop.porsche.com/us/en-US/p/porsche-wall-charger-connect-B-HCHH0LAA/HCHH0LAA";

        Process.Start(new ProcessStartInfo
        {
            FileName = WCCUrl,
            UseShellExecute = true,
        });
    }
    private void OpenWatchPage(object obj)
    {
        string WatchUrl = "https://shop.porsche.com/us/en-US/p/porsche-x-garmin-epix-smartwatch-P-WAP0709020PSMW/WAP0709020PSMW";

        Process.Start(new ProcessStartInfo
        {
            FileName = WatchUrl,
            UseShellExecute = true,
        });
    }
    private void OpenEBikePage(object obj)
    {
        string EBikUrl = "https://shop.porsche.com/us/en-US/p/ebike-cross-performance-P-WAP061ENA0PXXX/WAP061ENA0P00S?queryID=def6c253506819b4aeab45485b17f3fa";

        Process.Start(new ProcessStartInfo
        {
            FileName = EBikUrl,
            UseShellExecute = true,
        });
    }
    private void OpenGCSPage(object obj)
    {
        string GCSnUrl = "https://shop.porsche.com/us/en-US/p/golf-cartbag-sport-P-WAP0350510MCTB/WAP0350510MCTB";

        Process.Start(new ProcessStartInfo
        {
            FileName = GCSnUrl,
            UseShellExecute = true,
        });
    }

    private void OpenTAEPage(object obj)
    {
        string TAEUrl = "https://www.porschedriving.com/travel-experience";

        Process.Start(new ProcessStartInfo
        {
            FileName = TAEUrl,
            UseShellExecute = true,
        });
    }

    private void OpenPAPage(object obj)
    {
        string PAUrl = "https://finder.porsche.com/us/en-US/certified-preowned";

        Process.Start(new ProcessStartInfo
        {
            FileName = PAUrl,
            UseShellExecute = true,
        });
    }

    private void OpenMEPage(object obj)
    {
        string MEUrl = "https://www.porsche.com/usa/motorsportandevents/motorsport/";

        Process.Start(new ProcessStartInfo
        {
            FileName = MEUrl,
            UseShellExecute = true,
        });
    }

    private void ShowBuildYourCayennePage(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<BuildYourCayenneView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowBuildYour911Page(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<BuildYour911View>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowBuildYourTaycanPage(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<BuildYourTaycanView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowBuildYourPanameraPage(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<BuildYourPanameraView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowBuildYourMacanPage(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<BuildYourMacanView>();
            page.NavigationService.Navigate(goPage);
        }
    }

    private void ShowBuildYour718Page(object obj)
    {
        if (obj is Page page)
        {
            var goPage = App._Container?.GetInstance<BuildYour718View>();
            page.NavigationService.Navigate(goPage);
        }
    }

}