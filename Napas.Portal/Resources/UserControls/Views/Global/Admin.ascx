<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Admin.ascx.cs" Inherits="Napas.Portal.ControlTemplates.Admin" %>
<table id="appsTable" cellspacing="0" cellpadding="0" style="border-collapse: collapse;" border="0" class="ms-viewlsts" width="100%">
    <tbody>
        <tr class="ms-vl-sectionHeaderRow">
            <td colspan="3">
                <h1>Trang quản trị/Admin
                </h1>
                <span class="ms-vl-sectionHeader">
                    <h2 class="ms-webpart-titleText">
                        <span>
                        </span>
                    </h2>
                </span>
            </td>
            <td class="ms-alignRight"></td>
        </tr>
        <%--<tr style="display: none">
            <td colspan="4">
                <div id="applist" class="ms-vl-applist">
                    <div class="ms-vl-apptile ms-vl-apptilehover ">
                        <div class="ms-vl-appimage">
                            <a class="ms-storefront-selectanchor ms-storefront-appiconspan ms-draggable" href="/Lists/Tin tc/AllItems.aspx" dragid="53">
                                <img class="ms-storefront-appiconimg" style="border: 0;" alt="Tin tức" src="/_layouts/15/images/ltgen.png?rev=23">
                            </a>
                        </div>
                        <div>
                            <div>
                                <div class="ms-vl-apptitleouter">
                                    <a class="ms-draggable ms-vl-apptitle ms-listLink" href="/Lists/Tin tc/AllItems.aspx" title="Tin tức" dragid="52" draggable="true">Tin tức
                                    </a>
                                </div>
                                <a class="ms-vl-calloutarrow ms-calloutLink ms-ellipsis-a ms-pivotControl-overflowDot js-callout-launchPoint" title="Bấm để biết thêm thông tin." name="Bấm để biết thêm thông tin.">
                                    <img class="ms-ellipsis-icon" src="/_layouts/15/images/spcommon.png?rev=23" alt="Mở Menu" style="visibility: hidden;">
                                </a>
                            </div>

                            <div class="ms-metadata ms-vl-appstatus">
                                Quản lý danh sách tin tức
                            </div>
                        </div>
                    </div>

                    <div id="apptile-ad7d7056-ce4d-43af-9d12-71697de927ee" class="ms-vl-apptile ms-vl-apptilehover " onmouseover="javascript:if (typeof(showCalloutIcon) == 'function'){showCalloutIcon('ad7d7056-ce4d-43af-9d12-71697de927ee');}" onmouseout="if (typeof(hideCalloutIcon) == 'function'){javascript:hideCalloutIcon('ad7d7056-ce4d-43af-9d12-71697de927ee');}">
                        <div class="ms-vl-appimage">

                            <a class="ms-storefront-selectanchor ms-storefront-appiconspan ms-draggable" tabindex="-1" id="viewlistad7d7056-ce4d-43af-9d12-71697de927ee-image" href="/Lists/Th ni a/AllItems.aspx" dragid="55" draggable="true">

                                <img class="ms-storefront-appiconimg" style="border: 0;" alt="Thẻ nội địa" src="/_layouts/15/images/ltgen.png?rev=23">
                            </a>
                        </div>
                        <div id="appinfo-ad7d7056-ce4d-43af-9d12-71697de927ee" class="ms-vl-appinfo ms-vl-pointer" onclick="javascript:launchCallout(arguments[0],'ad7d7056-ce4d-43af-9d12-71697de927ee', this)">
                            <div>
                                <div class="ms-vl-apptitleouter">

                                    <a class="ms-draggable ms-vl-apptitle ms-listLink" id="viewlistad7d7056-ce4d-43af-9d12-71697de927ee" href="/Lists/Th ni a/AllItems.aspx" title="Thẻ nội địa" dragid="54" draggable="true">Thẻ nội địa
                                    </a>
                                </div>
                                <a class="ms-vl-calloutarrow ms-calloutLink ms-ellipsis-a ms-pivotControl-overflowDot js-callout-launchPoint" id="ad7d7056-ce4d-43af-9d12-71697de927ee" href="javascript:;" title="Bấm để biết thêm thông tin." name="Bấm để biết thêm thông tin." onfocus="javascript:showCalloutIcon('ad7d7056-ce4d-43af-9d12-71697de927ee');" onblur="javascript:hideCalloutIcon('ad7d7056-ce4d-43af-9d12-71697de927ee');">
                                    <img id="ad7d7056-ce4d-43af-9d12-71697de927ee-breadcrumb" class="ms-ellipsis-icon" src="/_layouts/15/images/spcommon.png?rev=23" alt="Mở Menu" style="visibility: hidden;">
                                </a>
                            </div>



                            <div class="ms-metadata ms-vl-appstatus">
                                Quản lý thẻ nội địa
                            </div>
                            <div class="ms-metadata ms-vl-appstatus" id="appstatus-ad7d7056-ce4d-43af-9d12-71697de927ee">
                            </div>
                        </div>
                    </div>

                    <div id="apptile-1c066be8-e997-4c12-a3f2-7306cff54eab" class="ms-vl-apptile ms-vl-apptilehover " onmouseover="javascript:if (typeof(showCalloutIcon) == 'function'){showCalloutIcon('1c066be8-e997-4c12-a3f2-7306cff54eab');}" onmouseout="if (typeof(hideCalloutIcon) == 'function'){javascript:hideCalloutIcon('1c066be8-e997-4c12-a3f2-7306cff54eab');}">
                        <div class="ms-vl-appimage">

                            <a class="ms-storefront-selectanchor ms-storefront-appiconspan ms-draggable" tabindex="-1" id="viewlist1c066be8-e997-4c12-a3f2-7306cff54eab-image" href="/Style Library/Forms/AllItems.aspx" dragid="57" draggable="true">

                                <img class="ms-storefront-appiconimg" style="border: 0;" alt="Thư viện Kiểu" src="/_layouts/15/images/ltdl.png?rev=23">
                            </a>
                        </div>
                        <div id="appinfo-1c066be8-e997-4c12-a3f2-7306cff54eab" class="ms-vl-appinfo ms-vl-pointer" onclick="javascript:launchCallout(arguments[0],'1c066be8-e997-4c12-a3f2-7306cff54eab', this)">
                            <div>
                                <div class="ms-vl-apptitleouter">

                                    <a class="ms-draggable ms-vl-apptitle ms-listLink" id="viewlist1c066be8-e997-4c12-a3f2-7306cff54eab" href="/Style Library/Forms/AllItems.aspx" title="Thư viện Kiểu" dragid="56" draggable="true">Thư viện Kiểu
                                    </a>
                                </div>
                                <a class="ms-vl-calloutarrow ms-calloutLink ms-ellipsis-a ms-pivotControl-overflowDot js-callout-launchPoint" id="1c066be8-e997-4c12-a3f2-7306cff54eab" href="javascript:;" title="Bấm để biết thêm thông tin." name="Bấm để biết thêm thông tin." onfocus="javascript:showCalloutIcon('1c066be8-e997-4c12-a3f2-7306cff54eab');" onblur="javascript:hideCalloutIcon('1c066be8-e997-4c12-a3f2-7306cff54eab');">
                                    <img id="1c066be8-e997-4c12-a3f2-7306cff54eab-breadcrumb" class="ms-ellipsis-icon" src="/_layouts/15/images/spcommon.png?rev=23" alt="Mở Menu" style="visibility: hidden;">
                                </a>
                            </div>

                            <div class="ms-metadata ms-vl-appstatus">
                                Quản lý thư viện
                            </div>
                            <div class="ms-metadata ms-vl-appstatus" id="appstatus-1c066be8-e997-4c12-a3f2-7306cff54eab">
                            </div>
                        </div>
                    </div>

                    <div id="apptile-a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea" class="ms-vl-apptile ms-vl-apptilehover " onmouseover="javascript:if (typeof(showCalloutIcon) == 'function'){showCalloutIcon('a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea');}" onmouseout="if (typeof(hideCalloutIcon) == 'function'){javascript:hideCalloutIcon('a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea');}">
                        <div class="ms-vl-appimage">

                            <a class="ms-storefront-selectanchor ms-storefront-appiconspan ms-draggable" tabindex="-1" id="viewlista9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea-image" href="/Trang/Forms/AllItems.aspx" dragid="59" draggable="true">

                                <img class="ms-storefront-appiconimg" style="border: 0;" alt="Trang" src="/_layouts/15/images/ltdl.png?rev=23">
                            </a>
                        </div>
                        <div id="appinfo-a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea" class="ms-vl-appinfo ms-vl-pointer" onclick="javascript:launchCallout(arguments[0],'a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea', this)">
                            <div>
                                <div class="ms-vl-apptitleouter">

                                    <a class="ms-draggable ms-vl-apptitle ms-listLink" id="viewlista9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea" href="/Trang/Forms/AllItems.aspx" title="Trang" dragid="58" draggable="true">Trang
                                    </a>
                                </div>
                                <a class="ms-vl-calloutarrow ms-calloutLink ms-ellipsis-a ms-pivotControl-overflowDot js-callout-launchPoint" id="a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea" href="javascript:;" title="Bấm để biết thêm thông tin." name="Bấm để biết thêm thông tin." onfocus="javascript:showCalloutIcon('a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea');" onblur="javascript:hideCalloutIcon('a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea');">
                                    <img id="a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea-breadcrumb" class="ms-ellipsis-icon" src="/_layouts/15/images/spcommon.png?rev=23" alt="Mở Menu" style="visibility: hidden;">
                                </a>
                            </div>

                            <div class="ms-metadata ms-vl-appstatus">
                                Quản lý trang
                            </div>
                            <div class="ms-metadata ms-vl-appstatus" id="appstatus-a9c1aee6-43a3-4f85-aaf0-ba8bb66cc9ea">
                            </div>
                        </div>
                    </div>

                    <div id="apptile-7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88" class="ms-vl-apptile ms-vl-apptilehover " onmouseover="javascript:if (typeof(showCalloutIcon) == 'function'){showCalloutIcon('7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88');}" onmouseout="if (typeof(hideCalloutIcon) == 'function'){javascript:hideCalloutIcon('7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88');}">
                        <div class="ms-vl-appimage">

                            <a class="ms-storefront-selectanchor ms-storefront-appiconspan ms-draggable" tabindex="-1" id="viewlist7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88-image" href="/Lists/V Napas/AllItems.aspx" dragid="61" draggable="true">

                                <img class="ms-storefront-appiconimg" style="border: 0;" alt="Về Napas" src="/_layouts/15/images/ltgen.png?rev=23">
                            </a>
                        </div>
                        <div id="appinfo-7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88" class="ms-vl-appinfo ms-vl-pointer" onclick="javascript:launchCallout(arguments[0],'7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88', this)">
                            <div>
                                <div class="ms-vl-apptitleouter">

                                    <a class="ms-draggable ms-vl-apptitle ms-listLink" id="viewlist7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88" href="/Lists/V Napas/AllItems.aspx" title="Về Napas" dragid="60" draggable="true">Về Napas
                                    </a>
                                </div>
                                <a class="ms-vl-calloutarrow ms-calloutLink ms-ellipsis-a ms-pivotControl-overflowDot js-callout-launchPoint" id="7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88" href="javascript:;" title="Bấm để biết thêm thông tin." name="Bấm để biết thêm thông tin." onfocus="javascript:showCalloutIcon('7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88');" onblur="javascript:hideCalloutIcon('7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88');">
                                    <img id="7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88-breadcrumb" class="ms-ellipsis-icon" src="/_layouts/15/images/spcommon.png?rev=23" alt="Mở Menu" style="visibility: hidden;">
                                </a>
                            </div>

                            <div class="ms-metadata ms-vl-appstatus">
                                Thông tin napas
                            </div>
                            <div class="ms-metadata ms-vl-appstatus" id="appstatus-7e49c7ef-9635-4c22-b1d5-2a19f3b1cf88">
                            </div>
                        </div>
                    </div>

                    <div id="apptile-5bd35977-72a4-4856-884e-78fac4825f12" class="ms-vl-apptile ms-vl-apptilehover " onmouseover="javascript:if (typeof(showCalloutIcon) == 'function'){showCalloutIcon('5bd35977-72a4-4856-884e-78fac4825f12');}" onmouseout="if (typeof(hideCalloutIcon) == 'function'){javascript:hideCalloutIcon('5bd35977-72a4-4856-884e-78fac4825f12');}">
                        <div class="ms-vl-appimage">

                            <a class="ms-storefront-selectanchor ms-storefront-appiconspan ms-draggable" tabindex="-1" id="viewlist5bd35977-72a4-4856-884e-78fac4825f12-image" href="/Video/Forms/AllItems.aspx" dragid="63" draggable="true">

                                <img class="ms-storefront-appiconimg" style="border: 0;" alt="Video" src="/_layouts/15/images/ltdl.png?rev=23">
                            </a>
                        </div>
                        <div id="appinfo-5bd35977-72a4-4856-884e-78fac4825f12" class="ms-vl-appinfo ms-vl-pointer" onclick="javascript:launchCallout(arguments[0],'5bd35977-72a4-4856-884e-78fac4825f12', this)">
                            <div>
                                <div class="ms-vl-apptitleouter">

                                    <a class="ms-draggable ms-vl-apptitle ms-listLink" id="viewlist5bd35977-72a4-4856-884e-78fac4825f12" href="/Video/Forms/AllItems.aspx" title="Video" dragid="62" draggable="true">Video
                                    </a>
                                </div>
                                <a class="ms-vl-calloutarrow ms-calloutLink ms-ellipsis-a ms-pivotControl-overflowDot js-callout-launchPoint" id="5bd35977-72a4-4856-884e-78fac4825f12" href="javascript:;" title="Bấm để biết thêm thông tin." name="Bấm để biết thêm thông tin." onfocus="javascript:showCalloutIcon('5bd35977-72a4-4856-884e-78fac4825f12');" onblur="javascript:hideCalloutIcon('5bd35977-72a4-4856-884e-78fac4825f12');">
                                    <img id="5bd35977-72a4-4856-884e-78fac4825f12-breadcrumb" class="ms-ellipsis-icon" src="/_layouts/15/images/spcommon.png?rev=23" alt="Mở Menu" style="visibility: hidden;">
                                </a>
                            </div>

                            <div class="ms-metadata ms-vl-appstatus">
                                Quản lý video
                            </div>
                            <div class="ms-metadata ms-vl-appstatus" id="appstatus-5bd35977-72a4-4856-884e-78fac4825f12">
                            </div>
                        </div>
                    </div>

                </div>
            </td>
        </tr>--%>
        
    </tbody>
</table>
