using ChummerHub.Client.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChummerHub.Client.UI
{
    public partial class frmWebBrowser : Form
    {
        public frmWebBrowser()
        {
            InitializeComponent();
        }

       

       

        private string LoginUrl
        {
            get
            {
                if(String.IsNullOrEmpty(Properties.Settings.Default.SINnerUrl))
                {
                    Properties.Settings.Default.SINnerUrl = "https://sinners.azurewebsites.net/";
                    string msg = "if you are (want to be) a Beta-Tester, change this to http://sinners-beta.azurewebsites.net/!";
                    System.Diagnostics.Trace.TraceWarning(msg);
                    Properties.Settings.Default.Save();
                }
                string path = Properties.Settings.Default.SINnerUrl.TrimEnd('/');

                path += "/Identity/Account/Login?returnUrl=/Identity/Account/Manage";
                return path;
            }
        }

       

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            
                Invoke((Action)(() =>
                {
                    this.SuspendLayout();
                    webBrowser2.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser2_Navigated);
                    webBrowser2.ScriptErrorsSuppressed = true;
                    webBrowser2.Navigate(LoginUrl);
                    this.BringToFront();
                })
                );
                        
        }

        private bool login = false;

        private async void webBrowser2_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if(e.Url.AbsoluteUri == LoginUrl)
                return;
            if((e.Url.AbsoluteUri.Contains("/Identity/Account/Logout")))
            {
                //maybe we are logged in now
                GetCookieContainer();
            }
            else if (e.Url.AbsoluteUri.Contains("/Identity/Account/Manage"))
            {
                try
                {
                    //we are logged in!
                    GetCookieContainer();
                    var client = await StaticUtils.GetClient();
                    var user = await client.GetUserByAuthorizationWithHttpMessagesAsync();
                    if (user.Body != null)
                    {
                        login = true;
                        SINnersOptions.AddVisibilityForEmail(user.Body.Email);
                        this.Close();
                    }
                    else
                    {
                        login = false;
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                
            }
        }

        private void GetCookieContainer()
        {
            try
            {
                using (new CursorWait(true, this))
                {
                    Properties.Settings.Default.CookieData = null;
                    Properties.Settings.Default.Save();
                    var cookies =
                        StaticUtils.AuthorizationCookieContainer.GetCookies(new Uri(Properties.Settings.Default
                            .SINnerUrl));
                    var client = StaticUtils.GetClient(true);
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.TraceInformation(ex.ToString());
            }
            
        }

        private void FrmWebBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (login == false)
                GetCookieContainer();
        }
    }
}
