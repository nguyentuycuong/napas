using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class UserGuidePage : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userGuideBo = new UserGuide(SPContext.Current.Web);
            //var userGuideCollectionPaymentBo = new UserGuideForCollectionPayment(SPContext.Current.Web);
            ProductsServicesGroup productServiceGroupBo = new ProductsServicesGroup(SPContext.Current.Web);
            var productServiceBo = new ProductService(SPContext.Current.Web);

            var serviceId = Request.QueryString["serviceId"];
            var catId = Request.QueryString["catId"];
            if (!IsPostBack)
            {
                if ((string.IsNullOrEmpty(serviceId)))
                {
                    productServiceGroupBo.get_ProductServiceFirst(out catId, out serviceId);
                }

                var serviceInfo = productServiceBo.get_ProductSeviceInfoById(serviceId);
                var userGuideInfo = userGuideBo.get_FQAByProductService(serviceId);
                ltContent.Text = userGuideInfo.Content;
                ltServiceName.Text = serviceInfo.Title;
                ltProductServiceGroup.Text = serviceInfo.catValue;
                ltProductServices.Text = serviceInfo.Title;
                if (serviceInfo != null && serviceInfo.CollectPayOnBehalf)
                {
                    ltContent.Visible = false;
                    
                }

                SetPageTitles(serviceInfo.Title);
            }
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