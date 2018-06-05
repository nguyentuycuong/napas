<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="Napas.Portal.ControlTemplates.Home" %>
<!--slider-->
<style>
    @media screen and (max-width: 4096px) {
        #divVideo {
            height: 426px;
            background-color: white;
            padding: 0px;
        }

        #ifram {
            height: 300px;
        }
    }

    @media screen and (max-width: 1366px) {
        #divVideo {
            height: 426px;
            background-color: white;
            padding: 0px;
        }

        #ifram {
            height: 330px;
        }
    }

    @media screen and (max-width: 1200px) {
        #divVideo {
            height: 352px;
        }

        #ifram {
            height: 273px;
        }
    }

    @media screen and (max-width: 992px) {
        #divVideo {
            height: 500px;
        }

        #ifram {
            height: 422px;
        }
    }

    @media screen and (max-width: 667px) {
        #divVideo {
            height: 330px;
        }

        #ifram {
            height: 365px;
        }

        /*.news-small-img {
            height: 200px !important;
        }*/
    }
     @media screen and (max-width: 568px) {        
        #ifram {
            height: 320px;
        }      
    }

      @media screen and (max-width: 414px) {        
        #ifram {
            height: 233px;
        }      
    }

      @media screen and (max-width: 375px) {        
        #ifram {
            height: 210px;
        }      
    }

    @media screen and (max-width: 320px) {        
        #ifram {
            height: 180px;
        }      
    }
</style>
<asp:Literal runat="server" ID="ltStyle"></asp:Literal>
<section class="home-slider">
    <ul class="bxslider">
        <asp:Repeater runat="server" ID="rpSlider" Visible="True">
            <ItemTemplate>
                <li style='background-image: url(<%#Eval("Image1366") %>)' class='slider0<%#Eval("Index") %>' data-url="<%#Eval("Url") %>">
                    <img src="<%#Eval("Image480") %>" />
                    <div class="container">
                        <div class="slider-item">
                            <a href="<%#Eval("Url") %>" class="slider-item-button button-<%#(string) Eval("Index") == "2" ? "right" : "left"%>">
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,viewmore%>" />
                            </a>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</section>

<section class="middle">
    <div class="middle-inner">
        <div class="container">

            <div class="news-box">
                <h2>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,HotNews%>" />
                </h2>
            </div>

            <div class="row">
                <div class="col-md-6 col-sm-12 col-xs-12" id="divL">
                    <asp:Repeater runat="server" ID="rpNewsHome">
                        <ItemTemplate>
                            <div class="news-small">
                                <div class="news-small-img" style="background-image: url('<%#Eval("Image") %>');">
                                    <a href="<%#Eval("Url") %>">
                                        <em class="date">
                                            <%#Eval("CreatedHome") %>
                                        </em>
                                        <img alt="" src="<%#Eval("Image") %>" style="max-height:250px" />
                                    </a>
                                </div>
                                <span><%#Eval("Category") %></span>

                                <h3><a href="<%#Eval("Url") %>"><%#Eval("Title4Home") %></a></h3>
                                <p><%#Eval("Description4Home") %></p>
                                <div class="clearfix"></div>
                            </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <div class="news-small news-small-right">
                                <div class="news-small-img" style="background-image: url('<%#Eval("Image") %>');">
                                    <a href="<%#Eval("Url") %>">
                                        <em class="date">
                                            <%#Eval("CreatedHome") %>
                                        </em>
                                        <img alt="" src="<%#Eval("Image") %>" style="max-height:250px" />
                                    </a>
                                </div>
                                <span><%#Eval("Category") %></span>

                                <h3>
                                    <a href="<%#Eval("Url") %>"><%#Eval("Title4Home") %>
                                    </a>
                                </h3>
                                <p><%#Eval("Description4Home") %></p>
                                <div class="clearfix"></div>
                            </div>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-6 col-sm-12 col-xs-12" id="divVideo">
                    <div class="news-big ">
                        <div class="news-small-img">
                            <asp:Literal runat="server" ID="ltVideoSource"></asp:Literal>
                        </div>                        
                        <h3>
                            <a>
                                <asp:Literal runat="server" ID="ltVideoDescription"></asp:Literal>
                            </a>
                        </h3>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--middle-->

