using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class UserGuideLeftMenu : UserControl
    {
        ProductsServicesGroup productServiceGroupBo = new ProductsServicesGroup(SPContext.Current.Web);
        ProductService productServiceBo = new ProductService(SPContext.Current.Web);

        private string serviceId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            serviceId = Request.QueryString["serviceId"];
            var catId = Request.QueryString["catId"];

            
            if ((string.IsNullOrEmpty(serviceId) || string.IsNullOrEmpty(catId)))
            {
                productServiceGroupBo.get_ProductServiceFirst(out catId, out serviceId);
            }

            ParentRepeater.DataSource = productServiceGroupBo.get_ProductsServicesGroup(catId);
            ParentRepeater.DataBind();
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfParentId = (HiddenField)args.Item.FindControl("hfParentId");
                Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
                childRepeater.DataSource = productServiceBo.get_ProductServiceByGroup(hfParentId.Value, serviceId, 0);
                childRepeater.DataBind();
            }
        }
    }
}