<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactInfor.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ContactInfor" %>
<section class="intro-banner intro-banner-ns"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="middle-inner middle-inner-information-contact">
            <div class="container">
            <div class="sitemap">
                <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,Url%>" cssclass="home">
                     <i class="fa fa-home"></i>
                 </sharepoint:splinkbutton>
                <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlCareer%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Career%>" />
                </sharepoint:splinkbutton>
                <span>|</span>
                <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlContactInfor%>' cssclass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,ContactInfor%>" />
                </sharepoint:splinkbutton>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlCareer%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,CareerPage%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li>
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlHR%>'>
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,HR%>" />
                            </sharepoint:splinkbutton>
                        </li>
                        <li class="active">
                            <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,UrlContactInfor%>'>
                                <i class="fa fa-angle-right"></i><asp:Literal runat="server" Text="<%$Resources:napas.resource,ContactInfor%>" />
                            </sharepoint:splinkbutton>
                        </li>
                    </ul>
                </div>
                <div class="colright">
                    <asp:Repeater ID="rptContact" runat="server">
                            <ItemTemplate>
                                    <div class="information-contact">
                                        <img alt="" src="<%#Eval("Image")%>" />
                                        <div class="box">
                                            <p class="title"><%#Eval("Title")%></p>
                                            <h1><%#Eval("ContactUsr")%></h1>
                                            <p><i class="fa fa-phone" aria-hidden="true"></i>&nbsp;<a href="<%#Eval("TelPhone")%>"> <%#Eval("Phone")%> </a> – ext <%#Eval("PhoneExt")%></p>
                                            <p><i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;<a href="<%#Eval("MailtoEmail")%>"><%#Eval("Email")%></a></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                        </asp:Repeater>
                </div>
            </div>
                </div>
            <div class="clearfix"></div>
        </div>
    </div>
</section>
