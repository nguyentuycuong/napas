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
using System.Web;

namespace Napas.Portal.ControlTemplates
{
    public partial class ShoppingOnline : BaseUserControl
    {
        CustomerGroup custBo = new CustomerGroup(SPContext.Current.Web);
        PartnersCustomers partnersCustomers = new PartnersCustomers(SPContext.Current.Web);
        VendersBo vendersBo = new VendersBo(SPContext.Current.Web);
        protected void Page_Load(object sender, EventArgs e)
        {
            //var web = SPContext.Current.Web;
            if (!IsPostBack)
            {
                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "ShoppingOnline").ToString();
                SetPageTitles(pageTitle);

                var shoppingOnline = custBo.get_ShoppingOnline();
                ltHead.Text = shoppingOnline.Title;
                ltContent.Text = shoppingOnline.Description;
                ltVenders.Text = shoppingOnline.Venders;
                ltNote.Text = shoppingOnline.Note;

                rpBanks.DataSource = partnersCustomers.Get_PartnersCustomersInfoByIds(shoppingOnline.Banks);
                rpBanks.DataBind();

                rpCommunication.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Communication);
                rpCommunication.DataBind();

                rpDigital.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Digital);
                rpDigital.DataBind();

                rpElectronicWallet.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.ElectronicWallet);
                rpElectronicWallet.DataBind();

                rpEnsurance.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Ensurance);
                rpEnsurance.DataBind();

                rpGame.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Game);
                rpGame.DataBind();

                rpOthers.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Other);
                rpOthers.DataBind();

                rpRetail.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Retail);
                rpRetail.DataBind();

                rpTranformer.DataSource = vendersBo.Get_VenderInfoByIds(shoppingOnline.Tranformer);
                rpTranformer.DataBind();
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
