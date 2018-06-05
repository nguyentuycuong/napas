using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Napas.Portal.Business
{
    public class AboutBo
    {
        public static string listName;
        
        public AboutBo(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.Introduction.ListNameEnglish;
            }
            else
            {
                listName = Constants.Introduction.ListName;
            }

        
        }

        public List<AboutInfo> get_About(SPWeb web, string currentId)
        {
            var list = web.Lists[listName];
            var aboutInfoList = new List<AboutInfo>();
            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.Introduction.InternalFields.Activate])
                    .OrderBy(c => c[Constants.Introduction.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();

            var items = list.GetItems(query);

            if (items.Count > 0)
            {
                if (string.IsNullOrEmpty(currentId))
                {
                    currentId = Convert.ToString(items[0].ID);
                }

                aboutInfoList.AddRange(from SPListItem item in items
                                       select new AboutInfo()
                                           {
                                               Id = item.ID,
                                               Title = item.Title,
                                               Content = Convert.ToString(item[Constants.Introduction.InternalFields.Content]),
                                               Language = web.Language,
                                               Active = currentId,
                                               WebUrl = web.Url
                                           }
                );
            }

            return aboutInfoList;
        }
    }

    public class AboutInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public string Created { get; set; }

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
                {
                    //[url]/tin-tuc/cat/ten-tin-id.html
                    //return string.Format("{0}/gioi-thieu/{1}-{2}.html", WebUrl, HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Title)), Id);
                    return string.Format("{0}/about.aspx?title={1}&id={2}", WebUrl, HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Title)), Id);
                }
                else
                    return string.Format("{0}/about.aspx?title={1}&id={2}", WebUrl, HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Title)), Id);
            }
        }
    }
}