using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Napas.Portal.Business
{
    public class Shareholder
    {
        public static string listName;
        
        public Shareholder(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.MeetingPartners.ListNameEnglish;
            }
            else
            {
                listName = Constants.MeetingPartners.ListName;
            }

        
        }

        public List<ShareholderInfo> get_ShareholderItems(SPWeb web, string category)
        {
            var list = web.Lists[listName];
            var shareholderInfoList = new List<ShareholderInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.MeetingPartners.InternalFields.Activate] && (string)c[Constants.MeetingPartners.InternalFields.Category] == category)
                    .OrderBy(c => c[Constants.MeetingPartners.InternalFields.DateCreate] as Camlex.Desc).ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                shareholderInfoList.AddRange(from SPListItem item in items
                                             select new ShareholderInfo
                                             {
                                                 Id = item.ID,
                                                 Title = item.Title,
                                                 Language = web.Language,
                                                 WebUrl = web.Url,

                                                 Image = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Image]),
                                                 Created = Convert.ToDateTime(item[Constants.MeetingPartners.InternalFields.DateCreate]).ToShortDateString(),
                                                 Description = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Description]),
                                                 Category = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Category])
                                             });
            }

            return shareholderInfoList;
        }

        public List<ShareholderInfo> get_Top10ShareholderItems(SPWeb web, int id, string category)
        {
           var list = web.Lists[listName];
            var shareholderInfoList = new List<ShareholderInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.MeetingPartners.InternalFields.Activate] && (int)c[Constants.CommonField.ID] != id && (string)c[Constants.MeetingPartners.InternalFields.Category] == category)
                    .OrderBy(c => c[Constants.MeetingPartners.InternalFields.DateCreate] as Camlex.Desc).ToSPQuery();
            query.RowLimit = 10;

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                shareholderInfoList.AddRange(from SPListItem item in items
                                             select new ShareholderInfo
                                             {
                                                 Id = item.ID,
                                                 Title = item.Title,
                                                 Language = web.Language,
                                                 WebUrl = web.Url,
                                                 Image = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Image]),
                                                 Created = Convert.ToDateTime(item[Constants.MeetingPartners.InternalFields.DateCreate]).ToShortDateString(),
                                                 Description = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Description]),
                                                 Category = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Category])
                                             });
            }

            return shareholderInfoList;
        }

        public ShareholderInfo get_ShareholderItemId(SPWeb web, int id)
        {
            var list = web.Lists[listName];
            var shareholderInfo = new ShareholderInfo();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.MeetingPartners.InternalFields.Activate] && (int)c[Constants.CommonField.ID] == id)
                    .ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                var item = items[0];
                shareholderInfo = new ShareholderInfo
                {
                    Id = item.ID,
                    Title = item.Title,
                    Language = web.Language,
                    WebUrl = web.Url,
                    Content = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Content]),
                    Image = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Image]),
                    Created = Convert.ToDateTime(item[Constants.MeetingPartners.InternalFields.DateCreate]).ToShortDateString(),
                    Description = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Description]),
                    Category = Convert.ToString(item[Constants.MeetingPartners.InternalFields.Category])
                };
            }

            return shareholderInfo;
        }
    }

    public class ShareholderInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }

        public string Title4Home
        {
            get { return Utilities.SplitText(Title, 9); }
        }

        public string Description4Home
        {
            get { return Utilities.SplitText(Description, 20); }
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

                return string.Empty;
            }
            set
            {
                _image = value;
            }
        }

        public string Created { get; set; }

        public DateTime CreatedSystem { get; set; }

        public string CreatedHome
        {
            get
            {
                if (CreatedSystem.Month == DateTime.Today.Month)
                {
                    return string.Format("Now <strong>{0}</strong>", CreatedSystem.Day);
                }

                return string.Format("{0} <strong>{1}</strong>", CreatedSystem.ToString("M/yy"), CreatedSystem.Day);
            }
        }

        public string Url
        {
            get
            {
                return string.Format("{0}/shareholders-meeting-details.aspx?category={1}&title={2}&id={3}", WebUrl, HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Category)), HttpUtility.UrlEncode(Utilities.ConvertToUnsign(Title)), Id);
            }
        }
    }
}