using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class ContactBo
    {
        public static string listName;
        // public static string documentTypeName;
        

        public ContactBo(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.ContactInfomation.ListNameEnglish;
            }
            else
            {
                listName = Constants.ContactInfomation.ListName;
            }

        
        }

        public List<ContactInfo> get_ContactInfo(SPWeb web, string currentContact)
        {
            var list = web.Lists[listName];
            var contactsInfoList = new List<ContactInfo>();

            var query =
                Camlex.Query().Where(c => (Boolean)c[Constants.ContactInfomation.InternalFields.Activate])
                    .OrderBy(c => c[Constants.ContactInfomation.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();

            var items = list.GetItems(query);
            if (items != null && items.Count > 0)
            {
                int currentId = 0;
                if (!int.TryParse(currentContact, out currentId))
                {
                    currentContact = Convert.ToString(items[0].ID);
                }

                contactsInfoList.AddRange(from SPListItem item in items
                                          select new ContactInfo
                                          {
                                              Id = item.ID,
                                              Title = item.Title,
                                              Language = web.Language,
                                              WebUrl = web.Url,
                                              Content = Convert.ToString(item[Constants.ContactInfomation.InternalFields.Content]),
                                              active = currentContact,
                                          });
            }

            return contactsInfoList;
        }
    }

    public class ContactInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }

        private string _active;

        public string active
        {
            get
            {
                if (Convert.ToString(Id).Equals(_active))
                {
                    return "active";
                }

                return string.Empty;
            }
            set
            {
                _active = value;
            }
        }

        public string Content { get; set; }

        public string Url
        {
            get
            {
                return string.Format("{0}/{1}/{2}-{3}.html", WebUrl, Language == 1033 ? "contact" : "lien-he", Utilities.ConvertToUnsign(Title), Id);
            }
        }
    }
}