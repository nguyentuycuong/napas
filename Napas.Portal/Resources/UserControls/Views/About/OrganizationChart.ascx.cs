using Microsoft.SharePoint;
using Napas.Portal.Business;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class OrganizationChart : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AboutBo aboutBo = new AboutBo(web);
                Organization retOrg = new Organization(web);
                var aboutInfoList = aboutBo.get_About(web, "0");
                rpAbout.DataSource = aboutInfoList;
                rpAbout.DataBind();

                var org = retOrg.getOrganizationChart(web);
                if (org.Any())
                {
                    var organizationChartInfor = org.FirstOrDefault();
                    if (organizationChartInfor != null) ltContent.Text = organizationChartInfor.description;
                }

                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "Organization").ToString();
                pageTitle += " - " + HttpContext.GetGlobalResourceObject("napas.resource", "OrganizationChart").ToString();
                SetPageTitles(pageTitle);
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