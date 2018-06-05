<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Napas.Portal.ControlTemplates.Footer" %>
<footer class="footer">
    <div class="container">
        <div class="row">
            <div class="col-md-2 col-sm-2 col-xs-12">
                <div class="logo-footer">
                    <SharePoint:SPLinkButton NavigateUrl='<%$Resources:napas.resource,Url%>' runat="server">
                        <SharePoint:SiteLogoImage ID="SiteLogoImage92" LogoImageUrl="&lt;% $SPUrl:~sitecollection/_catalogs/masterpage/napas_theme/images/logo_white.png %&gt;" runat="server" Style="width: 100%; max-width: 180px" />
                    </SharePoint:SPLinkButton>
                </div>
            </div>

            <div class="col-md-9 col-md-offset-1 col-sm-8 col-xs-12">                
                <div class="company">
                    <h2>
                        <asp:Literal runat="server" ID="ltCompanyName" Text="<%$Resources:napas.resource,CompanyName%>" />
                    </h2>
                    <p>
                        <asp:Literal runat="server" ID="ltCompanyNationalName" Text="<%$Resources:napas.resource,CompanyNameEnglish%>" />
                    </p>
                </div>                
                <div class="social">
                    <SharePoint:SPLinkButton ID="lbtFaceBook" Target="_blank" runat="server">
                        <i class="fa fa-facebook-square"></i>
                    </SharePoint:SPLinkButton>
                    <SharePoint:SPLinkButton ID="lbtYoutube" Target="_blank" runat="server">
                        <i class="fa fa-youtube-square"></i>
                    </SharePoint:SPLinkButton>
                    <SharePoint:SPLinkButton ID="lbtEmail" runat="server">
                        <i class="fa fa-envelope-square"></i>
                    </SharePoint:SPLinkButton>

                </div>
            </div>
        </div>
    </div>
</footer>
<div class="backtotop" style="display: block !important">
    <a href="#">
        <img src="/_catalogs/masterpage/napas_theme/images/backtotop.png" /></a>
</div>
<div class="backtodesktop" style="display: block !important">
    <a href="#" onclick="BackToDesktop()" style="display: block !important">
        <img src="/_catalogs/masterpage/napas_theme/images/backto-desktop.png" /></a>
</div>
<script>
    $(document).ready(function () {
        
        if (document.documentElement.clientWidth <= 1024) {
            
            var viewState = localStorage.getItem("viewState");
        
            if (viewState == "Desktop") {
                document.querySelector("meta[name=viewport]").setAttribute('content', 'width=1024, initial-scale=-1');
            }
            else {
                document.querySelector("meta[name=viewport]").setAttribute('content', 'width=device-width, initial-scale=1');
            }

            $(".backtodesktop").show()

        }
        else {
            $(".backtodesktop").hide();
            document.querySelector("meta[name=viewport]").setAttribute('content', 'width=device-width, initial-scale=1');          
            
        }

        setTimeout(function () {
            var divLPositionLeft = $("#divL").position().left;
            var divRPositionRight = $("#divVideo").position().left;            
            if (divLPositionLeft != divRPositionRight) {
                var heightL = $("#divL").height();
                $("#divVideo").height(heightL - 20);
            }
            else
            {
                $("#divVideo").height("100%");
            }

        }, 300);
    });

    function BackToDesktop() {
        var viewState = localStorage.getItem("viewState");
        if (viewState == "Mobile") {
            localStorage.setItem("viewState", "Desktop");
            document.querySelector("meta[name=viewport]").setAttribute('content', 'width=1024, initial-scale=-1');
        }
        else {
            localStorage.setItem("viewState", "Mobile");
            document.querySelector("meta[name=viewport]").setAttribute('content', 'width=device-width, initial-scale=1');
        }

        location.reload();
    }
</script>
