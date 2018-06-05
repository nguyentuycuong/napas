<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Src="ProductsServicesLeftMenu.ascx" TagPrefix="uc1" TagName="ProductsServicesLeftMenu" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsServices.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ProductsServices" %>

<section class="intro-banner intro-banner-service"></section>
<!--middle-->
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlProducts-Services%>' CssClass="current">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Products_Services%>" /></SharePoint:SPLinkButton>

            </div>

            <div class="cols1">
                <div class="row">
                        <asp:Repeater runat="server" ID="rpProductsServicesMenuTop">
                            <ItemTemplate>
                                <div class="col-md-3 col-sm-3">
                                    <div class="sub-item">
                                        <a href="<%#Eval("UrlFirstService") %>">
                                           <div style="text-align: center"> <img alt="" src="<%#Eval("MenuIcon") %>" /></div>
                                            <p style="text-align: center"><%#Eval("Title") %>
                                            </p>
                                        </a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                <div class="colright1">
                    

                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
