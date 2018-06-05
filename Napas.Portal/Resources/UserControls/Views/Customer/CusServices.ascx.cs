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
    public partial class CusServices : BaseUserControl
    {
        CategoryNews catNewsBo = new CategoryNews(SPContext.Current.Web);
        protected void Page_Load(object sender, EventArgs e)
        {
            //var web = SPContext.Current.Web;
            if (!IsPostBack)
            {
                var query = Request.QueryString["catId"];
                var catId = 0;
                if (int.TryParse(query, out catId))
                {
                    
                }
                var dt = catNewsBo.get_Category(Convert.ToString(catId));
                rpLeftMenu.DataSource = dt;
                rpLeftMenu.DataBind();
            }
        }

        protected void rpLeftMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var sessionCate = GetSessionString(Constants.SessionText.CategorySession);
            var ilControl = (HtmlGenericControl)e.Item.FindControl("pager");
            if (!ilControl.InnerText.Contains(sessionCate)) return;
            ilControl.Attributes.Add("class", "active"); 
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
