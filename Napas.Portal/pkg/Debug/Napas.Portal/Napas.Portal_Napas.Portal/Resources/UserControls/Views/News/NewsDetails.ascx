<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetails.ascx.cs" Inherits="Napas.Portal.ControlTemplates.NewsDetails" %>
<%@ Register Src="NewsLeftMenu.ascx" TagName="NewsLeftMenu" TagPrefix="uc1" %>
<section class="intro-banner intro-banner-news"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlNews%>'><asp:Literal runat="server" Text="<%$Resources:napas.resource,News%>" /></SharePoint:SPLinkButton>
                <span>|</span>
                <asp:Literal ID="ltCat" runat="server"></asp:Literal>
            </div>

            <div class="cols">
                <div class="colleft">
                    <uc1:newsleftmenu id="NewsLeftMenu2" runat="server" />
                </div>
                <div class="colright">
                    <!-- ===== STARTER: Main Placeholder gets replaced with content of the page ======================================= -->
                    <div class="news-detail" style="text-align: justify">
                        <p class="date"><asp:Literal runat="server" ID="ltCreated"></asp:Literal></p>
                                <h1><asp:Literal runat="server" ID="ltTitle"></asp:Literal></h1>
                                <p class="sapo"><asp:Literal runat="server" ID="ltDescription"></asp:Literal></p>
                                <p><asp:Literal runat="server" ID="ltContent"></asp:Literal></p>
                    </div>

                    <div class="news-related" runat="server" id="divRef">
                        <h4>Tin cũ liên quan</h4>
                        <ul>
                            <asp:Repeater ID="rpRelated" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <a href="<%#Eval("Url") %>">
                                            <i class="fa fa-angle-right"></i>
                                            <%#Eval("Title") %> (<%#Eval("Created") %>)
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
