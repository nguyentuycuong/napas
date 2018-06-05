<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HumanResource.ascx.cs" Inherits="Napas.Portal.ControlTemplates.HumanResource" %>
<section class="intro-banner intro-banner-news"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,Url%>" cssclass="home">
                     <i class="fa fa-home"></i>
                 </sharepoint:splinkbutton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlCareer%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Career%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlHR%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,HR%>" />
                </SharePoint:SPLinkButton>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li >
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlCareer%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerPage%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li class="active">
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlHR%>'>
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,HR%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li >
                             <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlContactInfor%>'>
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,ContactInfor%>" />
                            </SharePoint:SPLinkButton>
                        </li>                        
                    </ul>
                </div>
                <div class="colright">
                    <div style="text-align: justify">
                        <p><asp:Literal runat="server" ID="ltContent"></asp:Literal></p>
                    </div>                    
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</section>
