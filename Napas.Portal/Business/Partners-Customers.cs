using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Napas.Portal.Business
{
    public class PartnersCustomers
    {
        public static string listName;
       

        public PartnersCustomers(SPWeb _web)
        {
            
            if (_web.Language == 1033)
            {
                listName = Constants.CustomerPartner.ListNameEnglish;
            }
            else
            {
                listName = Constants.CustomerPartner.ListName;
            }

            
        }

        public List<PartnersCustomersInfo> Get_PartnersCustomersInfoByIds(SPWeb web, List<int> ids)
        {
            var list = web.Lists[listName];
            var customersList = new List<PartnersCustomersInfo>();

            if (!ids.Any())
                return customersList;

            customersList.AddRange(from id in ids
                select Camlex.Query().Where(c => (int) c[Constants.CommonField.ID] == id).ToSPQuery()
                into query
                select list.GetItems(query)
                into items
                where items.Count > 0
                select items[0]
                into item
                select new PartnersCustomersInfo()
                {
                    Id = item.ID, Title = item.Title, 
                    Image = Convert.ToString(item[Constants.CustomerPartner.InternalFields.Image]), 
                    Website = Convert.ToString(item[Constants.CustomerPartner.InternalFields.Website]),                     
                });


            return customersList;
        }
        
    }

    public class PartnersCustomersInfo
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
        
        private string s(string s)
        {
            string s1 = string.Empty;
            if (!string.IsNullOrEmpty(s))
            {
                var a = Regex.Split(s, "\n");
                foreach (string b in a)
                {
                    if (!string.IsNullOrEmpty(b))
                    {
                        s1 += "<i class='fa fa-angle-right'></i>" + b + "<br>";
                    }
                }
            }

            return s1;
        }
    }
}