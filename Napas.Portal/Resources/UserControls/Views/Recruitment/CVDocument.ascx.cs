using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class CVDocument : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Recruitment retBo = new Recruitment(web);
                rpCVDocument.DataSource = retBo.get_AllCVDocuments(web);
                rpCVDocument.DataBind();

                SetPageTitles("Mẫu ứng viên");
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