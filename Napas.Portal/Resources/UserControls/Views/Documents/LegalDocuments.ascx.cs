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
    public partial class LegalDocuments : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        DocumentsLegal documentsLegalBo;
        DocumentGroup documentGroupBo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                documentsLegalBo = new DocumentsLegal(SPContext.Current.Web);
                documentGroupBo = new DocumentGroup(SPContext.Current.Web);

                rpDocumentShareholder.DataSource = documentGroupBo.get_DocumentByType(web, Constants.DocumentGroup.TypeValue.valueStringCollection[1], Constants.DocumentGroup.TypeValue.valueStringCollectionEn[1]);
                rpDocumentShareholder.DataBind();

                rpOtherDocument.DataSource = documentGroupBo.get_DocumentByType(web, Constants.DocumentGroup.TypeValue.valueStringCollection[2], Constants.DocumentGroup.TypeValue.valueStringCollectionEn[2]);
                rpOtherDocument.DataBind();

                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "LegalDocuments").ToString();
                SetPageTitles(pageTitle);
            }
        }

        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfDocumentType = (HiddenField)args.Item.FindControl("hfDocumentType");
                Repeater rpDocumentsItem = (Repeater)args.Item.FindControl("rpDocumentsItem");
                rpDocumentsItem.DataSource = documentsLegalBo.get_DocumentsLegalInfoItemsByDocumentType(web, hfDocumentType.Value);
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