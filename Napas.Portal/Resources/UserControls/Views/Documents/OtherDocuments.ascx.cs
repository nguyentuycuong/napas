using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class OtherDocuments : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DocumentsOther documentsOtherBo = new DocumentsOther(web);
                DocumentGroup documentGroupBo = new DocumentGroup(web);

                var catId = Request.QueryString["catId"];
                int cat = 0;
                if (!int.TryParse(catId, out cat))
                {
                    catId = "0";
                }

                rpOtherDocument.DataSource = documentGroupBo.get_DocumentType(web, Constants.DocumentGroup.TypeValue.valueStringCollection[2], catId);
                rpOtherDocument.DataBind();

                var items = documentsOtherBo.get_DocumentsLegalInfoItemsByDocumentType(web, Convert.ToString(catId));
                rpDocumentsItem.DataSource = items;
                rpDocumentsItem.DataBind();

                if (items.Count > 0)
                {
                    ltDocumentGroup.Text = items[0].DocumentType;
                    ltDocumentGroupName.Text = items[0].DocumentType;

                    SetPageTitles(items[0].DocumentType);
                }

                //var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "LegalDocuments").ToString();
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