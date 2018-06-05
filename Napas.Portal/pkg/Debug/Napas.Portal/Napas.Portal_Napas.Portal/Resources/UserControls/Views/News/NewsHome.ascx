<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsHome.ascx.cs" Inherits="Napas.Portal.ControlTemplates.NewsHome" %>
<%@ Register Src="NewsLeftMenu.ascx" TagName="NewsLeftMenu" TagPrefix="uc1" %>
<section class="intro-banner intro-banner-news"></section>

<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,Url%>" cssclass="home">
                     <i class="fa fa-home"></i>
                 </sharepoint:splinkbutton>
                <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlNews%>'><asp:Literal runat="server" Text="<%$Resources:napas.resource,News%>" /></sharepoint:splinkbutton>
                <span>|</span>
                <asp:Literal ID="ltCat" runat="server"></asp:Literal>
            </div>

            <div class="cols">
                <div class="colleft">
                    <uc1:newsleftmenu id="NewsLeftMenu2" runat="server" />
                </div>
                <div class="colright">

                    <!-- ===== STARTER: Main Placeholder gets replaced with content of the page ======================================= -->

                    <div class="row">
                        <asp:Repeater ID="rpNewsHome" runat="server">
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
                        <a href="#" runat="server" id="previous">
                            <i class="fa fa-angle-left"></i>
                        </a>
                        <asp:Repeater ID="rptPaging" runat="server">
                            <ItemTemplate>
                                <a href="<%#Eval("Url") %>" class="<%#Eval("strClass") %>">
                                    <%#Eval("text")%>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                        <a href="#" runat ="server" id="next">
                            <i class="fa fa-angle-right"></i>
                        </a>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
