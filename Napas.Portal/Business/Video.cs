using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;

namespace Napas.Portal.Business
{
    public class Video
    {
        public static string listName;
        

        public Video(SPWeb _web)
        {
            if (_web.Language == 1033)
            {
                listName = Constants.Video.ListNameEnglish;
            }
            else
            {
             
                listName = Constants.Video.ListName;
            }
            
        }

       
    }

    public class VideoInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string DescriptionVN { get; set; }
        public string DescriptionEN { get; set; }

        public string Description
        {
            get
            {
                if (Language == 1033)
                {
                    return DescriptionEN;
                }

                return DescriptionVN;
            }
        }

        public string DescriptionSort
        {
            get { return Utilities.SplitText(Description, 25); }
        }

        private string _url;

        public string Url
        {
            get { return WebUrl + "/" + _url; }
            set { _url = value; }
        }
    }
}