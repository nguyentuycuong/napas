using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class DocumentGroup
    {
        public static string listName;
        
        public DocumentGroup(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.DocumentGroup.ListNameEnglish;
           
            }
            else
            {
                listName = Constants.DocumentGroup.ListName;
             
            }

        
        }

        public List<DocumentGroupInfo> get_DocumentByType(SPWeb web, string documentType, string documentTypeEn)
        {
            var list = web.Lists[listName];
            var typeList = new List<DocumentGroupInfo>();

            var query =
                Camlex.Query()
                    .Where(c => ((string)c[Constants.DocumentGroup.InternalFields.DocumentType] == documentType || (string)c[Constants.DocumentGroup.InternalFields.DocumentType]== documentTypeEn) &&
                            (Boolean)c[Constants.DocumentGroup.InternalFields.Activate])
                    .OrderBy(c => c[Constants.DocumentGroup.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();
            var items = list.GetItems(query);

            if (items.Count > 0)
            {
                typeList.AddRange(from SPListItem item in items
                                  select new DocumentGroupInfo()
                {
                    Title = item.Title,
                    TypeId = Convert.ToString(item.ID),
                    Language = web.Language,
                    WebUrl = web.Url
                });
            }

            return typeList;
        }

        public List<DocumentGroupInfo> get_DocumentType(SPWeb web, string documentType, string currentCatId)
        {
            var list = web.Lists[listName];
            var typeList = new List<DocumentGroupInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (string)c[Constants.DocumentGroup.InternalFields.DocumentType] == documentType &&
                            (Boolean)c[Constants.DocumentGroup.InternalFields.Activate])
                    .OrderBy(c => c[Constants.DocumentGroup.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();
            var items = list.GetItems(query);

            if (items.Count > 0)
            {
                typeList.AddRange(from SPListItem item in items
                                  select new DocumentGroupInfo()
                                  {
                                      Title = item.Title,
                                      TypeId = Convert.ToString(item.ID),
                                      Current = currentCatId,
                                      Language = web.Language,
                                      WebUrl = web.Url
                                  });
            }

            return typeList;
        }
    }

    public class DocumentGroupInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string TypeId { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Current { get; set; }

        public string Class
        {
            get
            {
                if (!string.IsNullOrEmpty(Current))
                {
                    if (Current.Equals(TypeId))
                    {
                        return "active";
                    }
                }

                return string.Empty;
            }
        }

        public string Url
        {
            get
            {
                if (Language != 1033)
                    return string.Format("<a href='{0}/tai-lieu/{1}-{2}.html'/><i class='fa fa-angle-right'></i>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title), TypeId, Title);
                else
                    return string.Format("<a href='{0}/documentation/{1}-{2}.html'/><i class='fa fa-angle-right'></i>{3}</a>", WebUrl, Utilities.ConvertToUnsign(Title).ToLower(), TypeId, Title);
            }
        }
    }
}