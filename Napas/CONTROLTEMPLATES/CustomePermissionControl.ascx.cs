using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Napas.CONTROLTEMPLATES
{
    public partial class CustomePermissionControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(SPContext.Current.Web.CurrentUser == null)
                {
                    //SPUtility.TransferToErrorPage(SPUtility.AccessDeniedPage);
                }
            }
        }
    }
}
