using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class DocumentShareholder : BaseUserControl
    {

        Document_Shareholder documentShareholderBo;
        DocumentGroup documentGroupBo;
        private SPWeb web = SPContext.Current.Web;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                documentShareholderBo = new Document_Shareholder(web);
                documentGroupBo = new DocumentGroup(web);

                rpDocumentShareholder.DataSource = documentGroupBo.get_DocumentByType(web, Constants.DocumentGroup.TypeValue.valueStringCollection[0], Constants.DocumentGroup.TypeValue.valueStringCollectionEn[0]);
                rpDocumentShareholder.DataBind();
                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "DocumentPartner").ToString();
                SetPageTitles(pageTitle);
            }
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfDocumentType = (HiddenField)args.Item.FindControl("hfDocumentType");
                Repeater rpDocumentsItem = (Repeater)args.Item.FindControl("rpDocumentsItem");
                rpDocumentsItem.DataSource = documentShareholderBo.get_ShareholderItemsByDocumentType(web, hfDocumentType.Value);
                rpDocumentsItem.DataBind();
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