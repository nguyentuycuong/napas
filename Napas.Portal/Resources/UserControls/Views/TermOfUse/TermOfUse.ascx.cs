using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class TermOfUse : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            //var web = SPContext.Current.Web;
            if (!IsPostBack)
            {
                TemOfUseBo catNewsBo = new TemOfUseBo(SPContext.Current.Web);
                var idFromQuery = Request.QueryString["id"];
                var dt = catNewsBo.get_Allitems(web, Convert.ToString(idFromQuery));
                rpItems.DataSource = dt;
                rpItems.DataBind();

                if (dt.Any())
                {
                    string title = string.Empty;
                    var id = 0;
                    if (!int.TryParse(idFromQuery, out id))
                    {
                        var termOfUse = dt.First();
                        ltContent.Text = termOfUse.Content;
                        ltCat.Text = termOfUse.Title;
                        title = termOfUse.Title;
                    }
                    else
                    {
                        var termInfo = dt.First(c => c.Id == id);
                        ltContent.Text = termInfo.Content;
                        ltCat.Text = termInfo.Title;
                        title = termInfo.Title;
                    }

                    SetPageTitles(title);
                }
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