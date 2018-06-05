using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class ContactGeneral : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(web.Language == 1033)
                {
                    btnSubmit.Text = "Send";
                }
                ContactBo contactBo = new ContactBo(web);
                var pageTitle = "Contacts";
                var id = Request.QueryString["Id"];
                var items = contactBo.get_ContactInfo(web, id);
                if (items.Count > 0)
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        var currrentItem = items[0];
                        ltContact.Text = currrentItem.Title;
                        ltContent.Text = currrentItem.Content;
                        pageTitle = currrentItem.Title;
                    }
                    else
                    {
                        int contactId = 0;
                        if (int.TryParse(id, out contactId))
                        {
                            var contact = items.First(c => c.Id == contactId);
                            ltContact.Text = contact.Title;
                            ltContent.Text = contact.Content;
                            pageTitle = contact.Title;
                        }
                    }
                }

                SetPageTitles(pageTitle);

                rpContact.DataSource = items;
                rpContact.DataBind();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;
                        var list = web.Lists[Constants.Contact.ListName];
                        SPListItem item = list.AddItem();
                        item[Constants.Contact.InternalFields.Name] = txtName.Text;
                        item[Constants.Contact.InternalFields.Mobile] = txtPhone.Text;
                        item[Constants.Contact.InternalFields.Email] = txtEmail.Text;
                        item[Constants.Contact.InternalFields.Subject] = txtSubject.Text;
                        item[Constants.Contact.InternalFields.Content] = txtContent.Text;
                        item.SystemUpdate();
                        web.AllowUnsafeUpdates = false;

                        ltMessage.Text = "Bạn đã gửi liên hệ thành công.<br/>";
                        txtContent.Text = string.Empty;
                        txtName.Text = string.Empty;
                        txtPhone.Text = string.Empty; txtSubject.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                    }
                }
            });
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