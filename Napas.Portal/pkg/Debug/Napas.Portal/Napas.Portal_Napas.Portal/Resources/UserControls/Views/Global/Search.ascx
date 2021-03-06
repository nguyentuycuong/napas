﻿<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="Napas.Portal.ControlTemplates.Search" %>

<!--intro-banner-->
<section class="intro-banner intro-banner-tl"></section>
<!--middle-->
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <a href="#" class="home">
                    <i class="fa fa-home"></i>
                </a>
                <a href="#">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,Search%>" />
                    </a>

            </div>
            <div class="page-30-06-search">
                <ul class="list-item">
                    <asp:Repeater runat="server" ID="rpResult">
                        <ItemTemplate>
                             <li class="item">
                                <div class="image">
                                    <a href="/<%#Eval("CustomeURL") %>">
                                        <%--<img src="/PublishingImages/logo.png" />--%>
                                        <img src="<%#Eval("ImageUrl").ToString().Replace("http://np-web", "") %>" />                                        
                                    </a>
                                </div>
                                <div class="text">
                                    <h3><a href="/<%#Eval("CustomeURL") %>"><%#Eval("Title") %></a> </h3>
                                    <div class="excerpt">
                                        <%#Eval("HitHighlightedSummary") %>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="paging">
                        <table style="width: 600px;">
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lbFirst" runat="server" OnClick="lbFirst_Click" BackColor="#f0f0f0" Width="80px">First</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbPrevious" runat="server" OnClick="lbPrevious_Click" BackColor="#f0f0f0" Width="80px">Previous</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:DataList ID="rptPaging" runat="server"
                                        OnItemCommand="rptPaging_ItemCommand"
                                        OnItemDataBound="rptPaging_ItemDataBound" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbPaging" runat="server"
                                                CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage"
                                                Text='<%# Eval("PageText") %> ' Width="20px" BackColor="#f0f0f0"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbNext" runat="server" OnClick="lbNext_Click" BackColor="#f0f0f0" Width="80px">Next</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbLast" runat="server" OnClick="lbLast_Click" BackColor="#f0f0f0" Width="80px">Last</asp:LinkButton>
                                </td>
                                <td>
                                    <asp:Label ID="lblpage" runat="server" Text="" Width="80px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
        </div>
    </div>
</section>


