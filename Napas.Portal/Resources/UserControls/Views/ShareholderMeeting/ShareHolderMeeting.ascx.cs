using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class ShareHolderMeeting : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        protected string newsMeeting = string.Empty;
        protected string otherMeeting = string.Empty;
        private string category = "Đại Hội Cổ Đông";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var _category = Request.QueryString["category"];
                if (_category == null || _category == "dai-hoi-co-dong" || _category == "shareholders meeting")
                {
                    newsMeeting = "active";
                    category = web.Language == 1033 ? "Shareholders Meeting" : "Đại Hội Cổ Đông";
                }
                else
                {
                    otherMeeting = "active";
                    category = web.Language == 1033 ? "News Other" : "Tin tức khác";
                }

                Shareholder shareholderBo = new Shareholder(SPContext.Current.Web);
                rpShareholder.DataSource = shareholderBo.get_ShareholderItems(web, category);
                rpShareholder.DataBind();

                SetPageTitles(web.Language == 1033 ? "Shareholders meeting" : "Đại hội cổ đông");
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