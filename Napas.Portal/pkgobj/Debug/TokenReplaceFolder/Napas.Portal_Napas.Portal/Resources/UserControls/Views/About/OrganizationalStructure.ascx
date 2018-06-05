<%@ Assembly Name="Napas.Portal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=a18f64d60256f0cd" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrganizationalStructure.ascx.cs" Inherits="Napas.Portal.ControlTemplates.OrganizationalStructure" %>

<section class="intro-banner"></section>
<style type="text/css">
    .DropDownlist {
        min-width: 170px;
    }

    .skin0 {
        position: absolute;
        width: auto;
        border: 2px solid black;
        background-color: menu;
        font-family: Verdana;
        line-height: 20px;
        cursor: default;
        font-size: 14px;
        z-index: 100;
        visibility: hidden;
    }

    .menuitems {
        padding-left: 10px;
        padding-right: 10px;
        font-family: Verdana;
        font-size: 12px;
        color: black;
    }

    .SelectTreeNode {
        color: red;
    }

    .TreeViewClass {
        height: 250px;
        width: 250px;
    }

    .modal {
        position: fixed;
        z-index: 999;
        height: 100%;
        width: 100%;
        margin-left: -225px;
        top: 0;
        background-color: Black;
        filter: alpha(opacity=60);
        opacity: 0.6;
        -moz-opacity: 0.8;
    }

    .center {
        z-index: 1000;
        margin: 300px auto;
        padding: 10px;
        width: 130px;
        background-color: White;
        border-radius: 10px;
        filter: alpha(opacity=100);
        opacity: 1;
        -moz-opacity: 1;
    }
</style>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <sharepoint:splinkbutton runat="server" navigateurl="<%$Resources:napas.resource,Url%>" cssclass="home">
                    <i class="fa fa-home"></i>
                </sharepoint:splinkbutton>
                <sharepoint:splinkbutton runat="server" navigateurl='<%$Resources:napas.resource,AboutUs%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,AboutUs%>" /></sharepoint:splinkbutton>
                <asp:Literal ID="ltCat" runat="server"></asp:Literal>
            </div>
            <div class="cols">
                <div class="colleft">
                </div>
                <div class="colright">
                    <asp:TreeView ID="trvOrganization" runat="server" ExpandDepth="1">
                       <%-- <Nodes>
                            <asp:TreeNode Text="Employees">
                                <asp:TreeNode Text="Bradley" Value="ID-1234" />
                                <asp:TreeNode Text="Whitney" Value="ID-5678" />
                                <asp:TreeNode Text="Barbara" Value="ID-9101" />
                            </asp:TreeNode>
                        </Nodes>--%>
                        <DataBindings>
                            <asp:TreeNodeBinding DataMember="System.Data.DataRowView"
                                    TextField="description" ValueField="Id" />
                            </DataBindings>
                    </asp:TreeView>
                    <!-- ===== STARTER: Main Placeholder gets replaced with content of the page ======================================= -->
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
