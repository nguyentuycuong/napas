﻿using Napas.Portal.Business;
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
    public partial class thanh_toan_hoa_don_uy_nhiem_chi_tu_dong : BaseUserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //var web = SPContext.Current.Web;
            if (!IsPostBack)
            {
                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "PayBills").ToString();
                SetPageTitles(pageTitle);

                var topupBo = new PayBills(SPContext.Current.Web);
                var partnerBo = new PartnersCustomers(SPContext.Current.Web);
                var customer = topupBo.get_PaybillsInfoInfo();
                if (customer.Id > 0)
                {
                    ltHeader.Text = customer.Title;
                    ltContent.Text = customer.Content;
                    ltNote.Text = customer.Note;

                    rpBanks.DataSource = partnerBo.Get_PartnersCustomersInfoByIds(customer.Banks);
                    rpBanks.DataBind();
                }
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