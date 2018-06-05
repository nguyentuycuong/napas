using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class DocumentsLegal
    {
        public static string listName;
        
        public DocumentsLegal(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.DocumentLegen.ListNameEnglish;
            }
            else
            {
                listName = Constants.DocumentLegen.ListName;
            }

        
        }

        public List<DocumentsLegalInfo> get_DocumentsLegalInfoItemsByDocumentType(SPWeb web, string documentType)
        {
            var list = web.Lists[listName];
            var documentsLegalInfoInfoList = new List<DocumentsLegalInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.DocumentShareholder.InternalFields.Activate] && c[Constants.DocumentShareholder.InternalFields.Type] == (DataTypes.LookupId)documentType)
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Desc).ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                documentsLegalInfoInfoList.AddRange(from SPListItem item in items
                                                    select new DocumentsLegalInfo
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

            return documentsLegalInfoInfoList;
        }

        public DocumentsLegalInfo get_DocumentsLegalInfoItemId(SPWeb web, int id)
        {
            var list = web.Lists[listName];
            var documentsLegalInfo = new DocumentsLegalInfo();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.DocumentShareholder.InternalFields.Activate] && (int)c[Constants.CommonField.ID] == id)
                    .OrderBy(c => c[Constants.DocumentShareholder.InternalFields.DocumentDate] as Camlex.Desc).ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                var item = items[0];
                documentsLegalInfo = new DocumentsLegalInfo
                {
                    Id = item.ID,
                    Title = item.Title,
                    Language = web.Language,
                    WebUrl = web.Url,
                    Created = Convert.ToDateTime(item[Constants.CommonField.Created]).ToShortDateString(),
                    DocumentDate = item[Constants.DocumentShareholder.InternalFields.DocumentDate] != null ? Convert.ToDateTime(item[Constants.DocumentShareholder.InternalFields.DocumentDate]).ToShortDateString() : string.Empty
                };
            }

            return documentsLegalInfo;
        }
    }

    public class DocumentsLegalInfo
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