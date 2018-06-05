using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class OrganizationBoardCommittee : UserControl
    {

        protected string division;
        protected string buttonName;
        protected string ContentText;
        protected string PopupText;
        protected string levelText = "0";
        private SPWeb web = SPContext.Current.Web;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "Organization").ToString();
                pageTitle += " - " + HttpContext.GetGlobalResourceObject("napas.resource", "ExecutiveCommittee").ToString();
                SetPageTitles(pageTitle);

                if (SPContext.Current.Web.Language == 1033)
                {
                    division = Constants.OrgNameEn.ExecutiveCommittee;
                    buttonName = "Detail";
                }
                else
                {
                    division = Constants.OrgNameVn.ExecutiveCommittee;
                    buttonName = "Chi tiết";
                }

                var aboutBo = new AboutBo(web);
                var retOrg = new Organization(web);

                var aboutInfoList = aboutBo.get_About(web, "0");
                rpAbout.DataSource = aboutInfoList;
                rpAbout.DataBind();

                var items = retOrg.getOrganizationBroad(web, division);
                for (int loop = 0; loop < items.Count; loop++)
                {
                    //@"<div class='list-item active'>
                    //</div>
                    if (levelText != items[loop].level)
                    {
                        if (levelText == "0")
                            ContentText += @"<div class='list-item active'>";
                        else
                            ContentText += @"<div class='list-item'>";
                    }
                    ContentText += String.Format(@"<div class='item'>
                                            <div class='image'>
                                                <img src={0}>
                                            </div>
                                            <div class='text'>
                                                <h3 style='height: 35px;'>{1}</h3>
                                                <p style='height: 50px;'>{2}</p>
                                                <a class='read-more' href='' data-toggle='modal' data-target='#modal-info-organize{3}'>{4}</a>
                                            </div>
                                        </div>", items[loop].Image, items[loop].personname, items[loop].duty, items[loop].Id, buttonName);
                    levelText = items[loop].level;
                    if (loop + 1 == items.Count)
                        ContentText += "</div>";
                    else if (levelText != items[loop + 1].level)
                    {
                        ContentText += "</div>";
                    }
                    PopupText += string.Format(@"<div class='modal my-modal my-modal-organize fade' id='modal-info-organize{0}' tabindex='-1' role='dialog' aria-labelledby='mySmallModalLabel' style='display: none;'>
                                    <div class='modal-dialog'>
                                        <div class='modal-wrap'>
                                            <span class='close-modal' data-dismiss='modal' aria-label='Close'>
                                            </span>
                                            <div class='bank-modal broad-modal'>
                                                <div class='modal-image'>
                                                    <img src={1}>
                                                    <h3>{2}</h3>
                                                    <p>{3}</p>
                                                </div>
                                                <div class='modal-text'>
                                                    {4}
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>", items[loop].Id, items[loop].Image, items[loop].personname, items[loop].duty, items[loop].history);
                }
                ltContent.Text = ContentText;
                PopupContent(PopupText);
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

        private void PopupContent(string content)
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("PlaceHolderOutnerContent");
            contentPlaceHolder.Controls.Clear();
            LiteralControl title = new LiteralControl();
            title.Text = content;
            contentPlaceHolder.Controls.Add(title);
        }
    }
}