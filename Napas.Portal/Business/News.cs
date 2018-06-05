using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Napas.Portal.Business
{
    public class News
    {
        public string listName;
        
        public News(SPWeb _web)
        {
           
            if (_web.Language == 1033)
            {
                listName = Constants.News.ListNameEnglish;
            }
            else
            {
                listName = Constants.News.ListName;
            }

           
        }

        /// <summary>
        /// lay tin tuc cu, voi so luong ban ghi gioi han la 10 ban ghi
        /// </summary>
        /// <param name="web"></param>
        /// <param name="idNews"></param>
        /// <param name="categories"></param>
        /// <returns></returns>
        public List<NewsInfo> get_SomeNews(SPWeb web, int idNews, string categories)
        {
            var list = web.Lists[listName];
            var lNews = new List<NewsInfo>();
            var query = Camlex.Query().Where(c => c[Constants.News.InternalFields.Category] == (DataTypes.LookupId)categories && (Boolean)c[Constants.News.InternalFields.Activate] && (int)c[Constants.CommonField.ID] != idNews &&
                (DateTime)c[Constants.News.InternalFields.FromDate] <= DateTime.Today && (c[Constants.News.InternalFields.ToDate] == null || (DateTime)c[Constants.News.InternalFields.ToDate] >= DateTime.Today)).OrderBy(c => c[Constants.News.InternalFields.FromDate] as Camlex.Desc).OrderBy(c=>c["ID"] as Camlex.Desc).ToSPQuery();
            query.RowLimit = 10;
            var items = list.GetItems(query);
            lNews.AddRange(from SPListItem item in items
                           select new NewsInfo
                           {
                               Id = item.ID,
                               Title = item.Title,
                               Language = web.Language,
                               WebUrl = web.Url,
                               Category = Convert.ToString(item[Constants.News.InternalFields.Category]),
                               Created = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]).ToShortDateString(),
                           });

            return lNews;
        }

        public NewsInfo get_NewItem(SPWeb web, int id)
        {
            var list = web.Lists[listName];
            var newsInfo = new NewsInfo();

            SPQuery query = new SPQuery()
            {
                Query = string.Format(Constants.News.Queries.getNewbyID, id)
            };
            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                var item = items[0];
                newsInfo = new NewsInfo
                               {
                                   Id = item.ID,
                                   Title = item.Title,
                                   Language = web.Language,
                                   WebUrl = web.Url,
                                   Content = Convert.ToString(item[Constants.News.InternalFields.Content]),
                                   Image = Convert.ToString(item[Constants.News.InternalFields.Thumbar]),
                                   Created = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]).ToShortDateString(),
                                   Description = Convert.ToString(item[Constants.News.InternalFields.Description]),
                                   Category = Convert.ToString(item[Constants.News.InternalFields.Category])
                               };
            }

            return newsInfo;
        }

        public List<NewsInfo> get_NewsCategory(SPWeb web, string id)
        {
            var list = web.Lists[listName];
            var lNews = new List<NewsInfo>();
            var query = Camlex.Query().Where(c => c[Constants.News.InternalFields.Category] == (DataTypes.LookupId)id && (Boolean)c[Constants.News.InternalFields.Activate] &&
                (DateTime)c[Constants.News.InternalFields.FromDate] <= DateTime.Today && (c[Constants.News.InternalFields.ToDate] == null || (DateTime)c[Constants.News.InternalFields.ToDate] >= DateTime.Today)).OrderBy(c => c[Constants.News.InternalFields.FromDate] as Camlex.Desc).OrderBy(c => c["ID"] as Camlex.Desc).ToSPQuery();
            var items = list.GetItems(query);

            lNews.AddRange(from SPListItem item in items
                           select new NewsInfo
                           {
                               Id = item.ID,
                               Title = item.Title,
                               Language = web.Language,
                               WebUrl = web.Url,
                               Content = Convert.ToString(item[Constants.News.InternalFields.Content]),
                               Image = Convert.ToString(item[Constants.News.InternalFields.Thumbar]),
                               Created = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]).ToShortDateString(),
                               Description = Convert.ToString(item[Constants.News.InternalFields.Description]),
                               Category = Convert.ToString(item[Constants.News.InternalFields.Category])
                           });

            return lNews;
        }

        public NewsInfo get_top1News(SPWeb web, string catId)
        {
            var list = web.Lists[listName];
            var newsInfo = new NewsInfo();
            var query = Camlex.Query().Where(c => c[Constants.News.InternalFields.Category] == (DataTypes.LookupId)catId && (Boolean)c[Constants.News.InternalFields.Activate] &&
                (DateTime)c[Constants.News.InternalFields.FromDate] <= DateTime.Today && (c[Constants.News.InternalFields.ToDate] == null || (DateTime)c[Constants.News.InternalFields.ToDate] >= DateTime.Today)).OrderBy(c => new[] { c[Constants.News.InternalFields.ShowHomePage] as Camlex.Desc, c[Constants.CommonField.Created] as Camlex.Desc}).ToSPQuery();
            query.RowLimit = 1;
            var items = list.GetItems(query);
            if (items.Count > 0)
            {
                SPListItem item = items[0];
                newsInfo = new NewsInfo
                {
                    Id = item.ID,
                    Title = item.Title,
                    Language = web.Language,
                    WebUrl = web.Url,
                    Content = Convert.ToString(item[Constants.News.InternalFields.Content]),
                    Image = Convert.ToString(item[Constants.News.InternalFields.Thumbar]),
                    Created = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]).ToShortDateString(),
                    Description = Convert.ToString(item[Constants.News.InternalFields.Description]),
                    Category = Convert.ToString(item[Constants.News.InternalFields.Category]),
                    CreatedSystem = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]),
                };
            }
            else
            {
                query = Camlex.Query().Where(c => c[Constants.News.InternalFields.Category] == (DataTypes.LookupId)catId && (Boolean)c[Constants.News.InternalFields.Activate] &&
                    (DateTime)c[Constants.News.InternalFields.FromDate] <= DateTime.Today && (c[Constants.News.InternalFields.ToDate] == null || (DateTime)c[Constants.News.InternalFields.ToDate] >= DateTime.Today)).OrderBy(c => new[] { c[Constants.News.InternalFields.ShowHomePage] as Camlex.Desc, c[Constants.CommonField.Created] as Camlex.Desc }).ToSPQuery();
                query.RowLimit = 1;
                items = list.GetItems(query);
                if (items.Count > 0)
                {
                    SPListItem item = items[0];
                    newsInfo = new NewsInfo
                                   {
                                       Id = item.ID,
                                       Title = item.Title,
                                       Language = web.Language,
                                       WebUrl = web.Url,
                                       Content = Convert.ToString(item[Constants.News.InternalFields.Content]),
                                       Image = Convert.ToString(item[Constants.News.InternalFields.Thumbar]),
                                       Created = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]).ToShortDateString(),
                                       Description = Convert.ToString(item[Constants.News.InternalFields.Description]),
                                       Category = Convert.ToString(item[Constants.News.InternalFields.Category]),
                                       CreatedSystem = Convert.ToDateTime(item[Constants.News.InternalFields.FromDate]),
                                   };
                }
            }

            return newsInfo;
        }

        public List<NewsInfo> get_NewsHome(SPWeb web)
        {
            var newsInfoList = new List<NewsInfo>();
            var categoryBo = new CategoryNews(web);
            var top2Cat = categoryBo.get_Category(web, string.Empty);
            foreach (var cat in top2Cat)
            {
                var newsInfo = get_top1News(web, Convert.ToString(cat.Id));
                if (newsInfo != null && newsInfo.Id > 0)
                {
                    newsInfoList.Add(newsInfo);
                }

                if (newsInfoList.Count == 2)
                {
                    break;
                }
            }

            return newsInfoList;
        }
    }

    public class NewsInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        private string _title;
        public string Title
        {
            get
            {
                return _title.ToUpper();
            }
            set { _title = value; }
        }

        public string WebUrl { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public string Title4Home
        {
            get { return Utilities.SplitText(Title, 20).ToUpper(); }
        }

        public string Description4Home
        {
            get { return Utilities.SplitText(Description, 28); }
        }

        private string _image;

        public string Image
        {
            get
            {
                if (!string.IsNullOrEmpty(_image))
                {
                    return _image.Split(',')[0];
                }

                return "/_catalogs/masterpage/napas_theme/images/n3.png";
            }
            set
            {
                _image = value;
            }
        }

        private string _cat;

        public string Category
        {
            get
            {
                if (!string.IsNullOrEmpty(_cat))
                {
                    return Regex.Split(_cat, ";#")[1];
                }

                return string.Empty;
            }
            set
            {
                _cat = value;
            }
        }

        public string CategoryID
        {
            get
            {
                if (!string.IsNullOrEmpty(_cat))
                {
                    return Regex.Split(_cat, ";#")[0];
                }

                return string.Empty;
            }
        }

        public string UrlCat
        {
            get
            {
                if (!string.IsNullOrEmpty(_cat))
                {
                    var cat = Regex.Split(_cat, ";#");
                    if (Language != 1033)
                        return string.Format("<a href='{0}/tin-tuc/{1}-{2}/trang-1.html' class='current'/>{3}</a>", WebUrl, Utilities.ConvertToUnsign(cat[1]), cat[0], cat[1]);
                    else
                        return string.Format("<a href='{0}/news/{1}-{2}/page-1.html' class='current'/>{3}</a>", WebUrl, Utilities.ConvertToUnsign(cat[1]).ToLower(), cat[0], cat[1]);
                }

                return string.Empty;
            }
        }

        public string Created { get; set; }

        public DateTime CreatedSystem { get; set; }

        public string CreatedHome
        {
            get
            {
                //if (CreatedSystem.Month == DateTime.Today.Month)
                //{
                //    return string.Format("Now <strong>{0}</strong>", CreatedSystem.Day);
                //}

                return string.Format("{0} <strong>{1}</strong>", CreatedSystem.ToString("d/M"), CreatedSystem.Year);
            }
        }

        public string Url
        {
            get
            {
                if (Language != 1033)
                {
                    //[url]/tin-tuc/cat/ten-tin-id.html
                    return string.Format("{0}/tin-tuc/{1}/{2}-{3}-{4}.html", WebUrl, Utilities.ConvertToUnsign(Category), HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Title)), CategoryID, Id);
                }
                else
                    return string.Format("{0}/news/{1}/{2}-{3}-{4}.html", WebUrl, Utilities.ConvertToUnsign(Category), HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Title)), CategoryID, Id);
            }
        }
    }
}