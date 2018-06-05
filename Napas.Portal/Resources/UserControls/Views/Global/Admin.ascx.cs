using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Napas.Portal.Business;

namespace Napas.Portal.ControlTemplates
{
    public partial class Admin : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            var group = web.SiteGroups;

            if (!IsPostBack)
            {
                var companyName = "Trang quản trị"; //HttpContext.GetGlobalResourceObject("napas.resource", "CompanyName").ToString();
                SetPageTitles(companyName);

                if (web.CurrentUser == null)
                {
                    SPIisSettings iisSettings = SPContext.Current.Site.WebApplication.IisSettings[SPUrlZone.Default];

                    if (null != iisSettings && iisSettings.UseWindowsClaimsAuthenticationProvider)
                    {
                        SPAuthenticationProvider provider = iisSettings.WindowsClaimsAuthenticationProvider;

                        RedirectToLoginPage(provider);
                    }
                }
            }
        }

        private void RedirectToLoginPage(SPAuthenticationProvider provider)
        {
            string components = HttpContext.Current.Request.Url.GetComponents(UriComponents.Query,
                UriFormat.SafeUnescaped);

            string url = provider.AuthenticationRedirectionUrl.ToString();

            if (provider is SPWindowsAuthenticationProvider)
            {
                components = EnsureUrlSkipsFormsAuthModuleRedirection(components, true);
            }

            SPUtility.Redirect(url, SPRedirectFlags.Default, this.Context, components + "=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()));
        }

        private string EnsureUrlSkipsFormsAuthModuleRedirection(string url, bool urlIsQueryStringOnly)
        {
            if (!url.Contains("ReturnUrl="))
            {
                if (urlIsQueryStringOnly)
                {
                    url = url + (string.IsNullOrEmpty(url) ? "" : "&");
                }
                else
                {
                    url = url + ((url.IndexOf('?') == -1) ? "?" : "&");
                }

                url = url + "ReturnUrl";
            }

            return url;
        }

        private void SetPageTitles(string Title)
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("PlaceHolderPageTitle");
            contentPlaceHolder.Controls.Clear();
            LiteralControl title = new LiteralControl();
            title.Text = Title;
            contentPlaceHolder.Controls.Add(title);

            //contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("PlaceHolderPageTitleInTitleArea");
            //contentPlaceHolder.Controls.Clear();
            //title = new LiteralControl();
            //title.Text = Title;
            //contentPlaceHolder.Controls.Add(title);
        }

        
    }
}