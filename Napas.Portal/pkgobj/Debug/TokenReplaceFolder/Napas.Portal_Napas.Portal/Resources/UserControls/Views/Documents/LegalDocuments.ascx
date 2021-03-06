﻿<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LegalDocuments.ascx.cs" Inherits="Napas.Portal.ControlTemplates.LegalDocuments" %>

<section class="intro-banner intro-banner-tl"></section>

<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,Url%>' runat="server" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlDocumentLegal%>' runat="server">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Documents%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlDocumentLegal%>' runat="server" CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,LegalDocuments%>" />
                </SharePoint:SPLinkButton>
            </div>

            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li class="active">
                            <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlDocumentLegal%>' runat="server" CssClass="current">
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,LegalDocuments%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <asp:Repeater runat="server" ID="rpOtherDocument">
                            <ItemTemplate>
                                 <li class='<%#Eval("Class") %>'>
                                        <%#Eval("Url") %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="colright">

                    <!-- ===== STARTER: Main Placeholder gets replaced with content of the page ======================================= -->

                    <div class="cd-tl">
                        <ul class="list-item">
                            <asp:Repeater runat="server" ID="rpDocumentShareholder" OnItemDataBound="ItemBound">
                                <ItemTemplate>
                                    <li class="item">
                                        <h1 class="heading"><a>
                                            <img src="/_catalogs/masterpage/napas_theme/images/cd-tl-icon.png">
                                            <%#Eval("Title") %>
                                        </a></h1>
                                        <asp:HiddenField runat="server" ID="hfDocumentType" Value='<%#Eval("TypeId") %>' />
                                        <div class="paginate">
                                            <div class="items">
                                                <asp:Repeater runat="server" ID="rpDocumentsItem">
                                                    <ItemTemplate>

                                                        <div class="bottom">
                                                            <div class="image">
                                                                <a href='<%#Eval("FileUrl") %>'>
                                                                    <img src="/_catalogs/masterpage/napas_theme/images/cd-dowload.png"></a>
                                                            </div>
                                                            <div class="text">
                                                                <p class="time"><%#Eval("DocumentDate") %></p>
                                                                <h4 class="title">
                                                                    <%#Eval("Title") %>
                                                                </h4>
                                                            </div>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="paging">
                                                <div class="pageNumbers"></div>
                                            </div>
                                        </div>
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
<script>
    $(function () {
        $(".paginate").paginga({
            // use default options
        });


    });
</script>
