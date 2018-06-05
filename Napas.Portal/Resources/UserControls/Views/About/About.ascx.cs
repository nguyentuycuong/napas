using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class About : UserControl
    {
        private SPWeb web = SPContext.Current.Web;
        private AboutBo aboutBo;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                aboutBo = new AboutBo(web);

                var id = Request.QueryString["Id"];
                int currentId = 0;
                var aboutInfoList = aboutBo.get_About(web, id);
                var aboutInfo = new AboutInfo();

                if (aboutInfoList.Any())
                {
                    if (!int.TryParse(id, out currentId))
                    {
                        aboutInfo = aboutInfoList[0];
                    }
                    else
                    {
                        aboutInfo = aboutInfoList.First(c => c.Id == currentId);
                    }

                    ltContent.Text = aboutInfo.Content;
                    ltCat.Text = aboutInfo.Title;

                    SetPageTitles(aboutInfo.Title);
                }

                rpAbout.DataSource = aboutInfoList;
                rpAbout.DataBind();
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