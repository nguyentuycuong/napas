using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Napas.Portal.ControlTemplates
{
    public partial class PromotionDetails : BaseUserControl
    {
        CustomerGroup cusBo = new CustomerGroup(SPContext.Current.Web);
        News newsBo = new News(SPContext.Current.Web);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                int id;                
                if (Request.QueryString["ID"] != null)
                    id = int.Parse(Request.QueryString["ID"]);
                else
                    id = 0;

                var newsInfo = cusBo.get_PromotionItem(id);
                if (newsInfo != null)
                {
                    ltContent.Text = newsInfo.Content;
                    ltCreated.Text = newsInfo.Created;
                    ltDescription.Text = newsInfo.Description;
                    ltTitle.Text = newsInfo.Title;
                    SetPageTitles(newsInfo.Title);
                }
                var dtCate = cusBo.get_SomeNews(id);
                rpRelated.DataSource = dtCate;
                rpRelated.DataBind();
                if (dtCate.Count == 0)
                    divRef.Visible = false;
                
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
