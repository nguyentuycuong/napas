using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class ProductsServicesLeftMenu : UserControl
    {
        private static bool itemRemoved = false;
        private static CacheItemRemovedReason reason;
        private CacheItemRemovedCallback onRemove = null;
        private static object _lock = new object();
        private uint language = SPContext.Current.Web.Language;

        private ProductsServicesGroup productServiceGroupBo;
        private ProductService productServiceBo;
        private int parrentId = 0;

        private string serviceId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productServiceGroupBo = new ProductsServicesGroup(SPContext.Current.Web);
                productServiceBo = new ProductService(SPContext.Current.Web);

                serviceId = Request.QueryString["serviceId"];
                var catId = Request.QueryString["catId"];

                if (serviceId != null)
                {
                    int id = 0;
                    if (int.TryParse(serviceId, out id))
                    {
                        var currentItem = productServiceBo.get_ProductSeviceInfoById(serviceId);
                        if (currentItem != null)
                        {
                            parrentId = currentItem.SubServiceValue != null ? currentItem.SubServiceValue.LookupId : 0;
                        }
                    }
                }

                ParentRepeater.DataSource = productServiceGroupBo.get_ProductsServicesGroup(catId);
                ParentRepeater.DataBind();
            }
        }

        public ProductServiceInfo CacheData()
        {
            ProductServiceInfo productServiceInfo;

            lock (_lock)
            {
                onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                productServiceInfo = (ProductServiceInfo)Cache["productServiceInfo" + language];
                if (productServiceInfo == null || productServiceInfo.Id == 0)
                {
                    productServiceInfo = productServiceBo.get_ProductSeviceInfoById(Convert.ToString(serviceId));
                    Cache.Add("productServiceInfo" + language, productServiceInfo, null, DateTime.Now.AddSeconds(3), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
                }
            }

            return productServiceInfo;
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfParentId = (HiddenField)args.Item.FindControl("hfParentId");
                Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
                childRepeater.DataSource = productServiceBo.get_ProductServiceByGroup(hfParentId.Value, serviceId, parrentId);
                childRepeater.DataBind();
            }
        }

        protected void ChildRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfParentId = (HiddenField)args.Item.FindControl("hfLevel1Id");
                HiddenField hfHaveSubService = (HiddenField)args.Item.FindControl("hfHaveSubService");
                HtmlGenericControl ul = (HtmlGenericControl)args.Item.FindControl("ulChilrent");
                if (hfHaveSubService.Value == "False")
                {
                    ul.Visible = false;
                }
                Repeater childRepeater = (Repeater)args.Item.FindControl("subRepeater");
                childRepeater.DataSource = productServiceBo.get_ChilrentProductService(hfParentId.Value, serviceId);
                childRepeater.DataBind();
            }
        }

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            itemRemoved = true;
            reason = r;
        }
    }
}