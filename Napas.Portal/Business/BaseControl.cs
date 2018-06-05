using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.Business
{
    public class BaseControl : UserControl
    {
        public string pageTitle;

        public string PageTitle
        {
            get { return pageTitle; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPageTitles(PageTitle);
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