using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.UI;

namespace Napas.Portal.ControlTemplates
{
    public partial class MenuTop : UserControl
    {
        private static bool itemRemoved = false, cusItemRemoved = false;
        private static CacheItemRemovedReason reason;
        private CacheItemRemovedCallback onRemove = null;
        private static object _lock = new object();
        private uint language = SPContext.Current.Web.Language;
        private SettingsBo settingsBo;
        private SPWeb web = SPContext.Current.Web;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                settingsBo = new SettingsBo(SPContext.Current.Web);

                ltStyle.Text = CacheBanerPage();

                var settingInfo = settingsBo.get_SettingInfo(web);
                ltLogo.Text = string.Format("<img alt=\"NAPAS\" src=\"{0}\" />", settingInfo.Logo);
                ltMobile.Text = string.Format("<a href=\"tel:{0}\">{0}</a>", settingInfo.Mobile);
                ltMobile2.Text = string.Format("<a href=\"tel:{0}\">{0}</a>", settingInfo.Mobile);
            }
        }

        private string CacheBanerPage()
        {
            string baner;
            lock (_lock)
            {
                onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                baner = (string)Cache["BanerPages" + language];
                if (string.IsNullOrEmpty(baner))
                {
                    baner = GetBanerPage();
                    Cache.Add("BanerPages" + language, baner, null, DateTime.Now.AddMinutes(1), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
                }
            }

            return baner;
        }

        private string GetBanerPage()
        {
            SettingsBo settingBo = new SettingsBo(web);

            string style = @"<style>.intro-banner {
                                  background-image: url({-1});
                                  height: 300px;
                                  background-repeat: no-repeat;
                                  background-size: cover;
                                  background-position: center center; }
                                  @media screen and (max-width: 991px) {
                                    .intro-banner {
                                      height: 121px; } }
                                .intro-banner.intro-banner-news {
                                    background-image: url({0}); }
                                  .intro-banner.intro-banner-service {
                                    background-image: url({1}); }
                                  .intro-banner.intro-banner-customer {
                                    background-image: url({2}); }
                                  .intro-banner.intro-banner-ns {
                                    background-image: url({3}); }
                                  .intro-banner.intro-banner-dk {
                                    background-image: url({4}); }
                                  .intro-banner-cd {background-image: url({5}); }
                                  .intro-banner-tl {background-image: url({6}); }
                                  .intro-banner-hotline {background-image: url({7}); }
                                </style>";
            var setting = settingBo.get_SettingInfo(web);
            style = style.Replace("{-1}", setting.BanerAboutUs);
            style = style.Replace("{0}", setting.BanerNews);
            style = style.Replace("{1}", setting.BanerProduct);
            style = style.Replace("{2}", setting.BanerCustomer);
            style = style.Replace("{3}", setting.BanerCeare);
            style = style.Replace("{4}", setting.BanerTermCondition);
            style = style.Replace("{5}", setting.BanerPartner);
            style = style.Replace("{6}", setting.BanerDocument);
            style = style.Replace("{7}", setting.BanerHotline);

            return style;
        }

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            itemRemoved = true;
            reason = r;
        }

        public void RemovedCustomerCallback(String k, Object v, CacheItemRemovedReason r)
        {
            cusItemRemoved = true;
            reason = r;
        }
    }
}