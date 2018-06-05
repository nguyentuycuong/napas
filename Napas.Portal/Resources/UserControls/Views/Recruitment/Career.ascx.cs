using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class Career : BaseUserControl
    {
        private Recruitment retBo;
        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                retBo = new Recruitment(web);
                var app = retBo.get_AllApplicationInfor(web);
                if (app != null)
                    ltContent.Text = app.Content;
                SetPageTitles("Cơ hội nghề nghiệp");
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