<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CVDocument.ascx.cs" Inherits="Napas.Portal.ControlTemplates.CVDocument" %>
<section class="intro-banner intro-banner-ns"></section>
<section class="middle">
    <div class="middle-inner middle-inner-information-contact">
        <div class="container">
            <div class="sitemap">
                <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,Url%>" cssclass="home">
                     <i class="fa fa-home"></i>
                 </sharepoint:splinkbutton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlCareer%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Career%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlCVDocument%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,CVDocument%>" />
                </SharePoint:SPLinkButton>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li class="active">
                            <a href="#">
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerPage%>" />
                            </a>
                            <ul class="lv2">                                
                                    <li >
                                        <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,UrlCareerInfor%>">
                                             <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerInfor%>" />
                                         </sharepoint:splinkbutton>
                                    </li>
                                    <li >
                                        <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,UrlCareerResult%>">
                                             <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerResult%>" />
                                         </sharepoint:splinkbutton>                                     
                                    </li>
                                    <li class="active">
                                        <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,UrlCVDocument%>">
                                             <asp:Literal runat="server" Text="<%$Resources:napas.resource,CVDocument%>" />
                                         </sharepoint:splinkbutton>   
                                    </li>        
                            </ul>
                        </li>
                        <li >
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlHR%>'>
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,HR%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li >
                             <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlContactInfor%>'>
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,ContactInfor%>" />
                            </SharePoint:SPLinkButton>
                        </li>                        
                    </ul>
                </div>
                <div class="colright">
                    <div class="cd-tl cd-tl-old">
                        <ul class="list-item">
                            <asp:Repeater runat="server" ID="rpCVDocument">
                                <ItemTemplate>
                                    <li class="item">
                                        <div class="bottom">
                                        <div class="image">
                                            <a href='<%#Eval("FileUrl") %>'>
                                                <img src="/_catalogs/masterpage/napas_theme/images/cd-dowload.png"></a>
                                        </div>
                                        <div class="text">
                                            <p class="time"><%#Eval("DocumentDate") %></p>
                                            <h3 class="title">
                                                <%#Eval("Description") %>
                                            </h3>
                                        </div>
                                            </div>
                                        </li>  
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</section>
