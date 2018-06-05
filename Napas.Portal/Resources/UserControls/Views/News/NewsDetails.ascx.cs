using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class NewsDetails : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        private News newsBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "News").ToString();
                newsBo = new News(web);

                int id = 0;
                string catId = "0";
                int.TryParse(Request.QueryString["ID"], out id);

                var newsInfo = newsBo.get_NewItem(web, id);
                if (newsInfo != null && newsInfo.Id > 0)
                {
                    ltCat.Text = newsInfo.UrlCat;
                    ltContent.Text = newsInfo.Content;
                    ltCreated.Text = newsInfo.Created;
                    ltDescription.Text = newsInfo.Description;
                    ltTitle.Text = newsInfo.Title;
                    catId = newsInfo.CategoryID;
                    SetPageTitles(newsInfo.Title);
                }

                var dtCate = newsBo.get_SomeNews(web, id, catId);
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