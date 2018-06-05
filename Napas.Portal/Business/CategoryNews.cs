using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Napas.Portal.Business
{
    public class CategoryNews
    {
        public static string listName;
        
        public CategoryNews(SPWeb _web)
        {
            
            if (_web.Language == 1033)
            {
                listName = Constants.CategoryNews.ListNameEnglish;
            }
            else
            {
                listName = Constants.CategoryNews.ListName;
            }

            
        }

        /// <summary>
        /// Cac funtion dung de hien thi du lieu, day em moi lam mau thoi,  fai filter theo cac dk nhu la activate = true, ...
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public DataTable get_CategoryNews(SPWeb web)
        {
            var list = web.Lists[listName];
            var query = Camlex.Query().Where(c => (Boolean)c[Constants.CategoryNews.InternalFields.Activate] == true).OrderBy(c => c[Constants.CategoryNews.InternalFields.Order] as Camlex.Asc).ToSPQuery();

            return list.GetItems(query).GetDataTable();
        }

        public List<Category> get_Category(SPWeb web, string currentCatId)
        {
            var iCategory = new List<Category>();

            var query = Camlex.Query().Where(c => (Boolean)c[Constants.CategoryNews.InternalFields.Activate] == true).OrderBy(c => c[Constants.CategoryNews.InternalFields.Order] as Camlex.Asc).ToSPQuery();

            var list = web.Lists[listName];
            var items = list.GetItems(query);
            if (items.Count>0)
            {
                if (string.IsNullOrEmpty(currentCatId) || currentCatId.Equals("0"))
                {
                    currentCatId = Convert.ToString(items[0].ID);
                }
            }

            iCategory.AddRange(from SPListItem item in items select new Category { Id = item.ID, Title = item.Title, Language = web.Language, WebUrl = web.Url, Active = currentCatId});

            return iCategory;
        }

        public Category get_CategoryInfo(SPWeb web, int catId)
        {
            var query = Camlex.Query().Where(c => (int)c[Constants.CommonField.ID] == catId).ToSPQuery();
            var list = web.Lists[listName];
            var items = list.GetItems(query);
            if (items.Count > 0)
            {
                return new Category
                {
                    Title = items[0].Title,
                    Id = items[0].ID,
                    Language = web.Language,
                    WebUrl = web.Url,
                    
                };
            }

            return new Category();
        }

        public List<Category> get_Top2Category(SPWeb web)
        {
            var list = web.Lists[listName];
            var iCategory = new List<Category>();

            var query = Camlex.Query().Where(c => (Boolean)c[Constants.CategoryNews.InternalFields.Activate] == true).OrderBy(c => c[Constants.CategoryNews.InternalFields.Order] as Camlex.Asc).ToSPQuery();
            query.RowLimit = 2;
            var items = list.GetItems(query);

            iCategory.AddRange(from SPListItem item in items select new Category { Id = item.ID, Title = item.Title, Language = web.Language, WebUrl = web.Url,});

            return iCategory;
        }
    }

    public class Category
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }

        private string _active;
        public string Active
        {
            get
            {
                if (!string.IsNullOrEmpty(_active))
                {
                    if (Convert.ToString(Id).Equals(_active))
                    {
                        return "active";
                    }
                }

                return string.Empty;
            }
            set { _active = value; }
        }

        public string Url
        {
            get
            {
                if (Language != 1033)
                    return string.Format("<a href='{0}/tin-tuc/{1}-{2}/trang-1.html'/><i class='fa fa-angle-right'></i>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title), Id, Title);
                else
                    return string.Format("<a href='{0}/news/{1}-{2}/page-1.html'/><i class='fa fa-angle-right'></i>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title).ToLower(), Id, Title);
            }
        }

        public string Url2
        {
            get
            {
                if (Language != 1033)
                    return string.Format("<a href='{0}/tin-tuc/{1}-{2}/trang-1.html' class='current'/>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title), Id, Title);
                else
                    return string.Format("<a href='{0}/news/{1}-{2}/page-1.html' class='current'/>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title).ToLower(), Id, Title);
            }
        }
    }
    public class CategoryPaging
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public int page { get; set; }
        public int text { get; set; }
        public int currentPage { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string strClass
        {
            get
            {
                if (page == currentPage)
                    return "current";
                else
                    return String.Empty;
            }
        }
        public string UrlPrevious
        {
            get
            {
                if (Language != 1033)
                    return string.Format("{0}/tin-tuc/{1}-{2}/trang-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, currentPage - 1);
                else
                    return string.Format("{0}/news/{1}-{2}/page-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, currentPage - 1);
            }
        }
        public string UrlCurr
        {
            get
            {
                if (Language != 1033)
                    return string.Format("{0}/tin-tuc/{1}-{2}/trang-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, currentPage);
                else
                    return string.Format("{0}/news/{1}-{2}/page-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, currentPage);
            }
        }
        public string Url
        {
            get
            {
                if (Language != 1033)
                    return string.Format("{0}/tin-tuc/{1}-{2}/trang-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, page);
                else
                    return string.Format("{0}/news/{1}-{2}/page-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, page);
            }
        }
        public string UrlNext
        {
            get
            {
                if (Language != 1033)
                    return string.Format("{0}/tin-tuc/{1}-{2}/trang-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, currentPage + 1);
                else
                    return string.Format("{0}/news/{1}-{2}/page-{3}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id, currentPage + 1);
            }
        }
    }
}