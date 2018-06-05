<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>


<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsServicesInformation.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ProductsServicesInformation" %>

<asp:Literal runat="server" ID="ltProductserviceName" Visible="False"></asp:Literal>

<div class="customer" style="text-align: justify">
    <asp:Literal runat="server" ID="ltContent"></asp:Literal>

    <div class="excerpt">
        <asp:Repeater ID="rpBanks" runat="server">
            <HeaderTemplate>
                <ul class="list-image">
            </HeaderTemplate>
                    <ItemTemplate>
                <li>
                    <a href="<%#Eval("Website")%>" target="_blank">
                        <img alt="" src="<%# Eval("Image")%>" />
                    </a>
                </li>
                    </ItemTemplate>
            <FooterTemplate>
            </ul>
            </FooterTemplate>
        </asp:Repeater>
            <div class="clearfix"></div>

        <asp:Literal runat="server" ID="ltContent2"></asp:Literal>

        <asp:Repeater ID="rpBanks2" runat="server">
            <HeaderTemplate>
                <ul class="list-image">
            </HeaderTemplate>
                    <ItemTemplate>
                <li>
                    <a href="<%#Eval("Website")%>" target="_blank">
                        <img alt="" src="<%# Eval("Image") %>" />
                    </a>
                </li>
                    </ItemTemplate>
            <FooterTemplate>
                </ul>            
            </FooterTemplate>
                </asp:Repeater>

            <div class="clearfix"></div>

        <asp:Literal runat="server" ID="ltContent3"></asp:Literal>

        <asp:Repeater ID="rpBanks3" runat="server">
            <HeaderTemplate>
                <ul class="list-image">
            </HeaderTemplate>
                    <ItemTemplate>
                <li>
                    <a href="<%#Eval("Website")%>" target="_blank">
                        <img alt="" src="<%# Eval("Image") %>" />
                    </a>
                </li>
                    </ItemTemplate>
            <FooterTemplate>
                </ul>            
            </FooterTemplate>
                </asp:Repeater>

            <div class="clearfix"></div>
        <asp:Literal runat="server" ID="ltContent4"></asp:Literal>

        <div runat="server" id="divVenders">

            <asp:Repeater ID="rpTranformer" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Vận tải – Hàng không</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

            <asp:Repeater ID="rpRetail" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Bán lẻ</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

            <asp:Repeater ID="rpCommunication" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Viễn thông</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href="<%#Eval("Website")%>" target="_blank">
                        <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>
            <asp:Repeater ID="rpEnsurance" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Bảo hiểm</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

            <asp:Repeater ID="rpGame" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Game</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

            <asp:Repeater ID="rpDigital" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Nội dung số</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

            <asp:Repeater ID="rpElectronicWallet" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Ví điện tử - Tiện ích</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

            <asp:Repeater ID="rpOthers" runat="server">
                <HeaderTemplate>
                    <h3 class="title title-center">Giải trí – Du lịch – Tiêu dùng – khác</h3>
                    <ul class="list-image">
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="<%#Eval("Website")%>" target="_blank">
                            <img alt="" src="<%# Eval("Image") %>" />
                        </a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>            
                </FooterTemplate>
            </asp:Repeater>

            <div class="clearfix"></div>

        </div>
        <asp:Literal runat="server" ID="ltNote"></asp:Literal>


    </div>
</div>

