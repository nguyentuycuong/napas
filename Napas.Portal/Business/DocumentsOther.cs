using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Napas.Portal.Business
{
    public class DocumentsOther
    {
        public static string listName;
        

        public DocumentsOther(SPWeb _web)
        {
           
            if (_web.Language == 1033)
            {
                listName = Constants.DocumentOther.ListNameEnglish;
            }
            else
            {
                listName = Constants.DocumentOther.ListName;
            }

            
        }

        public List<DocumentOtherInfo> get_DocumentsLegalInfoItemsByDocumentType(SPWeb web, string documentType)
        {
            var list = web.Lists[listName];
            var documentsLegalInfoInfoList = new List<DocumentOtherInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.DocumentShareholder.InternalFields.Activate] && c[Constants.DocumentShareholder.InternalFields.Type] == (DataTypes.LookupId)documentType)
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Desc).ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                documentsLegalInfoInfoList.AddRange(from SPListItem item in items
                                                    select new DocumentOtherInfo
                                             {
                                                 Id = item.ID,
                                                 Title = item.Title,
                                                 Language = web.Language,
                                                 WebUrl = web.Url,
                                                 Created = Convert.ToDateTime(item[Constants.CommonField.Created]).ToShortDateString(),
                                                 //FileUrl = Convert.ToString(item["LinkFilename"])
                                                 FileUrl = item.File.Url,
                                                 DocumentDate = item[Constants.DocumentShareholder.InternalFields.DocumentDate] != null ? Convert.ToDateTime(item[Constants.DocumentShareholder.InternalFields.DocumentDate]).ToShortDateString() : string.Empty,
                                                 DocumentType = Convert.ToString(item[Constants.DocumentShareholder.InternalFields.Type])
                                             });
            }

            return documentsLegalInfoInfoList;
        }

        public DocumentOtherInfo get_DocumentsLegalInfoItemId(SPWeb web, int id)
        {
            var list = web.Lists[listName];
            var documentsLegalInfo = new DocumentOtherInfo();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.DocumentShareholder.InternalFields.Activate] && (int)c[Constants.CommonField.ID] == id)
                    .OrderBy(c => c[Constants.DocumentShareholder.InternalFields.DocumentDate] as Camlex.Desc).ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                var item = items[0];
                documentsLegalInfo = new DocumentOtherInfo
                {
                    Id = item.ID,
                    Title = item.Title,
                    Language = web.Language,
                    WebUrl = web.Url,
                    Created = Convert.ToDateTime(item[Constants.CommonField.Created]).ToShortDateString(),
                    DocumentDate = item[Constants.DocumentShareholder.InternalFields.DocumentDate] != null ? Convert.ToDateTime(item[Constants.DocumentShareholder.InternalFields.DocumentDate]).ToShortDateString() : string.Empty,
                    DocumentType = Convert.ToString(item[Constants.DocumentShareholder.InternalFields.Type])
                };
            }

            return documentsLegalInfo;
        }
    }

    public class DocumentOtherInfo
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

        private string _documentType;

        public string DocumentType
        {
            get
            {
                if (!string.IsNullOrEmpty(_documentType) && _documentType.Contains(";#"))
                {
                    return Regex.Split(_documentType, ";#")[1];
                }

                return string.Empty;
            }
            set { _documentType = value; }
        }

        public string FileUrl
        {
            get { return WebUrl + "/" + _fileUrl; }
            set { _fileUrl = value; }
        }
    }
}