using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class ShareHolderMeetingdetails : BaseUserControl
    {
        private string category = "Đại Hội Cổ Đông";
        protected string newsMeeting = string.Empty;
        protected string otherMeeting = string.Empty;

        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var _category = Request.QueryString["category"];
                if (_category == null || _category == "dai-hoi-co-dong")
                {
                    newsMeeting = "active";
                }
                else
                {
                    otherMeeting = "active";
                    category = "Tin tức khác";
                }


                Shareholder shareholderBo = new Shareholder(SPContext.Current.Web);
                var id = Request.QueryString["id"];
                var holderId = 0;
                if (!string.IsNullOrEmpty(id))
                {
                    if (int.TryParse(id, out holderId))
                    {
                        var shareholderInfo = shareholderBo.get_ShareholderItemId(web, holderId);
                        if (shareholderInfo != null && shareholderInfo.Id > 0)
                        {
                            ltTitle.Text = shareholderInfo.Title;
                            ltContent.Text = shareholderInfo.Content;
                            ltCreated.Text = shareholderInfo.Created;
                            ltDescription.Text = shareholderInfo.Description;
                            SetPageTitles(shareholderInfo.Title);
                        }
                    }

                    rpRelated.DataSource = shareholderBo.get_Top10ShareholderItems(web, holderId, category);
                    rpRelated.DataBind();
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