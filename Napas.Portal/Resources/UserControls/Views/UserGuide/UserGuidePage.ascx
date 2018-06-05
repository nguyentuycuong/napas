<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register Src="UserGuideLeftMenu.ascx" TagPrefix="uc1" TagName="UserGuideLeftMenu" %>




<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserGuidePage.ascx.cs" Inherits="Napas.Portal.ControlTemplates.UserGuidePage" %>

<section class="intro-banner intro-banner-service"></section>
<!--middle-->
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlUserGuide%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,UserGuide%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <a>
                    <asp:Literal runat="server" ID="ltProductServiceGroup"></asp:Literal>
                </a>
                <span>|</span>
                <a>
                    <asp:Literal runat="server" ID="ltProductServices"></asp:Literal>
                </a>
                
            </div>

            <div class="cols">
                <div class="colleft">
                    <uc1:UserGuideLeftMenu runat="server" id="UserGuideLeftMenu" />
                </div>
                <div class="colright">
                    <div class="service247">
                        <h2>
                            <asp:Literal runat="server" ID="ltServiceName"></asp:Literal></h2>
                        
                            <asp:Literal runat="server" ID="ltContent"></asp:Literal>
                        

                        <%--<div runat="server" id="divCollectionPayment" visible="False">

                            <h5 class="text-center">Viễn Thông</h5>
                            <div class="slider-bank">
                                <div class="owl-carousel owl-bank">
                                    <div>
                                        <div class="bank-slide">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rpTelecommunication">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a data-toggle="modal" data-target='#modal-info-bank<%#Eval("Id") %>'><%#Eval("Title") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <h5 class="text-center">Internet - ADSL</h5>
                            <div class="slider-bank">
                                <div class="owl-carousel owl-bank">
                                    <div>
                                        <div class="bank-slide">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rpInternetADSL">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a data-toggle="modal" data-target='#modal-info-bank<%#Eval("Id") %>'><%#Eval("Title") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <h5 class="text-center">Tài Chính</h5>
                            <div class="slider-bank">
                                <div class="owl-carousel owl-bank">
                                    <div>
                                        <div class="bank-slide">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rpFinance">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a data-toggle="modal" data-target='#modal-info-bank<%#Eval("Id") %>'><%#Eval("Title") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <h5 class="text-center">Truyền Hình</h5>
                            <div class="slider-bank">
                                <div class="owl-carousel owl-bank">
                                    <div>
                                        <div class="bank-slide">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rpTelevision">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a data-toggle="modal" data-target='#modal-info-bank<%#Eval("Id") %>'><%#Eval("Title") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <h5 class="text-center">Bảo hiểm</h5>
                            <div class="slider-bank">
                                <div class="owl-carousel owl-bank">
                                    <div>
                                        <div class="bank-slide">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rpInsurrance">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a data-toggle="modal" data-target='#modal-info-bank<%#Eval("Id") %>'><%#Eval("Title") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <h5 class="text-center">Phương tiện vận chuyển</h5>
                            <div class="slider-bank">
                                <div class="owl-carousel owl-bank">
                                    <div>
                                        <div class="bank-slide">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rpTransportation">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a data-toggle="modal" data-target='#modal-info-bank<%#Eval("Id") %>'><%#Eval("Title") %></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <asp:Repeater runat="server" ID="rpAll">
                                <ItemTemplate>
                                    <div class="modal my-modal my-modal-bank fade" id='modal-info-bank<%#Eval("Id") %>' tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                                        <div class="modal-dialog">
                                            <div class="modal-wrap">
                                                <span class="close-modal" data-dismiss="modal" aria-label="Close"></span>
                                                <div class="bank-modal">
                                                    <div class="bank-modal-item">
                                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/s11_icon.png" />

                                                        <h3>Dịch vụ triển khai</h3>
                                                        <p><i class="fa fa-angle-right"></i><%#Eval("DeploymentServices") %></p>
                                                    </div>
                                                    <div class="bank-modal-item">
                                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/s12_icon.png" />
                                                        <h3>Mã khách hàng</h3>
                                                        <p><i class="fa fa-angle-right"></i><%#Eval("CustomerCode") %></p>
                                                    </div>
                                                    <div class="bank-modal-item">
                                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/s13_icon.png" />
                                                        <h3>Mệnh giá nạp thẻ/số tiền thanh toán</h3>

                                                        <p><i class="fa fa-angle-right"></i><%#Eval("FaceValueOfTheChar") %> </p>
                                                    </div>
                                                    <div class="bank-modal-item">
                                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/s12_icon.png" />
                                                        <h3>Thông tin cần lưu ý khi sửa dụng dịch vụ</h3>
                                                        <p><i class="fa fa-angle-right"></i><%#Eval("InformationNote") %></p>
                                                    </div>
                                                    <div class="bank-modal-item no-border">
                                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/s12_icon.png" />
                                                        <h3>
                                                            <a href='<%#Eval("PartnerWebsite") %>' target="_blank">Hướng dẫn sửa dụng trên website đơn vị
                                                            </a>
                                                        </h3>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>--%>
                    </div>

                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>


