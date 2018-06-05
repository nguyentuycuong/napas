using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Core.Framework.Helpers;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class OrganizationalStructure : UserControl
    {
        private SPWeb web = SPContext.Current.Web;
        private Organization newsOrganization;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newsOrganization = new Organization(web);
                var data = newsOrganization.getOrganization(web);
                DataSet ds = new DataSet();
                ds.Merge(data);
                trvOrganization.DataSource = new HierarchicalDataSet(ds, "Id", "parentId");
                trvOrganization.DataBind();

                SetPageTitles("Cơ cấu tổ chức");
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