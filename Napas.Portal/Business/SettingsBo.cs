using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;

namespace Napas.Portal.Business
{
    public class SettingsBo
    {
        public string listName;
        
        public SettingsBo(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.Setting.ListNameEnglish;
            }
            else
            {
                listName = Constants.Setting.ListName;
            }        
        }

        public SettingInfo get_SettingInfo(SPWeb web)
        {
            var list = web.Lists[listName];
            var sliderInfo = new SettingInfo();

            var query =
                Camlex.Query()
                    .ToSPQuery();

            query.RowLimit = 1;

            var items = list.GetItems(query);
            int i = 1;
            if (items != null && items.Count > 0)
            {
                var item = items[0];
                sliderInfo = new SettingInfo
                                                    {
                                                        Id = item.ID,
                                                        Title = item.Title,
                                                        Language = web.Language,
                                                        WebUrl = web.Url,
                                                        CompanyName = item.Title,
                                                        CompanyNameEn = Convert.ToString(item[Constants.Setting.InternalFields.CompanyNameEn]),
                                                        Address = Convert.ToString(item[Constants.Setting.InternalFields.Address]),
                                                        SubAddress = Convert.ToString(item[Constants.Setting.InternalFields.SubAddress]),
                                                        Mobile = Convert.ToString(item[Constants.Setting.InternalFields.Mobile]),
                                                        Hotline = Convert.ToString(item[Constants.Setting.InternalFields.Hotline]),
                                                        Email = Convert.ToString(item[Constants.Setting.InternalFields.Email]),
                                                        Facebook = Convert.ToString(item[Constants.Setting.InternalFields.Facebook]),
                                                        Youtube = Convert.ToString(item[Constants.Setting.InternalFields.Youtube]),
                                                        Twitter = Convert.ToString(item[Constants.Setting.InternalFields.Twitter]),

                                                        Logo = Convert.ToString(item[Constants.Setting.InternalFields.Logo]),
                                                        LogoFooter = Convert.ToString(item[Constants.Setting.InternalFields.LogoFooter]),
                                                        BanerAboutUs = Convert.ToString(item[Constants.Setting.InternalFields.BanerAboutUs]),
                                                        BanerNews = Convert.ToString(item[Constants.Setting.InternalFields.BanerNews]),
                                                        BanerProduct = Convert.ToString(item[Constants.Setting.InternalFields.BanerProduct]),
                                                        BanerCustomer = Convert.ToString(item[Constants.Setting.InternalFields.BanerCustomer]),
                                                        BanerPartner = Convert.ToString(item[Constants.Setting.InternalFields.BanerPartner]),
                                                        BanerUserGuide = Convert.ToString(item[Constants.Setting.InternalFields.BanerUserGuide]),
                                                        BanerDocument = Convert.ToString(item[Constants.Setting.InternalFields.BanerDocument]),
                                                        BanerCeare = Convert.ToString(item[Constants.Setting.InternalFields.BanerCeare]),
                                                        BanerTermCondition = Convert.ToString(item[Constants.Setting.InternalFields.BanerTermCondition]),
                                                        BanerHotline = Convert.ToString(item[Constants.Setting.InternalFields.BanerHotline]),
                                                        VideoDescription = Convert.ToString(item[Constants.Setting.InternalFields.VideoDescription]),
                                                        YoutubeChanel = Convert.ToString(item[Constants.Setting.InternalFields.YoutubeChanel])
                                                    };
            }

            return sliderInfo;
        }
    }

    public class SettingInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }
        public string Index { get; set; }

        public string CompanyName { get; set; }
        public string CompanyNameEn { get; set; }
        public string Address { get; set; }
        public string SubAddress { get; set; }
        public string Mobile { get; set; }
        public string Hotline { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string YoutubeChanel { get; set; }
        public string Twitter { get; set; }
        public string VideoDescription { get; set; }

        private string _logo;

        public string Logo
        {
            get
            {
                if (!string.IsNullOrEmpty(_logo))
                {
                    return _logo.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _logo = value;
            }
        }

        private string _LogoFooter;

        public string LogoFooter
        {
            get
            {
                if (!string.IsNullOrEmpty(_LogoFooter))
                {
                    return _LogoFooter.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _LogoFooter = value;
            }
        }

        private string _BanerAboutUs;

        public string BanerAboutUs
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerAboutUs))
                {
                    return _BanerAboutUs.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerAboutUs = value;
            }
        }

        private string _BanerNews;

        public string BanerNews
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerNews))
                {
                    return _BanerNews.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerNews = value;
            }
        }

        private string _BanerProduct;

        public string BanerProduct
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerProduct))
                {
                    return _BanerProduct.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerProduct = value;
            }
        }

        private string _BanerCustomer;

        public string BanerCustomer
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerCustomer))
                {
                    return _BanerCustomer.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerCustomer = value;
            }
        }

        private string _BanerPartner;

        public string BanerPartner
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerPartner))
                {
                    return _BanerPartner.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerPartner = value;
            }
        }

        private string _BanerUserGuide;

        public string BanerUserGuide
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerUserGuide))
                {
                    return _BanerUserGuide.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerUserGuide = value;
            }
        }

        private string _BanerDocument;

        public string BanerDocument
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerDocument))
                {
                    return _BanerDocument.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerDocument = value;
            }
        }

        private string _BanerCeare;

        public string BanerCeare
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerCeare))
                {
                    return _BanerCeare.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerCeare = value;
            }
        }

        private string _BanerTermCondition;

        public string BanerTermCondition
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerTermCondition))
                {
                    return _BanerTermCondition.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerTermCondition = value;
            }
        }

        private string _BanerHotline;

        public string BanerHotline
        {
            get
            {
                if (!string.IsNullOrEmpty(_BanerHotline))
                {
                    return _BanerHotline.Split(',')[0];
                }

                return string.Empty;
            }
            set
            {
                _BanerHotline = value;
            }
        }
    }
}