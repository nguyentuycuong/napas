﻿using System;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NAPAS.Portal.Common.Framework.Core.WebParts;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    /// <summary>
    /// </summary>
    public static class WebPartHelper
    {
        /// <summary>
        ///   Get a WebPart instance from WebPart gallery.
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "webPartName"></param>
        /// <returns></returns>
        public static WebPart GetWebPart(SPWeb web, string webPartName)
        {
            var query = new SPQuery
                            {
                                Query =
                                    "<Where><Eq><FieldRef Name='FileLeafRef'/><Value Type='File'>" + webPartName +
                                    "</Value></Eq></Where>"
                            };
            var webPartGallery = web.Site.RootWeb.GetCatalog(SPListTemplateType.WebPartCatalog);
            var webParts = webPartGallery.GetItems(query);
            if (webParts.Count == 0)
            {
                return null;
            }

            var typeName = webParts[0].GetFormattedValue("WebPartTypeName");
            var assemblyName = webParts[0].GetFormattedValue("WebPartAssembly");

            var webPartHandle = Activator.CreateInstance(assemblyName, typeName);
            if (webPartHandle == null)
            {
                return null;
            }

            var webPart = (WebPart) webPartHandle.Unwrap();
            return webPart;
        }

        /// <summary>
        ///   Get container web part instance
        /// </summary>
        /// <param name = "web"></param>
        /// <returns></returns>
        public static ContainerWebPart GetContainerWebPart(SPWeb web)
        {
            return new ContainerWebPart();
        }

        /// <summary>
        /// Add web part to page
        /// </summary>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        /// <param name="webPartName"></param>
        /// <param name="zoneId"></param>
        /// <param name="zoneIndex"></param>
        /// <returns></returns>
        public static string AddWebPart(SPWeb web, string pageUrl, string webPartName, string zoneId, int zoneIndex)
        {
            var webPart = GetWebPart(web, webPartName);
            if (webPart == null)
            {
                return null;
            }

            return AddWebPart(web, pageUrl, webPart, zoneId, zoneIndex);
        }

        /// <summary>
        /// Add web part to page
        /// </summary>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        /// <param name="webPart"></param>
        /// <param name="zoneId"></param>
        /// <param name="zoneIndex"></param>
        /// <returns></returns>
        public static string AddWebPart(SPWeb web, string pageUrl, WebPart webPart, string zoneId, int zoneIndex)
        {
            if (string.IsNullOrEmpty(webPart.Title))
            {
                throw new ArgumentException("The WebPart must be has title.");
            }

            var page = web.GetFile(pageUrl);
            using (var webPartManager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                try
                {
                    var oldWebParts = webPartManager.WebParts.Cast<WebPart>().Where(wp => wp.Title == webPart.Title).ToList();
                    foreach (var oldWebPart in oldWebParts)
                    {
                        webPartManager.DeleteWebPart(oldWebPart);
                    }
                    
                    webPartManager.AddWebPart(webPart, zoneId, zoneIndex);

                    return webPart.ID;
                }
                finally
                {
                    webPartManager.Web.Dispose();
                }
            }
        }

        /// <summary>
        ///   Add web part to new page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        /// <param name = "webPart"></param>
        /// <returns></returns>
        public static string AddWebPartToNewPage(SPWeb web, SPList list, WebPart webPart)
        {
            var url = list.Forms[PAGETYPE.PAGE_NEWFORM].Url;
            return AddWebPart(web, url, webPart, "Main", 0);
        }

        /// <summary>
        ///   Add web part to display page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        /// <param name = "webPart"></param>
        /// <returns></returns>
        public static string AddWebPartToDisplayPage(SPWeb web, SPList list, WebPart webPart)
        {
            var url = list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
            return AddWebPart(web, url, webPart, "Main", 0);
        }

        /// <summary>
        ///   Add web part to edit page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        /// <param name = "webPart"></param>
        /// <returns></returns>
        public static string AddWebPartToEditPage(SPWeb web, SPList list, WebPart webPart)
        {
            var url = list.Forms[PAGETYPE.PAGE_EDITFORM].Url;

            return AddWebPart(web, url, webPart, "Main", 0);
        }

        /// <summary>
        /// Add web part to upload page
        /// </summary>
        /// <param name="web"></param>
        /// <param name="list"></param>
        /// <param name="webPart"></param>
        /// <returns></returns>
        public static string AddWebPartToUploadPage(SPWeb web, SPList list, WebPart webPart)
        {
            var url = list.Forms[PAGETYPE.PAGE_EDITFORM].Url;
            return AddWebPart(web, url.Replace("EditForm.aspx","Upload.aspx"), webPart, "Main", 0);
        }

        /// <summary>
        /// Add web part to view page
        /// </summary>
        /// <param name="web"></param>
        /// <param name="view"></param>
        /// <param name="webPart"></param>
        /// <returns></returns>
        public static string AddWebPartToViewPage(SPWeb web, SPView view, WebPart webPart)
        {
            return AddWebPart(web, view.Url, webPart, "Main", 0);
        }

        /// <summary>
        /// Add web part to view page
        /// </summary>
        /// <param name="web"></param>
        /// <param name="list"></param>
        /// <param name="viewName"></param>
        /// <param name="webPart"></param>
        /// <returns></returns>
        public static string AddWebPartToViewPage(SPWeb web, SPList list, string viewName, WebPart webPart)
        {
            var view = list.Views[viewName];
            return AddWebPartToViewPage(web, view, webPart);
        }

        /// <summary>
        /// Hide web part by page url
        /// </summary>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        /// <param name="webPartTitle"></param>
        public static void HideWebPart(SPWeb web, string pageUrl, string webPartTitle)
        {
            var page = web.GetFile(pageUrl);
            using (var webPartManager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                try
                {
                    foreach (var webPart in
                        webPartManager.WebParts.Cast<WebPart>().Where(webPart => webPart.Title == webPartTitle && !webPart.Hidden))
                    {
                        webPart.Hidden = true;
                        webPartManager.SaveChanges(webPart);
                    }    
                }
                finally
                {
                    webPartManager.Web.Dispose();   
                }
            }
        }

        /// <summary>
        /// Hide web part by page url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        public static void HideWebPart<T>(SPWeb web, string pageUrl) where T : WebPart
        {
            var page = web.GetFile(pageUrl);
            using (var webPartManager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                try
                {
                    foreach (var webPart in webPartManager.WebParts.Cast<WebPart>().Where(webPart => webPart.GetType() == typeof(T) && !webPart.Hidden))
                    {
                        webPart.Hidden = true;
                        webPartManager.SaveChanges(webPart);
                    }
                }
                finally
                {
                    webPartManager.Web.Dispose();
                }
            }
        }

        /// <summary>
        ///   Hide default web part on new page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        public static void HideDefaultWebPartOnNewPage(SPWeb web, SPList list)
        {
            var url = list.Forms[PAGETYPE.PAGE_NEWFORM].Url;
            HideWebPart<ListFormWebPart>(web, url);
        }

        /// <summary>
        ///   Hide default web part on display page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        public static void HideDefaultWebPartOnDisplayPage(SPWeb web, SPList list)
        {
            var url = list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
            HideWebPart<ListFormWebPart>(web, url);
        }

        /// <summary>
        ///   Hide default web part on edit page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        public static void HideDefaultWebPartOnEditPage(SPWeb web, SPList list)
        {
            var url = list.Forms[PAGETYPE.PAGE_EDITFORM].Url;
            HideWebPart<ListFormWebPart>(web, url);
        }

        /// <summary>
        ///   Show default web part on new page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        public static void ShowDefaultWebPartOnNewPage(SPWeb web, SPList list)
        {
            var url = list.Forms[PAGETYPE.PAGE_NEWFORM].Url;
            ShowWebPart<ListFormWebPart>(web, url);
        }

        /// <summary>
        ///   Show default web part on display page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        public static void ShowDefaultWebPartOnDisplayPage(SPWeb web, SPList list)
        {
            var url = list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
            ShowWebPart<ListFormWebPart>(web, url);
        }

        /// <summary>
        ///   Show default web part on edit page
        /// </summary>
        /// <param name = "web"></param>
        /// <param name = "list"></param>
        public static void ShowDefaultWebPartOnEditPage(SPWeb web, SPList list)
        {
            var url = list.Forms[PAGETYPE.PAGE_EDITFORM].Url;
            ShowWebPart<ListFormWebPart>(web, url);
        }

        /// <summary>
        /// Hide default web part on view
        /// </summary>
        /// <param name="web"></param>
        /// <param name="view"></param>
        public static void HideDefaultWebPartOnView(SPWeb web, SPView view)
        {
            HideWebPart<XsltListViewWebPart>(web, view.Url);
        }

        /// <summary>
        /// Show default web part on view
        /// </summary>
        /// <param name="web"></param>
        /// <param name="view"></param>
        public static void ShowDefaultWebPartOnView(SPWeb web, SPView view)
        {
            ShowWebPart<XsltListViewWebPart>(web, view.Url);
        }

        /// <summary>
        /// Show web part by page url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        public static void ShowWebPart<T>(SPWeb web, string pageUrl) where T : WebPart
        {
            var page = web.GetFile(pageUrl);
            using (var webPartManager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                try
                {
                    foreach (var webPart in webPartManager.WebParts.Cast<WebPart>().Where(webPart => webPart.GetType() == typeof(T) && webPart.Hidden))
                    {
                        webPart.Hidden = false;
                        webPartManager.SaveChanges(webPart);
                    }
                }
                finally
                {
                    webPartManager.Web.Dispose();
                }
            }
        }

        /// <summary>
        /// Remove web part by page url
        /// </summary>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        /// <param name="title"></param>
        public static void RemoveWebPart(SPWeb web, string pageUrl, string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("The WebPart must be has title.");
            }

            var page = web.GetFile(pageUrl);
            using (var webPartManager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                try
                {
                    var oldWebParts = webPartManager.WebParts.Cast<WebPart>().Where(wp => wp.Title == title).ToList();
                    foreach (var oldWebPart in oldWebParts)
                    {
                        webPartManager.DeleteWebPart(oldWebPart);
                    }
                }
                finally
                {
                    webPartManager.Web.Dispose();
                }
            }
        }

        /// <summary>
        /// Remove web part by page name
        /// </summary>
        /// <param name="web"></param>
        /// <param name="pageUrl"></param>
        /// <param name="fullName"></param>
        public static void RemoveWebPartByFullName(SPWeb web, string pageUrl, string fullName)
        {
            var page = web.GetFile(pageUrl);
            using (var webPartManager = page.GetLimitedWebPartManager(PersonalizationScope.Shared))
            {
                try
                {
                    var oldWebParts = webPartManager.WebParts.Cast<WebPart>().Where(wp => string.Equals(wp.GetType().FullName, fullName)).ToList();
                    foreach (var oldWebPart in oldWebParts)
                    {
                        webPartManager.DeleteWebPart(oldWebPart);
                    }
                }
                finally
                {
                    webPartManager.Web.Dispose();
                }
            }
        }
    }
}