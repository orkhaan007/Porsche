using Porsche.Commands;
using Porsche.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Porsche.Views.Pages;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;

namespace Porsche.ViewModels.PageViewModels.DashBoardPages;

public class ContactFormViewModel : NotificationService
{
    //-------------------------------------- Fields --------------------------------------//

    private string _subject;
    public string Subject
    {
        get { return _subject; }
        set
        {
            _subject = value;
            OnPropertyChanged(nameof(Subject));
        }
    }

    private string _body;
    public string Body
    {
        get { return _body; }
        set
        {
            _body = value;
            OnPropertyChanged(nameof(Body));
        }
    }

    private string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set
        {
            _firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string _middleInitial;
    public string MiddleInitial
    {
        get { return _middleInitial; }
        set
        {
            _middleInitial = value;
            OnPropertyChanged(nameof(MiddleInitial));
        }
    }

    private string _lastName;
    public string LastName
    {
        get { return _lastName; }
        set
        {
            _lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    private string _suffix;
    public string Suffix
    {
        get { return _suffix; }
        set
        {
            _suffix = value;
            OnPropertyChanged(nameof(Suffix));
        }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    private string _phone;
    public string Phone
    {
        get { return _phone; }
        set
        {
            _phone = value;
            OnPropertyChanged(nameof(Phone));
        }
    }

    private bool _isHavePorscheAccount;
    public bool IsHavePorscheAccount
    {
        get { return _isHavePorscheAccount; }
        set
        {
            _isHavePorscheAccount = value;
            OnPropertyChanged(nameof(IsHavePorscheAccount));
        }
    }

    private bool _isDontHavePorscheAccount;
    public bool IsDontHavePorscheAccount
    {
        get { return _isDontHavePorscheAccount; }
        set
        {
            _isDontHavePorscheAccount = value;
            OnPropertyChanged(nameof(IsDontHavePorscheAccount));
        }
    }

    //-------------------------------------- Commands --------------------------------------//

    public ICommand ContactFormSubmitCommand { get; set; }
    public ICommand ShowLoginPageCommand { get; set; }
    public ICommand DashBoaardPageCommand { get; set; }

    public ContactFormViewModel()
    {
        ShowLoginPageCommand = new RelayCommand(ShowLoginPage);
        DashBoaardPageCommand = new RelayCommand(ShowDashBoaardPagePage);
        ContactFormSubmitCommand = new RelayCommand(_ => SendEmailContact());
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

    private bool IsValidInputs()
    {
        try
        {
            if (string.IsNullOrEmpty(Subject) || Subject.Length < 5)
            {
                MessageBox.Show("Subject must contain at least 5 characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(Body) || Body.Length < 5)
            {
                MessageBox.Show("Body must contain at least 5 characters.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(FirstName, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid First Name. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(MiddleInitial, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Middle Initial. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(LastName, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Last Name. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(Suffix, "^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid Suffix. Only letters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Invalid Email Address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!Regex.IsMatch(Phone, @"^\d{10}$"))
            {
                MessageBox.Show("Invalid Phone format. Please use the format: 0000000000.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

    }

    private void SendEmailContact()
    {
        try
        {
            if (IsValidInputs())
            {
                string jsonPath = "../../../AppSettings/appsettings.json";
                string json = File.ReadAllText(jsonPath);
                dynamic config = JsonConvert.DeserializeObject(json);

                string smtpServer = config.SmtpServer;
                int smtpPort = config.SmtpPort;
                string smtpUsername = config.SmtpUsername;
                string smtpPassword = config.SmtpPassword;
                string senderEmail = config.SenderEmail;
                string recipientEmail = config.RecipientEmail;


                string subject = Subject;
                string body = $@"
            <html>
    <div id="":ne"" class=""ii gt"" jslog=""20277; u014N:xr6bB; 1:WyIjdGhyZWFkLWY6MTc4MjQ4MTcxNjE1MTM0OTU5OCJd; 4:WyIjbXNnLWY6MTc4MjQ4MTcxNjE1MTM0OTU5OCJd""><div id="":mj"" class=""a3s aiL msg-2172725284877412636""><div class=""adM"">

  
 
 </div><div class=""m_-2172725284877412636em_body"" width=""600"" style=""margin:0px auto;padding:0px;max-width:600px""><div class=""adM"">
  </div><div role=""presentation"" style=""display:none;font-size:1px;color:#ffffff;line-height:1px;max-height:0;max-width:0;opacity:0;overflow:hidden"">
    Dear {FirstName}. {LastName}, Welcome to My Porsche and thank you for registering. Just one more step to activate your personal Porsche ID: Activate Porsche ID account Cli ‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌<wbr>&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌<wbr>&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌<wbr>&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌<wbr>&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌<wbr>&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌<wbr>&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;‌&nbsp;
  </div>
  <table bgcolor=""#fff"" class=""m_-2172725284877412636em_main_table"" align=""center"" width=""600"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""width:600px;max-width:600px"">
   <tbody>
    <tr>
     <td valign=""top"" align=""center"" width=""600"" class=""m_-2172725284877412636em_main_table m_-2172725284877412636full_body_wrapper"" style=""width:600px;max-width:600px"">
      <table class=""m_-2172725284877412636em_wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""width:100%"">
       <tbody>
        <tr>
         <td valign=""top"" align=""center"">
          <table class=""m_-2172725284877412636em_wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center"" style=""width:100%"">
           <tbody>
            <tr>
             <td style=""padding:13px 15px;height:80px"" valign=""center"" align=""center""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fwww.porsche.com/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/vWy9zSczS3q7UB3IvCa9sYOWXkNSPutfcQP_H3vGfjo=326"" style=""text-decoration:none"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fwww.porsche.com/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/vWy9zSczS3q7UB3IvCa9sYOWXkNSPutfcQP_H3vGfjo%3D326&amp;source=gmail&amp;ust=1700264311658000&amp;usg=AOvVaw3iAFgecXwtx2bZnlFesf3w""> <img src=""https://ci6.googleusercontent.com/proxy/jyw08pokzoG91lhaUycy5Dci72n2Jhjov4lrSNdfhxHbLT6oi5GWNSlDBDfA_dnQdUQ2JbBTel3tBJcj-MNtbQr8pztlrZUf-sGTTIyDdg7AdBK4L5x6=s0-d-e1-ft#https://cdn.messaging.porsche.com/p-wordmark/p-wordmark-fallback.png"" alt=""Porsche Picture"" style=""display:block;border:none;width:170px;height:30px;font-size:30px;line-height:30px;font-family:Porsche Next,Arial,sans-serif;color:#191f22;font-weight:bold"" width=""170"" height=""30"" class=""CToWUd"" data-bit=""iit""> 
               <u></u>
                <u></u>
                <u></u>
                <img src=""https://ci6.googleusercontent.com/proxy/jyw08pokzoG91lhaUycy5Dci72n2Jhjov4lrSNdfhxHbLT6oi5GWNSlDBDfA_dnQdUQ2JbBTel3tBJcj-MNtbQr8pztlrZUf-sGTTIyDdg7AdBK4L5x6=s0-d-e1-ft#https://cdn.messaging.porsche.com/p-wordmark/p-wordmark-fallback.png"" alt=""Porsche Picture"" style=""display:none;border:none;width:170px;height:30px;font-size:30px;line-height:30px;font-family:Porsche Next,Arial,sans-serif;color:#191f22;font-weight:bold"" width=""170"" height=""30"" class=""CToWUd"" data-bit=""iit""> 
               <u></u>  </a></td>
            </tr>
           </tbody>
          </table></td>
        </tr>
       </tbody>
      </table>
      <table class=""m_-2172725284877412636em_wrapper"" width=""600.0"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""width:600.0px"" align=""left"">
       <tbody>
        <tr>
         <td valign=""top"" align=""center"" style=""padding:0 0 20px 0"">
          <table class=""m_-2172725284877412636desktop_hero_img"" width=""600.0"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center"" style=""width:600.0"">
           <tbody>
            <tr>
             <td valign=""top"" align=""center"" style=""border-radius:8px""><img class=""m_-2172725284877412636desktop_hero_img CToWUd a6T"" width=""600.0"" style=""display:block;border:none;width:600.0px;max-width:600px;border-radius:8px"" src=""https://ci5.googleusercontent.com/proxy/6khdhQWb0L_QiJddGxIbejyqWY8T48aioriUtsEKW-65eo0oK8jyQNyQn4m5V9hgnpHxY_IYp4ReeDHyZnaILLkB98YR2_dcShd_kiuOBYH5cXtGB3o3bOYetbksas1zftzhVDP-bBXSbpjaLbDGh5_XbyZ4oNba3XqKVHO4YWhRr5terdKjLQ=s0-d-e1-ft#https://images.ctfassets.net/zs2af7joms4m/5fgabuTZ8LX1soB91F2GM9/3c9e0e7244514cee7a292941841971c9/Taycan-Charging.jpg"" alt=""Porsche Picture"" data-bit=""iit"" tabindex=""0""><div class=""a6S"" dir=""ltr"" style=""opacity: 0.01; left: 674px; top: 266px;""><div id="":nv"" class=""T-I J-J5-Ji aQv T-I-ax7 L3 a5q"" title=""Download"" role=""button"" tabindex=""0"" aria-label=""Download attachment "" jslog=""91252; u014N:cOuCgd,Kr2w4b,xr6bB; 4:WyIjbXNnLWY6MTc4MjQ4MTcxNjE1MTM0OTU5OCJd"" data-tooltip-class=""a1V"" jsaction=""JIbuQc:.CLIENT""><div class=""akn""><div class=""aSK J-J5-Ji aYr""></div></div></div></div></td>
            </tr>
           </tbody>
          </table></td>
        </tr>
       </tbody>
      </table> 
      <table class=""m_-2172725284877412636em_wrapper"" width=""100%"" style=""width:100%"">
       <tbody>
        <tr>
         <td class=""m_-2172725284877412636color_Black"" width=""100%"" style=""width:100%;font-size:14px;font-family:Porsche Next,Arial,sans-serif;color:#010205;padding:0 20px 20px 20px;line-height:18px"" valign=""top"" align=""left"">
          <table class=""m_-2172725284877412636em_wrapper"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
           <tbody>
            <tr>
             <td class=""m_-2172725284877412636color_Black"" valign=""top"" align=""left"" style=""font-size:28px;font-family:Porsche Next Semi-Bold,Arial,sans-serif;color:#010205;line-height:30px;padding-top:20px;padding-bottom:10px"">{Subject}</t>
            </tr>
           </tbody>
          </table> <br> {Body},<br> <br> <br> <br> <br> <br>
          <table class=""m_-2172725284877412636em_wrapper"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">
          </table>
        </tr>
       </tbody>
      </table>
      <table class=""m_-2172725284877412636em_wrapper"" style=""width:100%"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"">
       <tbody>
        <tr>
         <td valign=""top"" align=""left"" style=""padding-bottom:20px"">
          <table class=""m_-2172725284877412636em_wrapper"" width=""100%"" bgcolor=""#D8D8DB"" style=""width:100%;background-color:#d8d8db;border-radius:8px"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""left"">
           <tbody>
            <tr>
             <td style=""font-size:14px;color:#010205;line-height:18px;font-family:Porsche Next,Arial,sans-serif;padding:20px"" valign=""top"" align=""left"">For further information, questions, or assistance please contact us at:<br> <br>Phone: <a style=""color:#191f22;text-decoration:underline"" href=""http://redirect.messaging.porsche.com/CL0/tel:%2B1800-767-7243/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/u0hnZ9kjZuljryzidIASds4sMYgWPfVuWvKO0i0bIPI=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://redirect.messaging.porsche.com/CL0/tel:%252B1800-767-7243/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/u0hnZ9kjZuljryzidIASds4sMYgWPfVuWvKO0i0bIPI%3D326&amp;source=gmail&amp;ust=1700264311658000&amp;usg=AOvVaw1lIiNENyZrZTV_Y18IZGyc"">+1 800-767-7243</a> <br>Email: <a style=""color:#191f22;text-decoration:underline"" href=""mailto:customersupport@porsche.com"" target=""_blank"">customersupport@porsche.com</a></td>
            </tr>
           </tbody>
          </table></td>
        </tr>
       </tbody>
      </table>
      <table class=""m_-2172725284877412636em_wrapper"" style=""width:100%"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"">
       <tbody>
        <tr>
         <td valign=""top"" align=""center"">
          <table class=""m_-2172725284877412636em_main_table"" width=""600"" cellspacing=""0"" cellpadding=""0"" border=""0"">
           <tbody>
            <tr>
             <td class=""m_-2172725284877412636color_Black"" style=""padding-top:30px;padding-right:20px;padding-left:20px;font-family:Porsche Next,Arial,Helvetica,sans-serif;font-size:18px"" valign=""top"" align=""left""><span class=""m_-2172725284877412636color_Black"" style=""line-height:22px;font-size:18px""><strong>Connect with Porsche.</strong></span><br><br>
              <table cellspacing=""0"" cellpadding=""0"" border=""0"" align=""left"">
               <tbody>
                <tr>
                 <td valign=""top"" align=""left"">
                  <table cellspacing=""0"" cellpadding=""0"" border=""0"">
                   <tbody>
                    <tr>
                     <td style=""padding-right:5px;padding-bottom:5px"" valign=""middle"" align=""left""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fwww.facebook.com%2Fporsche/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/oGfj9jNxbgAU77nO86j2inNYf4QOwnYzI89J7oRaq3Y=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fwww.facebook.com%252Fporsche/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/oGfj9jNxbgAU77nO86j2inNYf4QOwnYzI89J7oRaq3Y%3D326&amp;source=gmail&amp;ust=1700264311658000&amp;usg=AOvVaw2mr2dRYDl9lNhjV4OJLncQ""><img title="""" style=""display:block"" alt=""Facebook Logo"" src=""https://ci5.googleusercontent.com/proxy/hmdB4ty96vIgXnfGEvDsKEXUMrmhRrKVSxNoiZxl3b6bFN5hxy2dGr4o_07EKF5nvC7y6Zmr3jCeGtE8Iza881UaCsQDr85ePBY3wFMdr-a9k1Evbg=s0-d-e1-ft#https://cdn.messaging.porsche.com/mailtemplate-facebook-png-V3.png"" width=""36"" height=""36"" border=""0"" class=""CToWUd"" data-bit=""iit""></a></td>
                     <td style=""padding-right:5px;padding-bottom:5px"" valign=""middle"" align=""left""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fwww.youtube.com%2Fuser%2FPorsche/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/pvzuF-fzZa0V9wSY0e1czgvxJqkHmhfT-lVDbPHQ4L0=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fwww.youtube.com%252Fuser%252FPorsche/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/pvzuF-fzZa0V9wSY0e1czgvxJqkHmhfT-lVDbPHQ4L0%3D326&amp;source=gmail&amp;ust=1700264311658000&amp;usg=AOvVaw0XOUMFFVrDpu9vG-DPTKH4""><img title="""" style=""display:block"" alt=""YouTube Logo"" src=""https://ci3.googleusercontent.com/proxy/Y_noQVq4177Wizq8wyJ8HDHNs2tK8CA2SzhLc2oJrhx2qIMITjqIAGlI_wE9nHyVTAA2-T6L3rlp3LWvuo4ESXo98pD93NgpqvOdic0mc5og45Ws=s0-d-e1-ft#https://cdn.messaging.porsche.com/mailtemplate-youtube-png-V3.png"" width=""36"" height=""36"" border=""0"" class=""CToWUd"" data-bit=""iit""></a></td>
                     <td style=""padding-right:5px;padding-bottom:5px"" valign=""middle"" align=""right""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Ftwitter.com%2Fporsche%2F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/juX9_u5ffWre9KE60mHGsbh2zixbVGsQQKZjMq3gdKE=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Ftwitter.com%252Fporsche%252F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/juX9_u5ffWre9KE60mHGsbh2zixbVGsQQKZjMq3gdKE%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw3X23tyPXnMPoa745oirzPU""><img title="""" style=""display:block"" alt=""Twitter Logo"" src=""https://ci3.googleusercontent.com/proxy/R5cxtxxoTYQ9tnZCRi6tpmFYJDEB3BbOkTYzPJoBZt7naGg5a714tMdLf8q4s2a15SjLEmGIc5C_ktnQnza5WCTM9-rgoKHPPg6OjSX3IpiJbovK=s0-d-e1-ft#https://cdn.messaging.porsche.com/mailtemplate-twitter-png-V3.png"" width=""36"" height=""36"" border=""0"" class=""CToWUd"" data-bit=""iit""></a></td>
                     <td style=""padding-right:5px;padding-bottom:5px"" valign=""middle"" align=""left""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fwww.pinterest.de%2Fporsche%2F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/md27sTZH0Wn6VvU6S37KjFOlWQiFQqLiTOHawDidAsg=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fwww.pinterest.de%252Fporsche%252F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/md27sTZH0Wn6VvU6S37KjFOlWQiFQqLiTOHawDidAsg%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw2aALO1CnzgXrNsP4ATkQKD""><img title="""" style=""display:block"" alt=""Pinterest Logo"" src=""https://ci5.googleusercontent.com/proxy/BnbbF7hjMpP5zPlo1y5zCaumUjakb-mVcWTqqe9JbK__JP8wRP5nl8x87zdiOkRh1Ee64iiDUoa6c7EcLJsesbG2f6Xph_2buCCm2e9HpTIc-WKCcGQ=s0-d-e1-ft#https://cdn.messaging.porsche.com/mailtemplate-pinterest-png-V3.png"" width=""36"" height=""36"" border=""0"" class=""CToWUd"" data-bit=""iit""></a></td>
                     <td style=""padding-right:5px;padding-bottom:5px"" valign=""middle"" align=""left""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fwww.instagram.com%2Fporscheusa%2F%3Fhl=en/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/Yvb7ATJS0oGXUGXyflDUlmG8vhua2dfdjQQV-rlp-pQ=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fwww.instagram.com%252Fporscheusa%252F%253Fhl%3Den/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/Yvb7ATJS0oGXUGXyflDUlmG8vhua2dfdjQQV-rlp-pQ%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw0YLYKAfZ7P5MYvQii0w2m_""><img title="""" style=""display:block"" alt=""Instagram Logo"" src=""https://ci4.googleusercontent.com/proxy/ssKIqA0YIfFNYVDd8urRF8_Y3Zt8DLHvoFbJUutGW84lhq1KTolmp774n4ht7Pbpr-oOFJ_P_dNWJYuEaESyknUh1kmtqATsx86i_XeRntb4nQp-y3Y=s0-d-e1-ft#https://cdn.messaging.porsche.com/mailtemplate-instagram-png-V3.png"" width=""36"" height=""36"" border=""0"" class=""CToWUd"" data-bit=""iit""></a></td>
                     <td style=""padding-right:5px;padding-bottom:5px"" valign=""middle"" align=""right""><a href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fwww.linkedin.com%2Fcompany%2Fporsche-ag/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/XiBkuzHF07dy638ALQC2n4I9qVqq7LzTrVONtzsxicM=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fwww.linkedin.com%252Fcompany%252Fporsche-ag/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/XiBkuzHF07dy638ALQC2n4I9qVqq7LzTrVONtzsxicM%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw3P2-diF_ObV9TO2_v1xs6K""><img title="""" style=""display:block"" alt=""LinkedIn Logo"" src=""https://ci5.googleusercontent.com/proxy/YPAYlvDzYTcGZGA5PJFAEcmxqj1ZHK1NkrzC8gmM23mKyGXPyHlHcTNC1Wmd7FhKRug0Ik-DG9epLzTqF_GGWwsu0vO1caiwPtZ3ixZOdLwUReqoZA=s0-d-e1-ft#https://cdn.messaging.porsche.com/mailtemplate-linkedin-png-V3.png"" width=""36"" height=""36"" border=""0"" class=""CToWUd"" data-bit=""iit""></a></td>
                    </tr>
                   </tbody>
                  </table></td>
                </tr>
               </tbody>
              </table></td>
            </tr>
            <tr>
             <td class=""m_-2172725284877412636color_Black"" style=""padding:20px 20px 10px;font-family:Porsche Next,Arial,Helvetica,sans-serif;font-size:14px"" valign=""top"" align=""left"">
              <table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""width:100%"">
               <tbody>
                <tr>
                 <td class=""m_-2172725284877412636color_Black"" style=""font-family:Porsche Next,Arial,Helvetica,sans-serif;font-size:14px"" valign=""top"" align=""left"">
                  <table cellspacing=""0"" cellpadding=""0"" border=""0"" align=""left"">
                   <tbody>
                    <tr>
                     <td class=""m_-2172725284877412636color_Black"" style=""padding-bottom:10px;font-family:Porsche Next,Arial,Helvetica,sans-serif;font-size:14px"" valign=""top"" align=""left"">© 2023 Porsche Sales &amp; Marketplace, Inc.</td>
                    </tr>
                    <tr>
                     <td class=""m_-2172725284877412636color_Black"" style=""padding-bottom:10px;font-family:Porsche Next,Arial,Helvetica,sans-serif;font-size:14px"" valign=""top"" align=""left""><a class=""m_-2172725284877412636color_Black"" style=""color:inherit;text-decoration:underline"" href=""http://redirect.messaging.porsche.com/CL0/http:%2F%2Fwww.porsche.com%2Fusa/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/wCAMI9Dmr-q7mBAOh75BVlLXeEsTPONFEHNEqoA_QTk=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://redirect.messaging.porsche.com/CL0/http:%252F%252Fwww.porsche.com%252Fusa/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/wCAMI9Dmr-q7mBAOh75BVlLXeEsTPONFEHNEqoA_QTk%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw3-iFwJab3qmBBKt0-B-pD2"">www.porsche.com</a></td>
                    </tr>
                   </tbody>
                  </table></td>
                </tr>
               </tbody>
              </table></td>
            </tr>
            <tr>
             <td style=""background-color:#191f22;padding:17px 25px 17px 20px;border-radius:8px"" valign=""top"" bgcolor=""#191f22"" align=""center"">
              <table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"">
               <tbody>
                <tr>
                 <td style=""color:#ffffff;font-family:Porsche Next,Arial,sans-serif;font-size:10px;line-height:13px"" align=""left"">If you no longer wish to receive emails from us, please click here to <a style=""color:#e6e0dd;text-decoration:underline"" href=""http://redirect.messaging.porsche.com/CL0/http:%2F%2Fwww.porsche.com%2Fusa%2Fdialogue%2Femailconsent%2Foptout%2F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/2u6PjTml_-xfF-24p8xCl-5EivV16iKFgcsrYPZ6Bls=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://redirect.messaging.porsche.com/CL0/http:%252F%252Fwww.porsche.com%252Fusa%252Fdialogue%252Femailconsent%252Foptout%252F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/2u6PjTml_-xfF-24p8xCl-5EivV16iKFgcsrYPZ6Bls%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw2R2sRnjNRd6MqprOTFZwqq"">unsubscribe</a>. <br> <br> Porsche recommends seat-belt usage and observance of traffic laws at all times.<br> Please do not reply to this e-mail. If you have any questions, please contact 1-800-PORSCHE. <br> <br> Porsche Sales &amp; Marketplace, Inc. I One Porsche Drive I Atlanta, Georgia 30354<br> <a style=""color:white;text-decoration:underline"" href=""mailto:info@porsche.us"" target=""_blank"">info@porsche.us</a> I 1-800-PORSCHE I <a style=""color:#e6e0dd;text-decoration:underline"" href=""http://redirect.messaging.porsche.com/CL0/http:%2F%2Fwww.porsche.com%2Fusa%2F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/tS3M7eU8WXgcQYAaHcBa6ylbFZ_vWDHMa7P3dHPlRwg=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://redirect.messaging.porsche.com/CL0/http:%252F%252Fwww.porsche.com%252Fusa%252F/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/tS3M7eU8WXgcQYAaHcBa6ylbFZ_vWDHMa7P3dHPlRwg%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw1mmoSIm5XSYdUb08OsJnXN"">www.porsche.com</a><br> <br> <a style=""color:white;text-decoration:underline"" href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fconnect-store.porsche.com%2Fus%2Fen%2Fabout%3FreducedHeaderFooter=true/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/gpKClJlzCYKzeH2GuAQuQ_QKJQ8DUQuBzUh7yIbDKok=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fconnect-store.porsche.com%252Fus%252Fen%252Fabout%253FreducedHeaderFooter%3Dtrue/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/gpKClJlzCYKzeH2GuAQuQ_QKJQ8DUQuBzUh7yIbDKok%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw1dNgZ4yOfLWWgWkeppbTRH"">Legal Notice</a>. <a style=""color:white;text-decoration:underline"" href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fconnect-store.porsche.com%2Fus%2Fen%2Ftac%2Ft%2Fprivacy%3FreducedHeaderFooter=true/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/iNV8kA33P2QtZNIdesIhsSdxR4eBQ7926R4d4r_2efs=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fconnect-store.porsche.com%252Fus%252Fen%252Ftac%252Ft%252Fprivacy%253FreducedHeaderFooter%3Dtrue/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/iNV8kA33P2QtZNIdesIhsSdxR4eBQ7926R4d4r_2efs%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw1qEABGSt5oCrS4m3iOiJeG"">Privacy Notice</a>. <a style=""color:white;text-decoration:underline"" href=""https://redirect.messaging.porsche.com/CL0/https:%2F%2Fconnect-store2.porsche.com%2Fus%2Fen%2Ft%2Fprivacy%3FreducedHeaderFooter=true%23california-consumers-notice/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/jg4VdLWSUmcrV3WlckuNxG9kF_tHCL-KN5FytvmSbcg=326"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://redirect.messaging.porsche.com/CL0/https:%252F%252Fconnect-store2.porsche.com%252Fus%252Fen%252Ft%252Fprivacy%253FreducedHeaderFooter%3Dtrue%2523california-consumers-notice/1/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/jg4VdLWSUmcrV3WlckuNxG9kF_tHCL-KN5FytvmSbcg%3D326&amp;source=gmail&amp;ust=1700264311659000&amp;usg=AOvVaw2jRneX7l2NHRvumbhHAGqI"">California Privacy</a>.</td>
                </tr>
               </tbody>
              </table></td>
            </tr>
           </tbody>
          </table></td>
        </tr>
       </tbody>
      </table></td>
    </tr>
   </tbody>
  </table>
 <img alt="""" src=""https://ci5.googleusercontent.com/proxy/nuEaSfdt75OSPXIKIVSz0qsOKy_R-p9a9OutTt_YTKWzXgiBhn_mb-9X-BF7clGbMAhFBUIoIBMoUZ-kwxStUqA8pyedEJpnuihIyHjymmE0MmI_-kiivIs-1vtUu7AxWaOFjVAecRYXGC2L0HWI5ae4UxFuQtmfKZ5pXR4MNjlSBSFDZbdquTIT5zy1ZpIkKro96QWH8nqR1NPFzd5NiSG3JhYvsyLrDoM=s0-d-e1-ft#http://redirect.messaging.porsche.com/CI0/0102018bca5ad0d2-b55c527b-49fb-4010-bf47-496b3df9c94d-000000/UZrr4wBfiIdXCpYIyHWdPo7LHmBqi10cJAcu2CmLmKk=326"" style=""display:none;width:1px;height:1px"" class=""CToWUd"" data-bit=""iit""><div class=""yj6qo""></div><div class=""adL"">
</div></div><div class=""adL"">
</div></div></div>
</html>
            ";

                using (MailMessage mail = new MailMessage(senderEmail, recipientEmail, subject, body))
                {
                    mail.IsBodyHtml = true;

                    SmtpClient smtpClient = new SmtpClient(smtpServer)
                    {
                        Port = smtpPort,
                        Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                        EnableSsl = true,
                    };

                    smtpClient.Send(mail);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error sending confirmation email: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
