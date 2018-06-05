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
using System.Collections.Generic;
using System.Web;

namespace Napas.Portal.ControlTemplates
{
    public partial class Promotions : BaseUserControl
    {
        SPWeb web = SPContext.Current.Web;
        CustomerGroup custBo = new CustomerGroup(SPContext.Current.Web);
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 9;
        string title;
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
            if (web.Language == 1033)
            {
                title = "promotion";
            }
            else
            {
                title = "chuong-trinh-khuyen-mai";
            }
            if (!IsPostBack)
            {
                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "Promotion").ToString();
                SetPageTitles(pageTitle);

                CurrentPage = 0;
                BindDataIntoRepeater();
            }
        }
        private void BindDataIntoRepeater()
        {
            var dt = custBo.get_Promotion();
            if (dt != null)
            {
                if (dt.Count <= 9)
                    paging.Visible = false;
                _pgsource.DataSource = dt;
                _pgsource.AllowPaging = true;
                // Number of items to be displayed in the Repeater
                _pgsource.PageSize = _pageSize;
                _pgsource.CurrentPageIndex = CurrentPage;
                // Keep the Total pages in View State
                ViewState["TotalPages"] = _pgsource.PageCount;
                rpPromotion.DataSource = _pgsource;
                rpPromotion.DataBind();

                // Call the function to do paging
                HandlePaging();
            }

        }
        private void HandlePaging()
        {
            if (CurrentPage > Convert.ToInt32(ViewState["TotalPages"]))
            {
                paging.Visible = false;
            }
            List<PromotionPaging> pagingData = new List<PromotionPaging>();


            if (Convert.ToInt32(ViewState["TotalPages"]) > 5)
            {
                if (CurrentPage == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new PromotionPaging
                        {
                            Id = int.Parse("3"),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = i + 1,
                            text = i + 1,
                            Title = title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else if (CurrentPage == 2)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new PromotionPaging
                        {
                            Id = int.Parse("3"),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = i + 1,
                            text = i + 1,
                            Title = title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else if (Convert.ToInt32(ViewState["TotalPages"]) - CurrentPage == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new PromotionPaging
                        {
                            Id = int.Parse("3"),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = CurrentPage + i - 4,
                            text = CurrentPage + i - 4,
                            Title = title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else if (Convert.ToInt32(ViewState["TotalPages"]) - CurrentPage == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new PromotionPaging
                        {
                            Id = int.Parse("3"),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = CurrentPage + i - 3,
                            text = CurrentPage + i - 3,
                            Title = title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new PromotionPaging
                        {
                            Id = int.Parse("3"),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = CurrentPage + i - 2,
                            text = CurrentPage + i - 2,
                            Title = title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
            }
            else
            {
                for (var i = 0; i < Convert.ToInt32(ViewState["TotalPages"]); i++)
                {
                    pagingData.Add(new PromotionPaging
                    {
                        Id = int.Parse("3"),
                        Language = SPContext.Current.Web.Language,
                        currentPage = CurrentPage,
                        page = i + 1,
                        text = i + 1,
                        Title = title,
                        WebUrl = SPContext.Current.Web.Url
                    });
                }
            }
            //previous button
            if (CurrentPage == 0)
            {
                previous.HRef = pagingData[0].UrlCurr;
                previous.Disabled = true;
            }
            else
            {
                previous.HRef = pagingData[0].UrlPrevious;
            }
            //next button
            if (CurrentPage == Convert.ToInt32(ViewState["TotalPages"]))
            {
                next.HRef = pagingData[0].UrlCurr;
                next.Disabled = true;
            }
            else
            {
                next.HRef = pagingData[0].UrlNext;
            }
            rptPaging.DataSource = pagingData;
            rptPaging.DataBind();
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
