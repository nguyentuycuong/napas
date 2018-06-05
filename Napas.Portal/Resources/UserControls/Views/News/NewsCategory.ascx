<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCategory.ascx.cs" Inherits="Napas.Portal.ControlTemplates.NewsCategory" %>
<%@ Register Src="NewsLeftMenu.ascx" TagName="NewsLeftMenu" TagPrefix="uc1" %>
<section class="intro-banner intro-banner-news"></section>

<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlNews%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,News%>" /></SharePoint:SPLinkButton>
                <asp:Literal ID="ltCat" runat="server"></asp:Literal>
            </div>
            <div class="cols">
                <div class="colleft">
                    <uc1:NewsLeftMenu ID="NewsLeftMenu2" runat="server" />
                </div>
                <div class="colright">

                    <!-- ===== STARTER: Main Placeholder gets replaced with content of the page ======================================= -->

                    <div class="row">
                        <asp:Repeater ID="rpNewsHome" runat="server">
                            <ItemTemplate>
                                <div class="col-md-4 col-sm-6 col-xs-12 col-new">
                                    <div class="news-item">
                                        <a href="/sites/napas/newsdetails.aspx?ID=<%#Eval("ID") %>">
                                            <img alt="" src="<%# Eval("Thumb").ToString().Split(',')[0] %>" />
                                        </a>
                                        <p class="date"><%#Eval("Created") %></p>
                                        <h3><a href="/sites/napas/newsdetails.aspx?ID=<%#Eval("ID") %>"><%#Eval("Title4Home") %> </a></h3>
                                        <p><%#Eval("Description4Home")%></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
