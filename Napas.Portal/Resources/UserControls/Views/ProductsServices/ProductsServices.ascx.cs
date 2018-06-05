using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class ProductsServices : UserControl
    {
        #region Init page

        private static bool itemRemoved = false;
        private static CacheItemRemovedReason reason;
        private CacheItemRemovedCallback onRemove = null;
        private static object _lock = new object();
        private ProductsServicesGroup productServiceBo;
        private uint language = SPContext.Current.Web.Language;

        #endregion Init page

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productServiceBo = new ProductsServicesGroup(SPContext.Current.Web);
                rpProductsServicesMenuTop.DataSource = CacheData();
                rpProductsServicesMenuTop.DataBind();

                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "Products_Services").ToString();
                SetPageTitles(pageTitle);
            }
        }

        public List<ProductsServicesGroupInfo> CacheData()
        {
            List<ProductsServicesGroupInfo> oListItems;

            lock (_lock)
            {
                onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                oListItems = (List<ProductsServicesGroupInfo>)Cache["ProductsServicesGroup" + language];
                if (oListItems == null || !oListItems.Any())
                {
                    oListItems = productServiceBo.get_ProductsServicesGroup(string.Empty);
                    Cache.Add("ProductsServicesGroup" + language, oListItems, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
                }
            }

            return oListItems;
        }

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            itemRemoved = true;
            reason = r;
        }

        private void SetPageTitles(string Title)
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("PlaceHolderPageTitle");
            contentPlaceHolder.Controls.Clear();
            LiteralControl title = new LiteralControl();
            title.Text = Title;
            contentPlaceHolder.Controls.Add(title);
        }
    }
}