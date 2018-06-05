using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Napas.Portal.Business
{
    public class ProductsServicesGroup
    {
        public static string listName;
        //public static SPWeb web;
        //public static SPList list;

        public ProductsServicesGroup(SPWeb _web)
        {
            //  web = _web;
            if (_web.Language == 1033)
            {
                listName = Constants.ProductionServicesGroup.ListNameEnglish;
            }
            else
            {
                listName = Constants.ProductionServicesGroup.ListName;
            }
        }
        
        public List<ProductsServicesMenu> get_ProductsServicesMenu(SPWeb web)
        {

            var pList = web.Lists[web.Language == 1033 ? Constants.ProductionServices.ListNameEnglish : Constants.ProductionServices.ListName];
            var productsServicesMenu = new List<ProductsServicesMenu>();
            var query =
                Camlex.Query()
                    .Where(c => (Boolean)c[Constants.ProductionServicesGroup.InternalFields.Activate])
                    .OrderBy(c => c[Constants.ProductionServicesGroup.InternalFields.Order] as Camlex.Asc).ToSPQuery();

            var list = web.Lists[listName];
            var items = list.GetItems(query);
            if (items.Count > 0)
            {                
                foreach (SPListItem item in items)
                {
                    var menu = new ProductsServicesMenu()
                    {
                        Title = item.Title,
                        Id = item.ID,
                        level = 1,
                        subTitle = string.Empty,
                        Url = "#"
                    };
                    productsServicesMenu.Add(menu);

                    var level2 = get_Level2(web, pList, item.ID.ToString());
                    foreach (SPListItem subItem in level2)
                    {
                        menu = new ProductsServicesMenu()
                        {
                            Title = subItem.Title,
                            Id = subItem.ID,
                            level = 2,
                            subTitle = string.Empty,
                            ParrentId = item.ID,
                            Url =web.Language == 1033? string.Format("{0}/for customers/{1}/{2}-{3}-{4}.html", web.Url, Utilities.ConvertToUnsign(item.Title), Utilities.ConvertToUnsign(subItem.Title), item.ID, subItem.ID):string.Format("{0}/san-pham-dich-vu/{1}/{2}/{3}-{4}-{5}.html", web.Url, Utilities.ConvertToUnsign(item.Title), Utilities.ConvertToUnsign(subItem.Title), "Thong-tin-san-pham-dich-vu", item.ID, subItem.ID),
                        };

                        productsServicesMenu.Add(menu);
                        var level3 = get_Level3(web, pList, subItem.ID.ToString());
                        foreach (SPListItem l3 in level3)
                        {
                            var sTitle = new SPFieldLookupValue(Convert.ToString(l3[Constants.ProductionServices.InternalFields.SubService]));
                            menu = new ProductsServicesMenu()
                            {
                                Title = l3.Title,
                                Id = l3.ID,
                                level = 3,
                                subTitle = sTitle.LookupValue,
                                ParrentId = subItem.ID,
                                Url = web.Language == 1033 ? string.Format("{0}/for customers/{1}/{2}-{3}-{4}.html", web.Url, Utilities.ConvertToUnsign(item.Title), Utilities.ConvertToUnsign(l3.Title), item.ID, l3.ID) : string.Format("{0}/san-pham-dich-vu/{1}/{2}/{3}-{4}-{5}.html", web.Url, Utilities.ConvertToUnsign(item.Title), Utilities.ConvertToUnsign(l3.Title), "Thong-tin-san-pham-dich-vu", item.ID, l3.ID),
                            };

                            productsServicesMenu.Add(menu);
                        }
                    }
                }
            }

            return productsServicesMenu;
        }

        private SPListItemCollection get_Level2(SPWeb web, SPList list, string id)
        {
            var query = Camlex.Query().Where(c => c[Constants.ProductionServices.InternalFields.ProductsServices] == (DataTypes.LookupId)id &&
                            (Boolean)c[Constants.ProductionServices.InternalFields.Activate] && c[Constants.ProductionServices.InternalFields.SubService] == null)
                    .OrderBy(c => c[Constants.ProductionServices.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();
            var items = list.GetItems(query);

            return items;
        }

        private SPListItemCollection get_Level3(SPWeb web, SPList list, string id)
        {
            var query =
                Camlex.Query()
                    .Where(
                        c =>
                            c[Constants.ProductionServices.InternalFields.SubService] == (DataTypes.LookupId)id &&
                            (Boolean)c[Constants.ProductionServices.InternalFields.Activate])
                    .OrderBy(c => c[Constants.ProductionServices.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();
            var items = list.GetItems(query);

            return items;
        }
    }

    public class ProductsServicesGroupInfo
    {
        public uint Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string WebUrl { get; set; }

        private string _currentCatId;

        public string CatIDActive
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentCatId) && _currentCatId.Equals(Convert.ToString(Id)))
                {
                    return "active";
                }

                return string.Empty;
            }
            set
            {
                _currentCatId = value;
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

                return "../../_catalogs/masterpage/napas_theme/images/m_icon9.png"; ;
            }
            set
            {
                _image = value;
            }
        }

        private string _menuIcon;

        public string MenuIcon
        {
            get
            {
                if (!string.IsNullOrEmpty(_menuIcon))
                {
                    return _menuIcon.Split(',')[0];
                }

                return "../../_catalogs/masterpage/napas_theme/images/m_icon9.png";
            }
            set { _menuIcon = value; }
        }

        public string Url
        {
            get
            {
                if (Language != 1033)
                    return string.Format("{0}/san-pham-dich-vu/{1}-{2}.html", WebUrl, Utilities.ConvertToUnsign(Title), Id);
                else
                    return string.Format("{0}/products-services/{1}-{2}.html", WebUrl, Utilities.ConvertToUnsign(Title).ToLower(), Id);
            }
        }
    }

    public class ProductsServicesMenu
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public int level { get; set; }
        public string subTitle { get; set; }
        public int ParrentId { get; set; }
        public string Url { get; set; }
    }
}