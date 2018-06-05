using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;

namespace Napas.Portal.ControlTemplates
{
    public partial class NewsLeftMenu : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            //var web = SPContext.Current.Web;
            if (!IsPostBack)
            {
                CategoryNews catNewsBo = new CategoryNews(SPContext.Current.Web);
                var catIdFromQuery = Request.QueryString["catId"];
                var catId = 0;
                int.TryParse(catIdFromQuery, out catId);

                var dt = catNewsBo.get_Category(web, Convert.ToString(catId));
                rpLeftMenu.DataSource = dt;
                rpLeftMenu.DataBind();
            }
        }
    }
}