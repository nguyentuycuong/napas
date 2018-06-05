using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Napas.Portal.Common;

namespace Napas.Portal.Business.EventReceiver
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiver : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            try
            {
                EventFiringEnabled = false;
                base.ItemAdded(properties);
                var item = properties.ListItem;
                var list = properties.List;
                UpdateUrl(list, item);
            }
            finally
            {

                EventFiringEnabled = true;
            }


        }

        /// <summary>
        /// An item was updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            try
            {
                EventFiringEnabled = false;
                base.ItemUpdated(properties);
                var item = properties.ListItem;
                var list = properties.List;
                UpdateUrl(list, item);
            }
            finally
            {

                EventFiringEnabled = true;
            }

        }

        private void UpdateUrl(SPList list, SPListItem item)
        {
            string customUrl = string.Empty;
            if (list.Title.Equals(Constants.News.ListName) || list.Title.Equals(Constants.News.ListNameEnglish))
            {
                var cat = new SPFieldLookupValue(Convert.ToString(item[Constants.News.InternalFields.Category]));
                customUrl = string.Format("{0}?cat={1}&title={2}&catId={3}&id={4}", "newsdetails.aspx", Utilities.ConvertToUnsign(cat.LookupValue), Utilities.ConvertToUnsign(item.Title), cat.LookupId, item.ID);
            }
            else if (list.Title.Equals(Constants.ProductionServices.ListName) || list.Title.Equals(Constants.ProductionServices.ListNameEnglish))
            {
                var cat = new SPFieldLookupValue(Convert.ToString(item[Constants.ProductionServices.InternalFields.ProductsServices]));
                customUrl = string.Format("productsservices.aspx?catName={0}&serviceName={1}&amp;type={2}&amp;catId={3}&amp;serviceId={4}", Utilities.ConvertToUnsign(cat.LookupValue), Utilities.ConvertToUnsign(item.Title), "Thong-tin-san-pham-dich-vu", cat.LookupId, item.ID);
            }
            else if (list.Title.Equals(Constants.Introduction.ListName) || list.Title.Equals(Constants.Introduction.ListNameEnglish))
            {
                customUrl = string.Format("about.aspx?title={0}&id={1}", Utilities.ConvertToUnsign(item.Title), item.ID);
            }
            else if (list.Title.Equals(Constants.MilestonesAchievements.ListName) || list.Title.Equals(Constants.MilestonesAchievements.ListNameEnglish))
            {
                customUrl = "milestones.aspx";
            }
            else if (list.Title.Equals(Constants.MeetingPartners.ListName) || list.Title.Equals(Constants.MeetingPartners.ListName))
            {
                customUrl = string.Format("shareholders-meeting-details.aspx?category={0}&title={1}&id={2}", Utilities.ConvertToUnsign(Convert.ToString(item[Constants.MeetingPartners.InternalFields.Category])), Utilities.ConvertToUnsign(item.Title), item.ID);
            }
            else if (list.Title.Equals(Constants.HumanResource.ListName) || list.Title.Equals(Constants.HumanResource.ListNameEnglish))
            {
                customUrl = "humanresource.aspx";
            }
            else if (list.Title.Equals(Constants.TermsOfUse.ListName) || list.Title.Equals(Constants.TermsOfUse.ListNameEnglish))
            {
                customUrl = "term-of-use.aspx.aspx";
            }
            else if (list.Title.Equals(Constants.DocumentShareholder.ListName) || list.Title.Equals(Constants.DocumentShareholder.ListNameEnglish) ||
                list.Title.Equals(Constants.DocumentLegen.ListName) || list.Title.Equals(Constants.DocumentLegen.ListNameEnglish) ||
                list.Title.Equals(Constants.DocumentOther.ListName) || list.Title.Equals(Constants.DocumentShareholder.ListNameEnglish))
            {
                customUrl = item.File.Url + "?search=.aspx";
            }

            if (list.Fields.ContainsFieldWithStaticName(Constants.CommonField.Custom_URL))
            {
                item[Constants.CommonField.Custom_URL] = customUrl;
                item.SystemUpdate();
            }

        }
    }
}