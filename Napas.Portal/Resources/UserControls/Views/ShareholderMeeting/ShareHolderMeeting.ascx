<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareHolderMeeting.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ShareHolderMeeting" %>

<section class="intro-banner intro-banner-cd"></section>

<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,Url%>' runat="server" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlShareholderMeeting%>' runat="server">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,ForPartners%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlShareholderMeeting%>' runat="server" CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,ShareholdersMeeting%>" />
                </SharePoint:SPLinkButton>
            </div>

            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li class="<%= newsMeeting%>">
                            <SharePoint:SPLinkButton NavigateUrl="~site/shareholders-meeting.aspx?category=dai-hoi-co-dong" runat="server" CssClass="current">
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,ShareholdersMeeting%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li class="<%= otherMeeting%>">
                            <SharePoint:SPLinkButton NavigateUrl="~site/shareholders-meeting.aspx?category=tin-tuc-khac" runat="server" CssClass="current">
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,OtherNews%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlDocumentPartner%>' runat="server" CssClass="current">
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,DocumentPartner%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                    </ul>
                </div>
                <div class="colright">

                    <!-- ===== STARTER: Main Placeholder gets replaced with content of the page ======================================= -->

                    <div class="row">
                        <asp:Repeater ID="rpShareholder" runat="server">
                            <ItemTemplate>
                                <div class="col-md-4 col-sm-6 col-xs-12 col-new">
                                    <div class="news-item">
                                        <a href="<%#Eval("Url") %>">
                                            <img alt="" src="<%#Eval("Image")%>" />
                                        </a>
                                        <p class="date"><%#Eval("Created") %></p>
                                        <h3><a href="<%#Eval("Url") %>"><%#Eval("Title4Home") %> </a></h3>
                                        <p><%#Eval("Description4Home")%></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="paging" runat="server" id="paging">
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
