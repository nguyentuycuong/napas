using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class VendersBo
    {
        public static string listName;
       

        public VendersBo(SPWeb _web)
        {
            if (_web.Language == 1033)
            {
                listName = Constants.VenderService.ListNameEnglish;
            }
            else
            {
                listName = Constants.VenderService.ListName;
            }
        }

        public List<VendersInfo> Get_VenderInfoByIds(SPWeb web, List<int> ids)
        {
            var list = web.Lists[listName];
            var customersList = new List<VendersInfo>();
            if (!ids.Any())
            {
                return customersList;
            }

            customersList.AddRange(from id in ids
                                   select Camlex.Query().Where(c => (int)c[Constants.CommonField.ID] == id).ToSPQuery()
                                       into query
                                       select list.GetItems(query)
                                           into items
                                           where items.Count > 0
                                           select items[0]
                                               into item
                                               select new VendersInfo()
                                               {
                                                   Id = item.ID,
                                                   Title = item.Title,
                                                   Image = Convert.ToString(item[Constants.VenderService.InternalFields.Image]),
                                                   Website = Convert.ToString(item[Constants.VenderService.InternalFields.PartnerWebsite])
                                               });


            return customersList;
        }

        public List<VendersInfo> Get_VenderInfoAll(SPWeb web, List<int> ids)
        {
            var list = web.Lists[listName];
            var customersList = new List<VendersInfo>();
            if (!ids.Any())
            {
                return customersList;
            }

            var query = Camlex.Query().OrderBy(c => c[Constants.CommonField.Title]).ToSPQuery();
            var items = list.GetItems(query);
            if (items.Count > 0)
            {
                customersList.AddRange(from SPListItem item in items
                                       select new VendersInfo()
                                       {
                                           Id = item.ID,
                                           Title = item.Title,
                                           Image = Convert.ToString(item[Constants.VenderService.InternalFields.Image]),
                                           Website = Convert.ToString(item[Constants.VenderService.InternalFields.PartnerWebsite])
                                       });
            }

            return customersList;
        }
    }

    public class VendersInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }

        private string _image;

        public string Image
        {
            get
            {
                if (!string.IsNullOrEmpty(_image))
                {
                    return _image.Split(',')[0];
                }

                return "";
            }
            set
            {
                _image = value;
            }
        }
                
        private string _webSite;

        public string Website
        {
            get
            {
                if (!string.IsNullOrEmpty(_webSite))
                {
                    return _webSite.Split(',')[0];
                }

                return string.Empty;
            }
            set { _webSite = value; }
        }

        public string Url
        {
            get;
            set;
            //get
            //{
            //    if (Language != 1033)
            //        return string.Format("<a href='{0}/tin-tuc/{1}-{2}.html'/>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title), Id, Title);
            //    else
            //        return string.Format("<a href='{0}/news/{1}-{2}.html'/>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title).ToLower(), Id, Title);
            //}
        }
    }
}