<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TermOfUse.ascx.cs" Inherits="Napas.Portal.ControlTemplates.TermOfUse" %>
<section class="intro-banner intro-banner-dk"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlTermsAndConditionOfUse%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,TermsAndConditionOfUse%>" /></SharePoint:SPLinkButton>
                <span>|</span>
                <a class="current">
                <asp:Literal ID="ltCat" runat="server"></asp:Literal>
                </a>
            </div>

            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                         <asp:Repeater runat="server" ID="rpItems">
                        <ItemTemplate>
                            
                            <li class='<%#Eval("Active") %>'>
                            <a href='<%#Eval("Url") %>'><i class="fa fa-angle-right"></i><%#Eval("Title") %></a>
                        </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                   
                </div>
                <div class="colright" style="text-align: justify">
                    <asp:Literal runat="server" ID="ltContent"></asp:Literal>

                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
