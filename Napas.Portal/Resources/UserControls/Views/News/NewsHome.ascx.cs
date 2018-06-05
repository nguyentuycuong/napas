using Microsoft.SharePoint;
using Napas.Portal.Business;
using Napas.Portal.Common;
using NAPAS.Portal.Common.Framework.Core.WebControls;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class NewsHome : BaseUserControl
    {
        private SPWeb web = SPContext.Current.Web;
        private readonly PagedDataSource _pgsource = new PagedDataSource();
        private CategoryNews catNew;
        private News newsBo;
        private int _firstIndex, _lastIndex;
        private Category catItem;
        private int _pageSize = 9;
        private string id;

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
                catNew = new CategoryNews(SPContext.Current.Web);
                newsBo = new News(SPContext.Current.Web);

                var pageTitle = HttpContext.GetGlobalResourceObject("napas.resource", "News").ToString();

                CurrentPage = Request.QueryString["page"] == null ? 1 : int.Parse(Request.QueryString["page"].ToString());

                var tbCategories = catNew.get_CategoryNews(web);
                id = Request.QueryString["catId"] == null ? tbCategories.Rows[0][Constants.CommonField.ID].ToString() : Request.QueryString["catId"].ToString();
                if (Request.QueryString["catId"] == null)
                {
                    if (tbCategories.Rows.Count > 0)
                        SetSessionString(Constants.SessionText.CategorySession, tbCategories.Rows[0][Constants.CommonField.ID].ToString(), true);
                    else
                        SetSessionString(Constants.SessionText.CategorySession, string.Empty, true);
                }
                else
                {
                    SetSessionString(Constants.SessionText.CategorySession, Request.QueryString["catId"].ToString(), true);
                }

                catItem = catNew.get_CategoryInfo(web, Convert.ToInt32(id));
                if (catItem != null)
                {
                    ltCat.Text = catItem.Url2;
                    pageTitle += " - " + catItem.Title;
                }

                SetPageTitles(pageTitle);
                BindDataIntoRepeater();
            }
        }

        private void BindDataIntoRepeater()
        {
            var dt = newsBo.get_NewsCategory(web, GetSessionString(Constants.SessionText.CategorySession));
            if (dt.Count <= 9)
                paging.Visible = false;
            _pgsource.DataSource = dt;
            _pgsource.AllowPaging = true;
            // Number of items to be displayed in the Repeater
            _pgsource.PageSize = _pageSize;
            _pgsource.CurrentPageIndex = CurrentPage - 1;
            // Keep the Total pages in View State
            ViewState["TotalPages"] = _pgsource.PageCount;
            rpNewsHome.DataSource = _pgsource;
            rpNewsHome.DataBind();
            HandlePaging();
        }

        private void HandlePaging()
        {
            if (CurrentPage > Convert.ToInt32(ViewState["TotalPages"]))
            {
                paging.Visible = false;
            }
            List<CategoryPaging> pagingData = new List<CategoryPaging>();

            if (Convert.ToInt32(ViewState["TotalPages"]) > 5)
            {
                if (CurrentPage == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new CategoryPaging
                        {
                            Id = int.Parse(id),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = i + 1,
                            text = i + 1,
                            Title = catItem.Title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else if (CurrentPage == 2)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new CategoryPaging
                        {
                            Id = int.Parse(id),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = i + 1,
                            text = i + 1,
                            Title = catItem.Title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else if (Convert.ToInt32(ViewState["TotalPages"]) - CurrentPage == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new CategoryPaging
                        {
                            Id = int.Parse(id),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = CurrentPage + i - 4,
                            text = CurrentPage + i - 4,
                            Title = catItem.Title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else if (Convert.ToInt32(ViewState["TotalPages"]) - CurrentPage == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new CategoryPaging
                        {
                            Id = int.Parse(id),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = CurrentPage + i - 3,
                            text = CurrentPage + i - 3,
                            Title = catItem.Title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        pagingData.Add(new CategoryPaging
                        {
                            Id = int.Parse(id),
                            Language = SPContext.Current.Web.Language,
                            currentPage = CurrentPage,
                            page = CurrentPage + i - 2,
                            text = CurrentPage + i - 2,
                            Title = catItem.Title,
                            WebUrl = SPContext.Current.Web.Url
                        });
                    }
                }
            }
            else
            {
                for (var i = 0; i < Convert.ToInt32(ViewState["TotalPages"]); i++)
                {
                    pagingData.Add(new CategoryPaging
                    {
                        Id = int.Parse(id),
                        Language = SPContext.Current.Web.Language,
                        currentPage = CurrentPage,
                        page = i + 1,
                        text = i + 1,
                        Title = catItem.Title,
                        WebUrl = SPContext.Current.Web.Url
                    });
                }
            }
            //previous button
            if (CurrentPage == 1)
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

            //contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("PlaceHolderPageTitleInTitleArea");
            //contentPlaceHolder.Controls.Clear();
            //title = new LiteralControl();
            //title.Text = Title;
            //contentPlaceHolder.Controls.Add(title);
        }
    }
}