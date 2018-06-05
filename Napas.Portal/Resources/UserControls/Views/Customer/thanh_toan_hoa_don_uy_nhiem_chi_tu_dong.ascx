<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="thanh_toan_hoa_don_uy_nhiem_chi_tu_dong.ascx.cs" Inherits="Napas.Portal.ControlTemplates.thanh_toan_hoa_don_uy_nhiem_chi_tu_dong" %>
<%@ Register Src="CustomerLeftMenu.ascx" TagName="CustomerLeftMenu" TagPrefix="uc1" %>
<style>
    @media (min-width: 992px) {
        .col-md-4 {
            width: 20%;
        }
    }
</style>

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
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPayBills%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,PayBills%>" />
                </SharePoint:SPLinkButton>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li>
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
                        <li class="active">
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
                    <div class="shopping-online">
                        <h2 class="title"><i class="fa fa-caret-right" aria-hidden="true"></i><asp:Literal runat="server" ID="ltHeader"></asp:Literal></h2>
                        
                        <asp:Literal runat="server" ID="ltContent"></asp:Literal>
                        <h2 class="title title-old"><i class="fa fa-caret-right" aria-hidden="true"></i>Danh sách ngân hàng </h2>

                        <div class="row row-fix-20">
                            <asp:Repeater runat="server" ID="rpBanks">
                                <ItemTemplate>
                                    <div class="col-md-4 col-sm-4 col-xs-6 col-fix-20">
                                        <div class="shopping-logo-item">
                                            <a href='<%#Eval("Website") %>'>
                                                <img alt="" src='<%#Eval("Image") %>' />
                                            </a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        
                        <asp:Literal runat="server" ID="ltNote"></asp:Literal>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>

