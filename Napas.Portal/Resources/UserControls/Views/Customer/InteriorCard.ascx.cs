using Napas.Portal.Business;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Linq;
using System.Web;

namespace Napas.Portal.ControlTemplates
{
    public partial class InteriorCard : BaseUserControl
    {
        CustomerInteriorCard catInteriorCard = new CustomerInteriorCard(SPContext.Current.Web);
        protected void Page_Load(object sender, EventArgs e)
        {
            //var web = SPContext.Current.Web;
            if (!IsPostBack)
            {
                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "InteriorCard").ToString();
                SetPageTitles(pageTitle);

                var description = catInteriorCard.get_Description();
                ltTitle.Text = description.Title;
                ltDescription.Text = description.Description;
                ltFeatureContent.Text = description.FeaturesCard;
                ltImages.Text = get_Images();

                //var customerBo = new CustomerTranfeBanking247Bo(SPContext.Current.Web);
                //var customerList = customerBo.get_AllItems();
                //if (customerList.Any())
                //{
                //    ltTitle.Text = customerList.FirstOrDefault().Custom_URL;
                //}
            }
        }
        protected string get_Images()
        {
            string ss = string.Empty;
            string s = string.Empty;
            var parrent = "<div class='item'>{0}</div>";
            var line = "<div class='' style='display: inline-block; padding-right: 5px;'><a> <img style='width:250px' src='{0}'/> </a></div>";
            var images = catInteriorCard.get_AllItems();
            for (int i = 1; i < images.Count + 1; i++)
            {
                ss += string.Format(line, images[i-1].Image);
                if (i>1 && i%6 == 0)
                {
                    s += string.Format(parrent, ss);
                    ss = string.Empty;
                }

               
                if (i== images.Count && i%6 != 0)
                {
                    s += string.Format(parrent, ss);
                }
            }


            return s;
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
