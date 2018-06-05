<%@ Assembly Name="Napas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0c423c40af161a72" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
	Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
	Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Control Language="C#" %>
<!-- The rendering template user controls should be deployed to TEMPLATE\CONTROLTEMPLATES, and not under a sub-folder. -->
<SharePoint:RenderingTemplate ID="ImageUploadField" runat="server">
	<Template>
		<script src="/_layouts/15/Napas.SharePoint/ImageUploadField.js" type="text/javascript"></script>
		<div><asp:Image ID="imgImage" runat="server" /></div>
		<a id="lnkLaunchUploadImagePage" runat="server" href="javascript:launchUploadImagePage('{0}', '{1}', '{2}', '{3}')">Upload an image</a>&nbsp;&nbsp;
		<asp:LinkButton ID="btnRemoveImage" runat="server" Text="Remove image" />
		<input type="hidden" id="hiddenImageUrl" runat="server" />
	</Template>
</SharePoint:RenderingTemplate>
<SharePoint:RenderingTemplate ID="ImageUploadFieldDisplay" runat="server">
	<Template>
		<asp:Image ID="imgImage" runat="server" /></Template>
</SharePoint:RenderingTemplate>
