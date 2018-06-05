<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTop.ascx.cs" Inherits="Napas.Portal.ControlTemplates.MenuTop" %>

<asp:Literal runat="server" ID="ltStyle"></asp:Literal>
<!-- header-->
<header class="header">
    <div class="container">
        <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,Url%>' runat="server" CssClass="logo">
            <asp:Literal runat="server" ID="ltLogo"></asp:Literal>
        </SharePoint:SPLinkButton>
        <div class="header-right">
            <ul class="menu-top list-inline">
                <li class="hotline">
                    <asp:Literal runat="server" ID="ltMobile"></asp:Literal>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlDocumentLegal%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Documents%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlCareer%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Career%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlTermsAndConditionOfUse%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,TermsAndConditionOfUse%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlContact%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Hotline%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
            </ul>
        </div>
    </div>

    <%--Menu mobile--%>
    <nav class="menu-res hidden-lg hidden-md ">
        <div class="menu-res-inner">
            <ul>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlAbout%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,AboutUs%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlNews%>'>
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,News%>" /><span></span><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li class="menu-item-has-children">
                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlBankFinace%>'>
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,ForCustomers%>" /><span></span><span></span>
                    </SharePoint:SPLinkButton>
                    <ul class="sub-menu">
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlBankFinace%>'>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,BankFinace%>" /><span></span><span></span>
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlBusinessesServiceProviders%>'>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,BusinessesServiceProviders%>" /><span></span><span></span>
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlIndividualCustomers%>'>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,IndividualCustomers%>" /><span></span><span></span>
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlIntermediaryPaymentCompany%>'>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,IntermediaryPaymentCompany%>" /><span></span><span></span>
                            </SharePoint:SPLinkButton>
                        </li>

                    </ul>
                </li>
                <li class="menu-item-has-children">
                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPartners%>'>
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,ForPartners%>" /><span></span><span></span>
                    </SharePoint:SPLinkButton>
                    <ul class="sub-menu">

                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlShareholderMeeting%>'>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,ShareholdersMeeting%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlDocumentPartner%>'>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,DocumentPartner%>" />
                            </SharePoint:SPLinkButton>
                        </li>

                    </ul>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlDocumentLegal%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Documents%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlCareer%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Career%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlTermsAndConditionOfUse%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,TermsAndConditionOfUse%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>
                <li>
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlContact%>' runat="server">
                        <asp:Literal runat="server" Text="<%$Resources:napas.resource,Hotline%>" /><span></span>
                    </SharePoint:SPLinkButton>
                </li>


            </ul>
        </div>
    </nav>
</header>
<!--menu-->
<nav class="menu ">
    <div class="container">
        <div class="menu-icon hidden-lg hidden-md">
            <!--<i class="fa fa-navicon"></i>-->
            <ul class="list-inline">
                <li class="hotline">
                    <asp:Literal runat="server" ID="ltMobile2"></asp:Literal>
                </li>
                <li class="search">
                    <a href="" class="search-form" onclick="setTimeout(btnSearchFormM_Click,1000)">
                        <i class="fa fa-search"></i>
                    </a>
                    <div class="form">
                        <form>
                            <input type="text" placeholder="" id="txtKeyM" />
                            <button type="button" onclick="searchM()"><i class="fa fa-search"></i></button>
                        </form>
                    </div>
                </li>
                <li class="language">
                     <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,LanguageUrl%>' runat="server">
                        <asp:Image runat="server" id="Image2"  ImageUrl="<%$Resources:napas.resource,Flag%>" />
                    </SharePoint:SPLinkButton>
                </li>
                <li class="favicon"><a href="">
                    <img src="/_catalogs/masterpage/napas_theme/images/favicon.png" /></a></li>
            </ul>
            <!--<span>MENU</span>-->
        </div>
        <ul class="hidden-sm hidden-xs">
            <li>
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,Url%>' runat="server">
                    <i class="fa fa-home"></i><span></span>
                </SharePoint:SPLinkButton>

            </li>
            <li>
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,UrlAbout%>' runat="server">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,AboutUs%>" /><span></span>
                </SharePoint:SPLinkButton>
            </li>
            <li>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlNews%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,News%>" /><span></span><span></span>
                </SharePoint:SPLinkButton>
            </li>

            <li>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlBankFinace%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,ForCustomers%>" /><span></span><span></span>
                </SharePoint:SPLinkButton>
                <div class="mega-menu">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlBankFinace%>'>
                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/m_icon3.png" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,BankFinace%>" /></h4>
                                    </SharePoint:SPLinkButton>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">

                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlBusinessesServiceProviders%>'>
                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/m_icon4.png" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,BusinessesServiceProviders%>" /></h4>
                                    </SharePoint:SPLinkButton>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">

                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlIndividualCustomers%>'>
                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/m_icon5.png" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,IndividualCustomers%>" /></h4>
                                    </SharePoint:SPLinkButton>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">

                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlIntermediaryPaymentCompany%>'>
                                        <img alt="" src="/_catalogs/masterpage/napas_theme/images/m_icon7.png" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,IntermediaryPaymentCompany%>" /></h4>
                                    </SharePoint:SPLinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </li>
            <li>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPartners%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,ForPartners%>" />
                </SharePoint:SPLinkButton>
                <div class="mega-menu">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlShareholderMeeting%>'>
                                        <SharePoint:SiteLogoImage ID="SiteLogoImage2" LogoImageUrl="&lt;% $SPUrl:~sitecollection/_catalogs/masterpage/napas_theme/images/m_icon1.png %&gt;" runat="server" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,ShareholdersMeeting%>" />
                                        </h4>
                                    </SharePoint:SPLinkButton>

                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='~site/shareholders-meeting.aspx?category=tin-tuc-khac'>
                                        <SharePoint:SiteLogoImage ID="SiteLogoImage1" LogoImageUrl="&lt;% $SPUrl:~sitecollection/_catalogs/masterpage/napas_theme/images/m_icon99.png %&gt;" runat="server" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,OtherNews%>" />
                                        </h4>
                                    </SharePoint:SPLinkButton>

                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <div class="sub-item">
                                    <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlDocumentPartner%>'>
                                        <SharePoint:SiteLogoImage ID="SiteLogoImage3" LogoImageUrl="&lt;% $SPUrl:~sitecollection/_catalogs/masterpage/napas_theme/images/m_icon2.png %&gt;" runat="server" />
                                        <h4>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,DocumentPartner%>" />
                                        </h4>
                                    </SharePoint:SPLinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </li>
            <li class="search">
                <a href="" class="search-form" onclick="setTimeout(btnSearchForm_Click, 1000)">
                    <i class="fa fa-search"></i>
                </a>
                <div class="form">
                    <form>
                        <input type="text" placeholder="" id="txtKey" />
                        <button type="button" onclick="search()" id="btSearch"><i class="fa fa-search"></i></button>
                    </form>
                </div>
            </li>
            <li class="language">                
                <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,LanguageUrl%>' runat="server">
                        <asp:Image runat="server" id="Image1"  ImageUrl="<%$Resources:napas.resource,Flag%>" />
                    </SharePoint:SPLinkButton>
            </li>
        </ul>

    </div>
</nav>


<script>
    $("#txtKey").keyup(function (event) {
        if (event.keyCode == 13) {
            $("#btSearch").click();
        }
    });

    function search() {
        var key = $("#txtKey").val();
        var url = _spPageContextInfo.webAbsoluteUrl + "/search.aspx?k=" + key;
        window.location = url;        
    }

    function searchM() {
        var key = $("#txtKeyM").val();
        var url = _spPageContextInfo.webAbsoluteUrl + "/search.aspx?k=" + key;
        window.location = url
    }

    function btnSearchForm_Click()
    {
        $("#txtKey").focus();
    }

    function btnSearchFormM_Click() {
        $("#txtKeyM").focus();
    }
</script>
