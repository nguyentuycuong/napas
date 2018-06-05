using CamlexNET;
using Microsoft.SharePoint;
using Napas.Portal.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace Napas.Portal.Business
{
    public class Organization
    {
        public static string listName;
        
        public static string listOrganizationChartName;
        public static string listOrganizationBroadName;

        public Organization(SPWeb _web)
        {
        
            if (_web.Language == 1033)
            {
                listName = Constants.Organization.ListNameEnglish;
                listOrganizationChartName = Constants.OrganizationChart.ListNameEnglish;
                listOrganizationBroadName = Constants.OrganizationBroad.ListNameEnglish;
            }
            else
            {
                listName = Constants.Organization.ListName;
                listOrganizationChartName = Constants.OrganizationChart.ListName;
                listOrganizationBroadName = Constants.OrganizationBroad.ListName;
            }

            
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable("Data");
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable getOrganization(SPWeb web)
        {
            List<OrganizationInfor> ogr = new List<OrganizationInfor>();
            var query = Camlex.Query().OrderBy(c => c[Constants.CommonField.Created]).ToSPQuery();
            var list = web.Lists[listName];
            var items = list.GetItems(query);
            if (items != null)
                foreach (SPListItem item in items)
                {
                    ogr.Add(
                        new OrganizationInfor
                        {
                            Id = item.ID - 1,
                            title = item[Constants.Organization.InternalFields.Name].ToString(),
                            description = Convert.ToString(item[Constants.Organization.InternalFields.Description]),                            
                            parentId = item[Constants.Organization.InternalFields.Parent] == null ? 0 : int.Parse((item[Constants.Organization.InternalFields.Parent].ToString()).Split(";#".ToCharArray())[0]) - 1
                        });
                }
            return ConvertToDataTable<OrganizationInfor>(ogr);
        }

        public List<OrganizationChartInfor> getOrganizationChart(SPWeb web)
        {
            var getOrganizationChart = new List<OrganizationChartInfor>();

            var query =
                Camlex.Query()
                    .Where(
                        c =>
                            (Boolean)c[Constants.OrganizationChart.InternalFields.Activate])
                    .OrderBy(c => c[Constants.CommonField.Title])
                    .ToSPQuery();
            var items = web.Lists[listOrganizationChartName].GetItems(query);
            if (items.Count > 0)
            {
                getOrganizationChart.AddRange(from SPListItem item in items
                                              select new OrganizationChartInfor()
                                           {
                                               title = item.Title,
                                               description = Convert.ToString(item[Constants.OrganizationChart.InternalFields.Description]),
                                               //Image = Convert.ToString(item[Constants.OrganizationChart.InternalFields.Image])
                                           });
            }

            return getOrganizationChart;
        }

        public List<OrganizationBroadInfor> getOrganizationBroad(SPWeb web, string division)
        {
            var getOrganizationBroad = new List<OrganizationBroadInfor>();

            var query =
                Camlex.Query()
                    .Where(
                        c =>
                            (Boolean)c[Constants.OrganizationBroad.InternalFields.Activate] && (string)c[Constants.OrganizationBroad.InternalFields.Division] == division)
                    .OrderBy(c => c[Constants.OrganizationBroad.InternalFields.Level]).OrderBy(c => c[Constants.OrganizationBroad.InternalFields.Order] as Camlex.Asc)
                    .ToSPQuery();
            var items = web.Lists[listOrganizationBroadName].GetItems(query);
            if (items.Count > 0)
            {
                getOrganizationBroad.AddRange(from SPListItem item in items
                                              select new OrganizationBroadInfor()
                                              {
                                                  Id = item.ID,
                                                  title = item.Title,
                                                  division = Convert.ToString(item[Constants.OrganizationBroad.InternalFields.Division]),
                                                  personname = Convert.ToString(item[Constants.OrganizationBroad.InternalFields.PersonName]),
                                                  duty = Convert.ToString(item[Constants.OrganizationBroad.InternalFields.Duty]),
                                                  level = Convert.ToString(item[Constants.OrganizationBroad.InternalFields.Level]),
                                                  history = Convert.ToString(item[Constants.OrganizationBroad.InternalFields.History]),
                                                  Image = Convert.ToString(item[Constants.OrganizationBroad.InternalFields.Image])
                                              });
            }

            return getOrganizationBroad;
        }
    }

    public class OrganizationInfor
    {
        public string title { get; set; }
        public int Id { get; set; }
        public string description { get; set; }

        // public string parent { get; set; }
        public int parentId { get; set; }
    }

    public class OrganizationChartInfor
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class OrganizationBroadInfor
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string division { get; set; }
        public string personname { get; set; }
        public string duty { get; set; }
        public string level { get; set; }
        public string history { get; set; }
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
}