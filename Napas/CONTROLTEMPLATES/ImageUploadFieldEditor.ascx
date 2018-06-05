<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadFieldEditor.ascx.cs" Inherits="Napas.SharePoint.ImageUploadFieldEditor" %>
<table class="ms-authoringcontrols" border="0" width="100%" cellspacing="0" cellpadding="0">
	<tr>
		<td class="ms-authoringcontrols" colspan="2">
			Upload images to:
		</td>
	</tr>
	<tr><td><img src="/_layouts/15/images/blank.gif" width="1" height="3" style="display: block" alt=""></td></tr>
	<tr>
		<td width="11px"><img src="/_layouts/15/images/blank.gif" width="11" height="1" style="display: block" alt=""/></td>
		<td class="ms-authoringcontrols" width="99%">
			<asp:TextBox ID="txtUploadImagesTo" runat="server" Text="Images" /></td>
	</tr>
</table>