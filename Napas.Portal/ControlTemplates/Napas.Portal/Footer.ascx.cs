using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Web.Caching;
using System.Web.UI;

namespace Napas.Portal.ControlTemplates
{
    public partial class Footer : UserControl
    {
        private static bool itemRemoved = false, cusItemRemoved = false;
        private static CacheItemRemovedReason reason;
        private CacheItemRemovedCallback onRemove = null;
        private static object _lock = new object();
        private SPWeb web = SPContext.Current.Web;

        private SettingsBo settingsBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                settingsBo = new SettingsBo(web);
                var settingInfo = settingsBo.get_SettingInfo(web);
                SiteLogoImage92.LogoImageUrl = settingInfo.LogoFooter;
                lbtEmail.NavigateUrl = string.Format("mailto:{0}", settingInfo.Email);
                lbtYoutube.NavigateUrl = settingInfo.YoutubeChanel;
                lbtFaceBook.NavigateUrl = settingInfo.Facebook;
                ltCompanyName.Text = settingInfo.CompanyName;
                ltCompanyNationalName.Text = settingInfo.CompanyNameEn;
            }
        }
    }
}