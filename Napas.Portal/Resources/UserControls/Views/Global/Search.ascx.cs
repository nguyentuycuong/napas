using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Server.Search.Query;
using System.Data;
using System.Drawing;

namespace Napas.Portal.ControlTemplates
{
    public partial class Search : UserControl
    {
        private SPWeb web = SPContext.Current.Web;
        readonly PagedDataSource _pgsource = new PagedDataSource();
        int _firstIndex, _lastIndex;
        private int _pageSize = 100;
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

        private static DataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SetPageTitles("Tìm kiếm");
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            string k = Request.QueryString["k"];

                            KeywordQuery keywordQuery = new KeywordQuery(web);

                            keywordQuery.QueryText = k;
                            keywordQuery.QueryText += "(contentclass:STS_List OR contentclass:STS_List_DocumentLibrary) CustomeURL:.aspx";
                            //keywordQuery.QueryText = "scope:\"All Sites\" AND (contentclass:\"STS_Site\" OR contentclass:\"STS_Web\")";
                            keywordQuery.StartRow = 0;
                            keywordQuery.RowLimit = 500;
                            //keywordQuery.SourceId = PeopleSearch;
                            keywordQuery.EnableNicknames = true;
                            keywordQuery.EnablePhonetic = true;
                            keywordQuery.TrimDuplicates = false;

                            //which columns should be returned in the query result. 

                            keywordQuery.SelectProperties.Add("title");
                            keywordQuery.SelectProperties.Add("CustomeURL");
                            keywordQuery.SelectProperties.Add("ImageUrl");

                            SearchExecutor searchExecutor = new SearchExecutor();
                            ResultTableCollection resultTableCollection = searchExecutor.ExecuteQuery(keywordQuery);
                            var resultTables = resultTableCollection.Filter("TableType", KnownTableTypes.RelevantResults);

                            if (resultTables != null && resultTables.Any())
                            {
                                var resultTable = resultTables.FirstOrDefault();

                                if (resultTable != null)
                                {
                                    DataTable dataTable = resultTable.Table;
                                    //rpResult.DataSource = dataTable;
                                    //rpResult.DataBind();
                                    BindDataIntoRepeater(dataTable);
                                    table = dataTable;
                                }
                                else
                                {
                                    table = new DataTable();
                                }
                            }
                            else
                            {
                                table = new DataTable();
                            }
                        }
                    }
                });
            }
        }
        private void BindDataIntoRepeater(DataTable dt)
        {            
            if (dt.Rows.Count > 0)
            {
                _pgsource.DataSource = dt.DefaultView;
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
                rpResult.DataSource = _pgsource;
                rpResult.DataBind();

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
            BindDataIntoRepeater(table);
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindDataIntoRepeater(table);
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater(table);
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater(table);
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater(table);
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#00FF00");
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