using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Text.RegularExpressions;

namespace Napas.Portal.Business
{
    public class CustomerSevices
    {
        public static string listName;
        public static SPWeb web;
        public static SPList list;

        public CustomerSevices(SPWeb _web)
        {
            web = _web;
            if (_web.Language == 1033)
            {
                listName = Constants.ProductionServices.ListNameEnglish;
            }
            else
            {
                listName = Constants.ProductionServices.ListName;
            }

            list = web.Lists[listName];
        }
    }

    public class CustomerSevicesInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Content { get; set; }

        private string _cat;
        public string FullCat { get; set; }

        public string catId
        {
            get
            {
                if (!string.IsNullOrEmpty(FullCat) && FullCat.Contains(";#"))
                {
                    return Regex.Split(FullCat, ";#")[0];
                }

                return "0";
            }
        }

        public string catValue
        {
            get
            {
                if (!string.IsNullOrEmpty(FullCat) && FullCat.Contains(";#"))
                {
                    return Regex.Split(FullCat, ";#")[1];
                }

                return string.Empty;
            }
        }

        private string _currentCustomerSevices;

        public string CurrentCustomerSevices
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentCustomerSevices) && _currentCustomerSevices.Equals(Convert.ToString(Id)))
                {
                    return "active";
                }

                return string.Empty;
            }
            set { _currentCustomerSevices = value; }
        }
    }
}