﻿using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Napas.Portal.ControlTemplates
{
    public partial class NewsCategory : UserControl
    {
        News newsBo;
        private SPWeb web = SPContext.Current.Web;
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 9;
        private int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {
                ViewState["CurrentPage"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                newsBo = new News(web);
                string id = Request.QueryString["catId"];
                string title = Request.QueryString["title"];
                //ltCat.Text = string.Format("<a href='{0}/newscategories.aspx?title={1}&catId={2}' class='current'>{1}</a>", web.Url, title, id);
                //ltNews.Text = string.Format("<a href='{0}/news.aspx'>{1}</a>", web.Url, "Tin tức");
                CurrentPage = 0;
                BindDataIntoRepeater();

                //<a href="/sites/napas/about" class="current">Tin Napas</a>
            }
        }
        private void BindDataIntoRepeater()
        {
            string id = Request.QueryString["catId"];
            var dt = newsBo.get_NewsCategory(web, id);
            if (dt != null)
            {
                _pgsource.DataSource = dt;
                _pgsource.AllowPaging = true;
                // Number of items to be displayed in the Repeater
                _pgsource.PageSize = _pageSize;
                _pgsource.CurrentPageIndex = CurrentPage;
                // Keep the Total pages in View State
                ViewState["TotalPages"] = _pgsource.PageCount;
                // Example: "Page 1 of 10"
                lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
                // Enable First, Last, Previous, Next buttons
                lbPrevious.Enabled = !_pgsource.IsFirstPage;
                lbNext.Enabled = !_pgsource.IsLastPage;
                lbFirst.Enabled = !_pgsource.IsFirstPage;
                lbLast.Enabled = !_pgsource.IsLastPage;

                // Bind data into repeater
                rpNewsHome.DataSource = _pgsource;
                rpNewsHome.DataBind();

                // Call the function to do paging
                HandlePaging();
            }

        }
        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            // Check last page is greater than total page then reduced it to total no. of page is last index
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }
        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BindDataIntoRepeater();
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindDataIntoRepeater();
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater();
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater();
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#00FF00");
        }
    }
}
