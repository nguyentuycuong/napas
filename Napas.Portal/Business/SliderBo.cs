using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class SliderBo
    {
        public string listName;


        public SliderBo(SPWeb _web)
        {
           
            if (_web.Language == 1033)
            {
                listName = Constants.Slider.ListNameEnglish;
            }
            else
            {
                listName = Constants.Slider.ListName;
            }

            
        }

        public List<SliderInfo> get_SliderInfo(SPWeb web)
        {
            var list = web.Lists[listName];
            var sliderInfoList = new List<SliderInfo>();

            var query =
                Camlex.Query().Where(c => (Boolean)c[Constants.Slider.InternalFields.Active] && (DateTime)c[Constants.Slider.InternalFields.FromDate] <= DateTime.Today && (c[Constants.Slider.InternalFields.ToDate] == null || (DateTime)c[Constants.Slider.InternalFields.ToDate] >= DateTime.Today))
                    .OrderBy(c => c[Constants.Slider.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();

            query.RowLimit = 4;

            var items = list.GetItems(query);

            if (items != null && items.Count > 0)
            {
                sliderInfoList.AddRange(from SPListItem item in items
                                        select new SliderInfo
                                                  {
                                                      Id = item.ID,
                                                      Title = item.Title,
                                                      Language = web.Language,
                                                      WebUrl = web.Url,
                                                      Description = Convert.ToString(item[Constants.Slider.InternalFields.Description]),
                                                      Image1366 = Convert.ToString(item[Constants.Slider.InternalFields.Banner1366]),
                                                      Image1024 = Convert.ToString(item[Constants.Slider.InternalFields.Banner1024]),
                                                      Image480 = Convert.ToString(item[Constants.Slider.InternalFields.Banner480]),
                                                      Url = Convert.ToString(item[Constants.Slider.InternalFields.LinkToContent]),
                                                      Index = Convert.ToString(item[Constants.Slider.InternalFields.Slider])
                                                  });
            }

            return sliderInfoList;
        }
    }

    public class SliderInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }
        public string Index { get; set; }

        private string _image1366;

        public string Image1366
        {
            get
            {
                if (!string.IsNullOrEmpty(_image1366))
                {
                    return _image1366.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _image1366 = value;
            }
        }

        private string _image1024;

        public string Image1024
        {
            get
            {
                if (!string.IsNullOrEmpty(_image1024))
                {
                    return _image1024.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _image1024 = value;
            }
        }

        private string _image480;

        public string Image480
        {
            get
            {
                if (!string.IsNullOrEmpty(_image480))
                {
                    return _image480.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _image480 = value;
            }
        }

        private string _url;

        public string Url
        {
            get
            {
                if (!string.IsNullOrEmpty(_url))
                {
                    return _url.Split(',')[0];
                }

                return "#";
            }
            set { _url = value; }
        }
    }
}