<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TranferBanking247.ascx.cs" Inherits="Napas.Portal.ControlTemplates.TranferBanking247" %>
<%@ Register Src="CustomerLeftMenu.ascx" TagName="CustomerLeftMenu" TagPrefix="uc1" %>
<section class="intro-banner intro-banner-customer"></section>
<style>
    @media (min-width: 992px) {
        .col-md-4 {
            width: 20%;
        }
    }
</style>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,Url%>" cssclass="home">
                    <i class="fa fa-home"></i>
                </sharepoint:splinkbutton>
                <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlAtmPosition%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,CustomerService%>" />
                </sharepoint:splinkbutton>
                <span>|</span>
                <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlTranfer247%>' cssclass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Tranfer247%>" />
                </sharepoint:splinkbutton>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlInteriorCard%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,InteriorCard%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li class="active">
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlTranfer247%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Tranfer247%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlShoppingOnline%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,ShoppingOnline%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlTopup%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Topup%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlPayBills%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,PayBills%>" />
                            </sharepoint:splinkbutton>
                        </li>
                         <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlAtmPosition%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,AtmPosition%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlPromotion%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Promotion%>" />
                            </sharepoint:splinkbutton>
                        </li>
                    </ul>
                </div>
                <div class="colright">
                    <div class="shopping-online">
                        <h2 class="title title-old"><i class="fa fa-caret-right" aria-hidden="true"></i>
                            <asp:literal runat="server" id="ltHeader"></asp:literal>
                        </h2>
                        <asp:literal runat="server" id="ltContent"></asp:literal>
                        <h2 class="title title-old"><i class="fa fa-caret-right" aria-hidden="true"></i>Danh sách các ngân hàng tham gia dịch vụ  </h2>

                        <p><strong>Chuyển khoản liên ngân hàng 24/7 tới số thẻ</strong></p>
                        <div class="row row-fix-20">
                            <asp:repeater runat="server" id="rpTransferNumberCard">
                                <ItemTemplate>
                                    <div class="col-md-4 col-sm-4 col-xs-6 col-fix-20">
                                        <div class="shopping-logo-item">
                                            <a href='<%#Eval("Website") %>'>
                                                <img alt="" src='<%#Eval("Image") %>' />
                                            </a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:repeater>

                        </div>
                        <p><strong>Chuyển khoản liên ngân hàng 24/7 tới số tài khoản</strong></p>
                        <asp:repeater runat="server" id="rpTranferNumberAccount">
                            <ItemTemplate>
                                <div class="col-md-4 col-sm-4 col-xs-6 col-fix-20">
                                    <div class="shopping-logo-item">
                                        <a href='<%#Eval("Website") %>'>
                                            <img alt="" src='<%#Eval("Image") %>' />
                                        </a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:repeater>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>

