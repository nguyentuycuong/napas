<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Career.ascx.cs" Inherits="Napas.Portal.ControlTemplates.Career" %>
<section class="intro-banner intro-banner-ns"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlCareer%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Career%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlCareerInfor%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerInfor%>" />
                </SharePoint:SPLinkButton>
            </div>
            <div class="cols" style="text-align: justify">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li class="active">
                            <a href="#">
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerPage%>" />
                            </a>
                            <ul class="lv2">
                                <li class="active">
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlCareerInfor%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerInfor%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlCareerResult%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerResult%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlCVDocument%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,CVDocument%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlHR%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,HR%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlContactInfor%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,ContactInfor%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                    </ul>
                </div>
                <div style="text-align: justify">
                    <div class="information-recruitment">
                        <h1 class="heading">
                            <img src="/_catalogs/masterpage/napas_theme/images/information-recruitment-icon.png" />
                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,RecruitmentInformation%>" /></h1>
                        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</section>
