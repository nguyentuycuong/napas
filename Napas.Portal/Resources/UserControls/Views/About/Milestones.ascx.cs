using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class Milestones : UserControl
    {
       
        private AboutBo aboutBo;
        private SPWeb web = SPContext.Current.Web;
        public int iCounter = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                aboutBo = new AboutBo(SPContext.Current.Web);
                getMilestone(web);

                var aboutInfoList = aboutBo.get_About(web, "0");
                rpAbout.DataSource = aboutInfoList;
                rpAbout.DataBind();

                var text = "Các mốc lịch sử, thành tựu";
                if(web.Language == 1033)
                {
                    text = "Milestones, Achievements";
                }

                ltCat.Text = text;
                SetPageTitles(text);
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

        private void getMilestone(SPWeb web)
        {
            var listName = web.Language == 1033
                ? Constants.MilestonesAchievements.ListNameEnglish
                : Constants.MilestonesAchievements.ListName;
            var list = web.Lists[listName];
            var q = CamlexNET.Camlex.Query()
                    .Where(c => (Boolean)c[Constants.MilestonesAchievements.InternalFields.Activate])
                    .OrderBy(c => c[Constants.MilestonesAchievements.InternalFields.Year] as Camlex.Desc)
                    .ToSPQuery();

            var items = list.GetItems(q);

            rpMilestones.DataSource = items.GetDataTable();
            rpMilestones.DataBind();
        }
    }
}