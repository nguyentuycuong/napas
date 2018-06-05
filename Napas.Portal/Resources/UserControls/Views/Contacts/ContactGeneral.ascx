<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactGeneral.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ContactGeneral" %>
<section class="intro-banner intro-banner-hotline"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <a href="#"><asp:Literal runat="server" Text="<%$Resources:napas.resource,Contact%>" /></a>
                <span>|</span>
                <a href="#" class="current">
                    <asp:Literal runat="server" ID="ltContact"></asp:Literal>
                </a>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <asp:Repeater runat="server" ID="rpContact">
                            <ItemTemplate>
                                <li class='<%#Eval("active") %>'>
                                    <a href='<%#Eval("Url") %>'><i class="fa fa-angle-right"></i><%#Eval("Title") %></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="colright">
                    <div class="lh">
                        <div class="left">

                            <asp:Literal runat="server" ID="ltContent"></asp:Literal>

                        </div>
                        <div class="right">
                            <form method="" action="">
                                <div class="form-group">
                                    <label><asp:Literal runat="server" Text="<%$Resources:napas.resource,FullName%>" /></label>
                                    <asp:TextBox class="form-control" type="text" name="contact_name" runat="server" ID="txtName" required></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label><asp:Literal runat="server" Text="<%$Resources:napas.resource,Mobile%>" /></label>
                                    <asp:TextBox TextMode="Phone" class="form-control" type="text" name="contact_phone" runat="server" ID="txtPhone" required></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox TextMode="Email" class="form-control" type="text" name="contact_email" runat="server" ID="txtEmail" required></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label><asp:Literal runat="server" Text="<%$Resources:napas.resource,Title%>" /></label>
                                    <asp:TextBox class="form-control" type="text" name="contact_title" runat="server" ID="txtSubject" required></asp:TextBox>
                                     
                                </div>
                                <div class="form-group">
                                    <label><asp:Literal runat="server" Text="<%$Resources:napas.resource,Content%>" /></label>
                                    <asp:TextBox TextMode="MultiLine" class="form-control" Rows="3" name="contact_content" runat="server" ID="txtContent" required>                                                    
                                    </asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <asp:Literal runat="server" ID="ltMessage"></asp:Literal>
                                    <asp:Button runat="server" ID="btnSubmit" Text="Gửi" CssClass="btn-submit" OnClick="btnSubmit_OnClick"/>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</section>
<script>
    document.addEventListener("DOMContentLoaded", function () {
        var elements = document.getElementsByTagName("INPUT");
        for (var i = 0; i < elements.length; i++) {
            elements[i].oninvalid = function (e) {
                e.target.setCustomValidity("");
                if (!e.target.validity.valid) {
                    e.target.setCustomValidity("Trường này không thể để trống");
                }
            };
            elements[i].oninput = function (e) {
                e.target.setCustomValidity("");
            };
        }
    })
    //function modelDialog() {
    //    var siteCollectionURL = SP.ClientContext.get_current().get_url();
    //    var url = '/_layouts/15/NSRP.CDMS.WebParts/ComingSoon.aspx/?{StandardTokens}&amp;Source={Source}&amp;ListURLDir={ListUrlDir}&amp;listId={ListId}&amp;SelectedItem={SelectedItemId}';
    //    if (siteCollectionURL.length > 1)
    //        url = siteCollectionURL + url;
    //    var NewPopUp = SP.UI.$create_DialogOptions();
    //    NewPopUp.url = url;
    //    NewPopUp.width = 900;
    //    NewPopUp.height = 400;
    //    SP.UI.ModalDialog.showModalDialog(NewPopUp);
    //}
</script>
