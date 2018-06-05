<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrganizationBoardAssembly.ascx.cs" Inherits="Napas.Portal.ControlTemplates.OrganizationBoardAssembly" %>

<section class="intro-banner"></section>

<div class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                 <SharePoint:SPLinkButton runat="server" NavigateUrl='#'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,AboutUs%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlGeneralAssembly%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,GeneralAssembly%>" />
                </SharePoint:SPLinkButton>

            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <asp:Repeater runat="server" ID="rpAbout">
                            <ItemTemplate>
                                <li class='<%#Eval("Active") %>'>
                                    <a href='<%#Eval("Url") %>'>
                                        <i class="fa fa-angle-right"></i>
                                        <%#Eval("Title") %>
                                    </a>

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li class="active">
                            <a href="#">
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Organization%>" />
                            </a>
                            <ul class="lv2">
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlOrganizationChart%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,OrganizationChart%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li class="active">
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlGeneralAssembly%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,GeneralAssembly%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlExecutiveBoard%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,ExecutiveBoard%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlExecutiveCommittee%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,ExecutiveCommittee%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl="~site/milestones.aspx">
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,MilestonesAchievements%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                    </ul>
                </div>
                <div class="co-cau">
                    <div class="colright">
                        <h2 class="title">
                            <img src="/_catalogs/masterpage/napas_theme/images/tree_icon_diff.png">
                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,GeneralAssembly%>"></asp:Literal>
                        </h2>                        
                        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</div>

