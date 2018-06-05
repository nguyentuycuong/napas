<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InteriorCard.ascx.cs" Inherits="Napas.Portal.ControlTemplates.InteriorCard" %>
<%@ Register Src="CustomerLeftMenu.ascx" TagName="CustomerLeftMenu" TagPrefix="uc1" %>
<section class="intro-banner intro-banner-customer"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlAtmPosition%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,CustomerService%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlInteriorCard%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,InteriorCard%>" />
                </SharePoint:SPLinkButton>
            </div>
            <div class="cols">
                <div class="colleft">
                     <ul id="menu" class="menuleft">
                        <li class="active">
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlInteriorCard%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,InteriorCard%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlTranfer247%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Tranfer247%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlShoppingOnline%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,ShoppingOnline%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlTopup%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Topup%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPayBills%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,PayBills%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlAtmPosition%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,AtmPosition%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPromotion%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Promotion%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                    </ul>
                </div>
                <div class="colright">
                    <div class="tnd" style="text-align: justify">
                        <div class="top">
                            <h1 class="heading">
                                <img src="/_catalogs/masterpage/napas_theme/images/thend-icon.png">
                                <asp:Literal runat="server" ID="ltTitle"></asp:Literal>
                            </h1>
                            <p class="excerpt">
                                <asp:Literal runat="server" ID="ltDescription"></asp:Literal>
                            </p>
                        </div>
                        <div class="owl-carousel owl-carousel-tnd" id="owl_carousel_tnd">
                            <asp:Literal runat="server" ID="ltImages"></asp:Literal>
                        </div>
                        <div>
                            <b>
                                <asp:Literal runat="server" ID="ltfeature"></asp:Literal>
                                <br />
                            </b>
                            <p class="excerpt">
                                <asp:Literal runat="server" ID="ltFeatureContent"></asp:Literal>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        var owl = $('#owl_carousel_tnd');
        owl.owlCarousel({
            items: 1,
            loop: false,
            margin: 10,
            autoplay: false,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            pagination: true,
            nav: true
        });
        $(".tnd .owl-carousel-tnd .owl-nav .owl-prev").html("");
        $(".tnd .owl-carousel-tnd .owl-nav .owl-next").html("");
    });
        </script>
