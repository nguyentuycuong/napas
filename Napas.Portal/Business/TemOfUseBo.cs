using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class TemOfUseBo
    {
        public static string listName;
        
        public TemOfUseBo(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.TermsOfUse.ListNameEnglish;
            }
            else
            {
                listName = Constants.TermsOfUse.ListName;
            }

        
        }

        public List<TemOfUseInfo> get_Allitems(SPWeb web, string currentItem)
        {
            var list = web.Lists[listName];
            var TermOfUseInfoList = new List<TemOfUseInfo>();
            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.TermsOfUse.InternalFields.Activate])
                    .OrderBy(c => c[Constants.TermsOfUse.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();

            var items = list.GetItems(query);
            if (items.Count > 0)
            {
                int id = 0;
                if (!int.TryParse(currentItem, out id))
                {
                    id = items[0].ID;
                }

                TermOfUseInfoList.AddRange(from SPListItem item in items
                                           select new TemOfUseInfo()
                                               {
                                                   Language = web.Language,
                                                   Id = item.ID,
                                                   Title = item.Title,
                                                   Content = Convert.ToString(item[Constants.TermsOfUse.InternalFields.Content]),
                                                   Active = Convert.ToString(id),
                                                   WebUrl = web.Url
                                               });
            }

            return TermOfUseInfoList;
        }
    }

    public class TemOfUseInfo
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

        public string Content { get; set; }

        public string Url
        {
            get
            {
                if (Language != 1033)
                    return string.Format("{0}/dieu-khoan-sua-dung/{1}-{2}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id);
                else
                    return string.Format("{0}/term-of-use/{1}-{2}.html", WebUrl, Utilities.ConvertToUnsign(Title).ToLower(), Id);
            }
        }
    }
}