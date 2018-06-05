using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;

namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    /// <summary>
    ///   A helper support create a new list instance
    /// </summary>
    public class ListHelper
    {
        private readonly List<BaseFieldCreator> creators;
        private readonly SPWeb web;

        public ListHelper(SPWeb web)
        {
            this.web = web;
            creators = new List<BaseFieldCreator>();
            ListTemplateType = SPListTemplateType.GenericList;
            Views = new List<ViewCreator>();
            EnableAttachments = false;
            DisableListThrottling = false;
            OnQuickLaunch = true;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public SPListTemplateType ListTemplateType { get; set; }

        public bool OnQuickLaunch { get; set; }

        /// <summary>
        /// Indicates whether throttling for this list is disable.
        /// </summary>
        public bool DisableListThrottling { get; set; }
        
        /// <summary>
        /// Gets or sets a Boolean value that specifies whether attachments can be added to items in the list.
        /// </summary>
        public bool EnableAttachments { get; set; }

        public IList<ViewCreator> Views { get; private set; }

        /// <summary>
        /// Create a list with fields
        /// </summary>
        /// <returns></returns>
        public SPList Apply()
        {
            var list = CreateList(Title, Description, ListTemplateType);

            if (!(ListTemplateType == SPListTemplateType.DocumentLibrary || ListTemplateType == SPListTemplateType.Survey))
            {
                list.EnableAttachments = EnableAttachments;
            }
            list.EnableThrottling = !DisableListThrottling;
            list.OnQuickLaunch = OnQuickLaunch;
            list.Update();

            // Create views
            foreach (var viewCreator in Views)
            {
                viewCreator.Apply(list);
            }

            // Replace views
            foreach (var view in Views)
            {
                if (!string.IsNullOrEmpty(view.UserControlPath))
                {
                    view.ReplaceViewControl(web, list);    
                }
            }

            return list;
        }

        private SPList CreateList(string title, string description, SPListTemplateType listTemplateType)
        {
            var list = web.Lists.TryGetList(title);

            if (list == null)
            {
                var id = web.Lists.Add(title, description, listTemplateType);
                list = web.Lists[id];

                try
                {
                    foreach (var creator in creators)
                    {
                        creator.CreateField(list);
                    }
                    
                    return list;
                }
                catch (Exception ex)
                {
                    if (id != Guid.Empty)
                    {
                        web.Lists[id].Delete();
                    }

                    throw new ArgumentException(
                        string.Format("Cannot create a list '{0}' because: {1}", title, ex.Message), ex);
                }
            }
            
            return list;
        }

        public void AddField(BaseFieldCreator creator)
        {
            creators.Add(creator);
        }

        /// <summary>
        /// Indicates whether throttling for this list is disable.
        /// </summary>
        public static void DisableListThreshold(SPList list)
        {
            list.EnableThrottling = false;
            list.Update();
        }

        /// <summary>
        /// Indicates whether field will indexed.
        /// </summary>
        /// <param name="field"></param>
        public static void CreateIndexedField(SPField field)
        {
            if (!field.Indexed)
            {
                field.Indexed = true;
                field.Update();
            }
        }

        /// <summary>
        /// Indicates whether field will indexed.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="fieldName"></param>
        public static void CreateIndexedField(SPList list, string fieldName)
        {
            var field = list.Fields[fieldName];
            CreateIndexedField(field);
        }

        /// <summary>
        /// Delete user custom action item button for a list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="actionId"></param>
        public static void DeleteUserCustomAction(SPList list, string actionId)
        {
            var btnCustomRibbon = list.UserCustomActions.FirstOrDefault(c => c.Name == actionId);
            if (btnCustomRibbon != null)
            {
                btnCustomRibbon.Delete();
                list.Update();
            }
        }
    }
}