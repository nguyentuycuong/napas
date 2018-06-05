using Napas.Portal.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Napas.Portal.ControlTemplates
{
    public partial class CustomerLeftMenu : BaseUserControl
    {
        CustomerGroup customerGroupBo = new CustomerGroup(SPContext.Current.Web);
        private string serviceId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            serviceId = String.IsNullOrEmpty(Request.QueryString["serviceId"]) ? string.Empty : Request.QueryString["serviceId"];
            var catId = String.IsNullOrEmpty(Request.QueryString["catId"]) ? string.Empty : Request.QueryString["catId"];
            if (!IsPostBack)
            {
                CustomerRepeater.DataSource = customerGroupBo.get_CustomerServicesGroup(catId);
                CustomerRepeater.DataBind();
            }
        }
       
    }
}
