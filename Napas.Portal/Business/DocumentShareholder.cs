using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class Document_Shareholder
    {
        public static string listName;
       
        public Document_Shareholder(SPWeb _web)
        {
       
            if (_web.Language == 1033)
            {
                listName = Constants.DocumentShareholder.ListNameEnglish;
            }
            else
            {
                listName = Constants.DocumentShareholder.ListName;
            }

            
        }

        public List<DocumentShareholderInfo> get_ShareholderItemsByDocumentType(SPWeb web, string documentType)
        {
           var list = web.Lists[listName];
            var documentShareholderInfoList = new List<DocumentShareholderInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.DocumentShareholder.InternalFields.Activate] && c[Constants.DocumentShareholder.InternalFields.Type] == (DataTypes.LookupId)documentType)
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Desc).ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                documentShareholderInfoList.AddRange(from SPListItem item in items
                                                     select new DocumentShareholderInfo
                                             {
                                                 Id = item.ID,
                                                 Title = item.Title,
                                                 Language = web.Language,
                                                 WebUrl = web.Url,
                                                 Created = Convert.ToDateTime(item[Constants.CommonField.Created]).ToShortDateString(),
                                                 //FileUrl = Convert.ToString(item["LinkFilename"])
                                                 FileUrl = item.File.Url,
                                                 DocumentDate = item[Constants.DocumentShareholder.InternalFields.DocumentDate] != null ? Convert.ToDateTime(item[Constants.DocumentShareholder.InternalFields.DocumentDate]).ToShortDateString() : string.Empty
                                             });
            }

            return documentShareholderInfoList;
        }

        public DocumentShareholderInfo get_DocumentShareholderInfoItemId(SPWeb web, int id)
        {
            var documentShareholderInfo = new DocumentShareholderInfo();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.DocumentShareholder.InternalFields.Activate] && (int)c[Constants.CommonField.ID] == id)
                    .OrderBy(c => c[Constants.DocumentShareholder.InternalFields.DocumentDate] as Camlex.Desc).ToSPQuery();

            var list = web.Lists[listName];
            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                var item = items[0];
                documentShareholderInfo = new DocumentShareholderInfo
                {
                    Id = item.ID,
                    Title = item.Title,
                    Language = web.Language,
                    WebUrl = web.Url,
                    Created = Convert.ToDateTime(item[Constants.CommonField.Created]).ToShortDateString(),
                    DocumentDate = item[Constants.DocumentShareholder.InternalFields.DocumentDate] != null ? Convert.ToDateTime(item[Constants.DocumentShareholder.InternalFields.DocumentDate]).ToShortDateString() : string.Empty
                };
            }

            return documentShareholderInfo;
        }
    }

    public class DocumentShareholderInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string TypeId { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }

        public string Created { get; set; }
        public string DocumentDate { get; set; }
        public string CreatedDisplay { get; set; }

        private string _fileUrl;

        public string FileUrl
        {
            get { return WebUrl + "/" + _fileUrl; }
            set { _fileUrl = value; }
        }
    }
}