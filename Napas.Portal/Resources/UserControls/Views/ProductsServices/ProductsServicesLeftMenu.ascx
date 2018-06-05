<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductsServicesLeftMenu.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ProductsServicesLeftMenu" %>
<ul id="menu" class="menuleft">

    <asp:Repeater ID="ParentRepeater" runat="server" OnItemDataBound="ItemBound">
        <ItemTemplate>
            <li class='<%#Eval("CatIDActive") %>'>
                <a href="#">
                    <i class="fa fa-angle-right"></i><%#Eval("Title") %>
                </a>
                <ul class="lv2">
                    <asp:HiddenField ID="hfParentId" runat="server" Value='<%#Eval("Id") %>' />
                    <asp:Repeater ID="ChildRepeater" runat="server" OnItemDataBound="ChildRepeater_OnItemDataBound">
                        <ItemTemplate>
                            <li class='<%#Eval("CurrentProductService") %>'>
                                <a href='<%#Eval("Url") %>'>
                                    <i class="fa fa-angle-right"></i><%#Eval("Title") %>
                                </a>
                                <ul class="lv3" runat="server" id="ulChilrent">
                                    <asp:HiddenField ID="hfLevel1Id" runat="server" Value='<%#Eval("Id") %>' />
                                    <asp:HiddenField runat="server" ID="hfHaveSubService" Value='<%#Eval("haveSubService") %>' />
                                    <asp:Repeater runat="server" ID="subRepeater">
                                        <ItemTemplate>
                                            <li class='<%#Eval("CurrentProductService") %>'><a href='<%#Eval("Url") %>'><i class="fa fa-angle-right"></i><%#Eval("Title") %></a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
        </ItemTemplate>
    </asp:Repeater>

</ul>
