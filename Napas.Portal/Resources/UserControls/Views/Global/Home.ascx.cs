using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class Home : UserControl
    {
        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var newsBo = new News(web);
                var settingBo = new SettingsBo(web);

                SliderBo sliderBo = new SliderBo(web);

                var companyName = HttpContext.GetGlobalResourceObject("napas.resource", "CompanyName").ToString();
                SetPageTitles(companyName);

                rpNewsHome.DataSource = newsBo.get_NewsHome(web);
                rpNewsHome.DataBind();

                var settingInfo = settingBo.get_SettingInfo(web);
                var youtube = settingInfo.Youtube;
                if(!youtube.Contains("rel=="))
                {
                    youtube = youtube + "?rel=0";
                }


                ltVideoSource.Text = string.Format("<iframe width=\"100%\" height=\"100%\" id=\"ifram\" src=\"{0}\" frameborder=\"0\" allowfullscreen=\"\"></iframe>", settingInfo.Youtube);
                ltVideoDescription.Text = settingInfo.VideoDescription;

                var listSlider = sliderBo.get_SliderInfo(web);
                string style = "<style>{0}</style>";
                string styleContent = string.Empty;
                var s = @"@media screen and (max-width: 4096px) {
                    .home-slider .slider0{0} {
                     background-image: url({1}) !important; } }
                    @media screen and (max-width: 1366px) {
                    .home-slider .slider0{0} {
                     background-image: url({1}) !important; } }
                    @media screen and (max-width: 1024px) {
                     .home-slider .slider0{0} {
                     background-image: url({2}) !important; } }
                    @media (max-width: 480px) {
                        .home-slider .slider0{0} {
                        background-image: url({3}) !important; } }";

                foreach (SliderInfo info in listSlider)
                {
                    styleContent += s.Replace("{0}", info.Index)
                        .Replace("{1}", info.Image1366)
                        .Replace("{2}", info.Image1024)
                        .Replace("{3}", string.IsNullOrEmpty(info.Image480) ? info.Image1024 : info.Image480); //string.Format(s, info.Index, info.Image1366, info.Image1024);
                }

                ltStyle.Text = string.Format(style, styleContent);

                rpSlider.DataSource = listSlider;
                rpSlider.DataBind();
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