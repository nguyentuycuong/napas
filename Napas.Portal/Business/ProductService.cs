using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Napas.Portal.Business
{
    public class ProductService
    {
        public static string listName;
        // public static SPWeb web;
        //public static SPList list;

        public ProductService(SPWeb _web)
        {
            //web = _web;
            if (_web.Language == 1033)
            {
                listName = Constants.ProductionServices.ListNameEnglish;
            }
            else
            {
                listName = Constants.ProductionServices.ListName;
            }
            
        }

        public ProductServiceInfo get_ProductSeviceInfoById(SPWeb web, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var query =
                    Camlex.Query()
                        .Where(
                            c =>
                                (int)c[Constants.CommonField.ID] == Convert.ToInt32(id) &&
                                (Boolean)c[Constants.ProductionServices.InternalFields.Activate])
                        .ToSPQuery();

                query.ViewFields = Camlex.Query().ViewFields(x => new[] { x[Constants.ProductionServices.InternalFields.Content],
                    x[Constants.ProductionServices.InternalFields.Content1] ,
                    x[Constants.ProductionServices.InternalFields.Content2],
                    x[Constants.ProductionServices.InternalFields.Content3],
                    x[Constants.ProductionServices.InternalFields.Content4],
                    x[Constants.ProductionServices.InternalFields.Partner1],
                    x[Constants.ProductionServices.InternalFields.Partner2],
                    x[Constants.ProductionServices.InternalFields.Partner3],
                    x[Constants.ProductionServices.InternalFields.SubService],
                    x[Constants.ProductionServices.InternalFields.ProductsServices],
                    x[Constants.ProductionServices.InternalFields.IsShowVenders],
                    x[Constants.ProductionServices.InternalFields.Tranformer],
                    x[Constants.ProductionServices.InternalFields.Retail],
                    x[Constants.ProductionServices.InternalFields.Communication],
                    x[Constants.ProductionServices.InternalFields.Ensurance],
                    x[Constants.ProductionServices.InternalFields.Game],
                    x[Constants.ProductionServices.InternalFields.Digital],
                    x[Constants.ProductionServices.InternalFields.ElectronicWallet],
                    x[Constants.ProductionServices.InternalFields.AnotherServices],
                    x[Constants.CommonField.Title],
                    x[Constants.CommonField.ID]});

                var list = web.Lists[listName];
                var items = list.GetItems(query);
                if (items.Count > 0)
                {
                    var item = items[0];
                    return new ProductServiceInfo()
                    {
                        Id = item.ID,
                        Title = item.Title,
                        WebUrl = web.Url,
                        Language = web.Language,
                        Content = Convert.ToString(item[Constants.ProductionServices.InternalFields.Content]),
                        Content1 = Convert.ToString(item[Constants.ProductionServices.InternalFields.Content1]),
                        Content2 = Convert.ToString(item[Constants.ProductionServices.InternalFields.Content2]),
                        Content3 = Convert.ToString(item[Constants.ProductionServices.InternalFields.Content3]),
                        Content4 = Convert.ToString(item[Constants.ProductionServices.InternalFields.Content4]),

                        Partner1 = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Partner1])),
                        Partner2 = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Partner2])),
                        Partner3 = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Partner3])),
                        SubServiceValue = new SPFieldLookupValue(Convert.ToString(item[Constants.ProductionServices.InternalFields.SubService])),
                        FullCat = Convert.ToString(item[Constants.ProductionServices.InternalFields.ProductsServices]),

                        HasVenders = Convert.ToBoolean(item[Constants.ProductionServices.InternalFields.IsShowVenders]),
                        Tranformer = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Tranformer])),
                        Retail = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Retail])),
                        Communication = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Communication])),
                        Ensurance = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Ensurance])),
                        Game = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Game])),
                        Digital = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.Digital])),
                        ElectronicWallet = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.ElectronicWallet])),
                        Other = new SPFieldLookupValueCollection(Convert.ToString(item[Constants.ProductionServices.InternalFields.AnotherServices])),
                        List = list,
                    };
                }
            }

            return new ProductServiceInfo();
        }                
    }

    public class ProductServiceInfo
    {
        public SPList List { get; set; }
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }
        public string Content { get; set; }
        public SPFieldLookupValueCollection Partner1 { get; set; }
        public string Content1 { get; set; }
        public SPFieldLookupValueCollection Partner2 { get; set; }
        public string Content2 { get; set; }
        public SPFieldLookupValueCollection Partner3 { get; set; }
        public string Content3 { get; set; }
        public string Content4 { get; set; }

        public SPFieldLookupValue SubServiceValue { get; set; }

        // public SPFieldLookupValue SubService { get; set; }

        private int? _SubService;

        public int SubService
        {
            get
            {
                if (_SubService != null)
                    return Convert.ToInt32(_SubService);
                return 0;
            }
            set { _SubService = value; }
        }

        private string _cat;
        public string FullCat { get; set; }

        public string catId
        {
            get
            {
                if (!string.IsNullOrEmpty(FullCat) && FullCat.Contains(";#"))
                {
                    return Regex.Split(FullCat, ";#")[0];
                }

                return "0";
            }
        }

        public string catValue
        {
            get
            {
                if (!string.IsNullOrEmpty(FullCat) && FullCat.Contains(";#"))
                {
                    return Regex.Split(FullCat, ";#")[1];
                }

                return string.Empty;
            }
        }

        

        public bool HasVenders { get; set; }

        public bool DisplayBankInService { get; set; }
        public bool CollectPayOnBehalf { get; set; }

        public SPFieldLookupValueCollection Banks { get; set; }
        public SPFieldLookupValueCollection Venders { get; set; }
        public string Note { get; set; }
                
        public SPFieldLookupValueCollection Tranformer { get; set; }
        public SPFieldLookupValueCollection Retail { get; set; }
        public SPFieldLookupValueCollection Communication { get; set; }
        public SPFieldLookupValueCollection Ensurance { get; set; }
        public SPFieldLookupValueCollection Game { get; set; }
        public SPFieldLookupValueCollection Digital { get; set; }
        public SPFieldLookupValueCollection ElectronicWallet { get; set; }
        public SPFieldLookupValueCollection Other { get; set; }        
    }
}