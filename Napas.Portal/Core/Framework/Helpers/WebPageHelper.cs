using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Napas.Portal.Business;

namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    public static class WebPageHelper
    {
        public static void CreateWebPage(SPWeb web, string fileName, byte[] fileContent)
        {
            web.RootFolder.Files.Add(fileName, fileContent);
        }

        public static void CreateDefaultWebPage(SPWeb web, string fileName, string pageTitle, bool overwrite, bool userDefaultMasterPage)
        {
            CreateDefaultWebPage(web, fileName, pageTitle, overwrite, "Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c", userDefaultMasterPage);
        }

        public static void CreateDefaultWebPage(SPWeb web, string fileName, string pageTitle, bool overwrite, string inherits, bool userDefaultMasterPage)
        {
            var exists = web.RootFolder.Files.Cast<SPFile>().Any(file => file.Name.Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (exists && !overwrite)
            {
                return;
            }

            if (exists)
            {
                var file = web.RootFolder.Files[fileName];
                file.Delete();
            }

            var fileContent = BuildDefaultPageContent(inherits, pageTitle, userDefaultMasterPage);
            //var fileData =  Encoding.Unicode.GetBytes(fileContent);
            var fileData = GetBytes(fileContent);
            
            CreateWebPage(web, fileName, fileData);
        }

        private static string BuildDefaultPageContent(string inherits, string title, bool userDefaultMasterPage)
        {
            //System.Diagnostics.Debugger.Launch();
            var sb = new StringBuilder();
            if (userDefaultMasterPage)
            {
                sb.AppendLine(string.Format("<%@ Page language=\"C#\" MasterPageFile=\"~masterurl/default.master\" Inherits=\"{0}\" meta:webpartpageexpansion=\"full\" %>", inherits));
            }
            else {
                sb.AppendLine(string.Format("<%@ Page language=\"C#\" MasterPageFile=\"~masterurl/custom.master\" Inherits=\"{0}\" meta:webpartpageexpansion=\"full\" %>", inherits));
            }
            sb.AppendLine("<%@ Register Tagprefix=\"SharePoint\" Namespace=\"Microsoft.SharePoint.WebControls\" Assembly=\"Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\" %>");
            sb.AppendLine("<%@ Register Tagprefix=\"Utilities\" Namespace=\"Microsoft.SharePoint.Utilities\" Assembly=\"Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\" %>");
            sb.AppendLine("<%@ Import Namespace=\"Microsoft.SharePoint\" %>");
            sb.AppendLine("<%@ Assembly Name=\"Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\" %>");
            sb.AppendLine("<%@ Register Tagprefix=\"WebPartPages\" Namespace=\"Microsoft.SharePoint.WebPartPages\" Assembly=\"Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\" %>");

            sb.AppendLine("<asp:Content ID=\"PlaceHolderPageTitle\" ContentPlaceHolderId=\"PlaceHolderPageTitle\" runat=\"server\">" + Utilities.ConvertToUnsign(title) + "</asp:Content>");
            sb.AppendLine("<asp:Content ID=\"PlaceHolderPageTitleInTitleArea\" ContentPlaceHolderId=\"PlaceHolderPageTitleInTitleArea\" runat=\"server\"></asp:Content>");
            sb.AppendLine("<asp:Content ID=\"PlaceHolderPageDescription\" ContentPlaceHolderId=\"PlaceHolderPageDescription\" runat=\"server\"></asp:Content>");
            sb.AppendLine("<asp:Content ID=\"PlaceHolderMain\" ContentPlaceHolderId=\"PlaceHolderMain\" runat=\"server\">");
            sb.AppendLine("<SharePoint:ScriptLink Name=\"SP.UI.Dialog.js\" runat=\"server\" OnDemand=\"true\" Localizable=\"false\" />");
            sb.AppendLine("<SharePoint:ScriptLink Name=\"SP.Ribbon.js\" runat=\"server\" OnDemand=\"true\" Localizable=\"false\" />");
            //sb.AppendLine("<table cellpadding=\"4\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
            //sb.AppendLine("<tr>");
            //sb.AppendLine("<td id=\"invisibleIfEmpty\" name=\"_invisibleIfEmpty\" valign=\"top\" width=\"100%\">");
            sb.AppendLine("<WebPartPages:WebPartZone runat=\"server\" Title=\"loc:Main\" ID=\"Main\" FrameType=\"TitleBarOnly\"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>");
            //sb.AppendLine("</td>");
            //sb.AppendLine("</tr>");
            sb.AppendLine("</asp:Content>");
            return sb.ToString();
        }

        /// <summary>
        /// Delete a page in root web by file name
        /// </summary>
        /// <param name="web"></param>
        /// <param name="fileName">A file name like Default.aspx</param>
        public static void DeleteWebPage(SPWeb web, string fileName)
        {
            var exists = web.RootFolder.Files.Cast<SPFile>().Any(file => file.Name.Equals(fileName, StringComparison.InvariantCultureIgnoreCase));
            if (exists)
            {
                web.RootFolder.Files.Delete(fileName);
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
