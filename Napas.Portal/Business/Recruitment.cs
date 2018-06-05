using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class Recruitment
    {
        public static string listName;
        public static string hrListName;
        public static string appInforListName;
        public static string CareerResultListName;
        public static string CVDocListName;
        //public static SPWeb web;
        //public static SPList list;
        public static SPList hrList;

        public Recruitment(SPWeb _web)
        {
            if (_web.Language == 1033)
            {
                listName = Constants.ContactInfor.ListNameEnglish;
                hrListName = Constants.HumanResource.ListNameEnglish;
                appInforListName = Constants.ApplicationInformation.ListNameEnglish;
                CareerResultListName = Constants.CareerResult.ListNameEnglish;
                CVDocListName = Constants.CVDocument.ListNameEnglish;
            }
            else
            {
                listName = Constants.ContactInfor.ListName;
                hrListName = Constants.HumanResource.ListName;
                appInforListName = Constants.ApplicationInformation.ListName;
                CareerResultListName = Constants.CareerResult.ListName;
                CVDocListName = Constants.CVDocument.ListName;
            }

            //list = web.Lists[listName];
        }

        public List<ContactInforObj> get_AllContact(SPWeb web)
        {
            var contact = new List<ContactInforObj>();

            var query =
                Camlex.Query()
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Asc)
                    .ToSPQuery();

            var list = web.Lists[listName];
            var items = list.GetItems(query);
            if (items.Count > 0)
            {
                foreach (SPListItem item in items)
                {
                    var ctact = new ContactInforObj()
                        {
                            Title = item.Title,
                            ContactUsr = Convert.ToString(item[Constants.ContactInfor.InternalFields.ContactUsr]),
                            Phone = Convert.ToString(item[Constants.ContactInfor.InternalFields.Phone]),
                            PhoneExt = Convert.ToString(item[Constants.ContactInfor.InternalFields.PhoneExt]),
                            Email = Convert.ToString(item[Constants.ContactInfor.InternalFields.Email]),
                            Image = Convert.ToString(item[Constants.ContactInfor.InternalFields.Image])
                        };
                    contact.Add(ctact);
                }
            }

            return contact;
        }

        public HrInfor get_AllHrInfor(SPWeb web)
        {
            var query =
                Camlex.Query()
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Asc)
                    .ToSPQuery();

            var items = web.Lists[hrListName].GetItems(query);
            if (items.Count > 0)
            {
                var item = items[0];

                var hrInfor = new HrInfor()
                {
                    Name = item.Title,
                    Description = Convert.ToString(item[Constants.HumanResource.InternalFields.Description]),
                    Content = Convert.ToString(item[Constants.HumanResource.InternalFields.Content])
                };
                return hrInfor;
            }

            return null;
        }

        public ApplicationInfor get_AllApplicationInfor(SPWeb web)
        {
            var query =
                Camlex.Query()
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Asc)
                    .ToSPQuery();

            var items = web.Lists[appInforListName].GetItems(query);
            if (items.Count > 0)
            {
                var item = items[0];

                var hrInfor = new ApplicationInfor()
                {
                    Name = item.Title,
                    Description = Convert.ToString(item[Constants.ApplicationInformation.InternalFields.Description]),
                    Content = Convert.ToString(item[Constants.ApplicationInformation.InternalFields.Content])
                };
                return hrInfor;
            }

            return null;
        }

        public CareerResultInfor get_AllCareerResultInfor(SPWeb web)
        {
            var query =
                Camlex.Query()
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Asc)
                    .ToSPQuery();

            var items = web.Lists[CareerResultListName].GetItems(query);
            if (items.Count > 0)
            {
                var item = items[0];

                var hrInfor = new CareerResultInfor()
                {
                    Name = item.Title,
                    Description = Convert.ToString(item[Constants.CareerResult.InternalFields.Description]),
                    Content = Convert.ToString(item[Constants.CareerResult.InternalFields.Content])
                };
                return hrInfor;
            }

            return null;
        }

        public List<CVDocumentsInfo> get_AllCVDocuments(SPWeb web)
        {
            var cvDocuments = new List<CVDocumentsInfo>();

            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.CVDocument.InternalFields.Activate])
                    .OrderBy(c => c[Constants.CommonField.Created] as Camlex.Desc).ToSPQuery();

            var items = web.Lists[CVDocListName].GetItems(query);
            if (items != null && items.Count > 0)
            {
                cvDocuments.AddRange(from SPListItem item in items
                                     select new CVDocumentsInfo
                                     {
                                         Id = item.ID,
                                         Title = item.Title,
                                         Language = web.Language,
                                         WebUrl = web.Url,
                                         Description = Convert.ToString(item[Constants.CVDocument.InternalFields.Description]),
                                         Created = Convert.ToDateTime(item[Constants.CommonField.Created]).ToShortDateString(),                                         
                                         FileUrl = item.File.Url,
                                         DocumentDate = item[Constants.CVDocument.InternalFields.DocumentDate] != null ? Convert.ToDateTime(item[Constants.CVDocument.InternalFields.DocumentDate]).ToShortDateString() : string.Empty
                                     });
            }

            return cvDocuments;
        }
    }

    public class ContactInforObj
    {
        public string Title { get; set; }
        public string ContactUsr { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }

        public string Email { get; set; }

        public string MailtoEmail
        {
            get
            {
                return "email:" + Email;
            }
        }

        public string TelPhone
        {
            get
            {
                return "tel:" + Phone;
            }
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

                return "";
            }
            set
            {
                _image = value;
            }
        }
    }

    public class HrInfor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class ApplicationInfor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class CareerResultInfor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class CVDocumentsInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string TypeId { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }
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