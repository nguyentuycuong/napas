<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>

<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Milestones.ascx.cs" Inherits="Napas.Portal.ControlTemplates.Milestones" %>

<section class="intro-banner"></section>

<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlAbout%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,AboutUs%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <a class="current">
                    <asp:Literal ID="ltCat" runat="server"></asp:Literal></a>

            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <asp:Repeater runat="server" ID="rpAbout">
                            <ItemTemplate>
                                <li class='<%#Eval("Active") %>'>
                                    <a href='<%#Eval("Url") %>'>
                                        <i class="fa fa-angle-right"></i>
                                        <%#Eval("Title") %>
                                    </a>

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li>
                            <a href="#">
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Organization%>" />
                            </a>
                            <ul class="lv2">
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlOrganizationChart%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,OrganizationChart%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlGeneralAssembly%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,GeneralAssembly%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlExecutiveBoard%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,ExecutiveBoard%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                                <li>
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,UrlExecutiveCommittee%>">
                                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,ExecutiveCommittee%>" />
                                    </SharePoint:SPLinkButton>
                                </li>
                            </ul>
                        </li>
                        <li class="active">
                            <SharePoint:SPLinkButton runat="server" NavigateUrl="~site/milestones.aspx">
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,MilestonesAchievements%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                    </ul>
                </div>
                <div class="colright" style="text-align: justify">
                    <div class="about-history">
                        <div class="panel-group" id="accordion">
                            <asp:Repeater runat="server" ID="rpMilestones">
                                <ItemTemplate>
                                    <% if (iCounter == 1)
                                       { %>
                                    <div class="panel panel-default panel-item">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <!--note cái đầu tiên không có class  collapsed-->
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse<%#Eval("ID") %>">
                                                    <span><%#Eval("Year") %></span><span><img src="/_catalogs/masterpage/napas_theme/images/about-history-icon.png" /><%#Eval("Title") %></span>
                                                </a>
                                            </h4>
                                        </div>
                                        <div id="collapse<%#Eval("ID") %>" class="panel-collapse collapse in">
                                            <div class="panel-body">
                                                <%#Eval("Content") %>
                                            </div>
                                        </div>
                                    </div>
                                    <% }
                                       else
                                       { %>
                                    <br />
                                    <div class="panel panel-default panel-item">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <!--note cái đầu tiên không có class  collapsed-->
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse<%#Eval("ID") %>" class="collapsed">
                                                    <span><%#Eval("Year") %></span><span><img src="/_catalogs/masterpage/napas_theme/images/about-history-icon.png" /><%#Eval("Title") %></span>
                                                </a>
                                            </h4>
                                        </div>
                                        <div id="collapse<%#Eval("ID") %>" class="panel-collapse collapse">
                                            <div class="panel-body">
                                                <%#Eval("Content") %>
                                            </div>
                                        </div>
                                    </div>
                                    <% }
                                       iCounter++;
                                    %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
