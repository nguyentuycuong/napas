<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ATMPositions.ascx.cs" Inherits="Napas.Portal.ControlTemplates.ATMPositions" %>
<%@ Register Src="CustomerLeftMenu.ascx" TagName="CustomerLeftMenu" TagPrefix="uc1" %>
<section class="intro-banner intro-banner-customer"></section>
<section class="middle">
    <div class="middle-inner">
        <div class="container">
            <div class="sitemap">
                <SharePoint:SPLinkButton runat="server" NavigateUrl="<%$Resources:napas.resource,Url%>" CssClass="home">
                    <i class="fa fa-home"></i>
                </SharePoint:SPLinkButton>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlAtmPosition%>'>
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,CustomerService%>" />
                </SharePoint:SPLinkButton>
                <span>|</span>
                <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlAtmPosition%>' CssClass="current">
                    <asp:Literal runat="server" Text="<%$Resources:napas.resource,AtmPosition%>" />
                </SharePoint:SPLinkButton>
            </div>
            <div class="cols">
                <div class="colleft">
                    <ul id="menu" class="menuleft">
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlInteriorCard%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,InteriorCard%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlTranfer247%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Tranfer247%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlShoppingOnline%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,ShoppingOnline%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlTopup%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Topup%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPayBills%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,PayBills%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li class="active">
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlAtmPosition%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,AtmPosition%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                        <li>
                            <SharePoint:SPLinkButton runat="server" NavigateUrl='<%$Resources:napas.resource,UrlPromotion%>'>
                                <i class="fa fa-angle-right"></i>
                                <asp:Literal runat="server" Text="<%$Resources:napas.resource,Promotion%>" />
                            </SharePoint:SPLinkButton>
                        </li>
                    </ul>
                </div>
                <div class="colright">
                    <div class="search-atm">

                        <div class="search-atm-left">


                            <div ng-app="myApp" ng-controller="myCtrl" class="row row-fix">
                                <div class="col-md-4 col-sm-4 col-xs-12 col-fix">
                                    <div class="col-search">
                                        <p>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,City%>"></asp:Literal>
                                        </p>

                                        <select id="city" ng-change="Districts(selectId)" ng-model="selectId">
                                            
                                            <option ng-repeat="city in cities" value="{{city.text}}">{{city.text}}</option>
                                        </select>
                                    </div>

                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-12 col-fix">
                                    <div class="col-search">
                                        <p>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,Province%>"></asp:Literal>
                                        </p>
                                        <select id="province">
                                            <option ng-repeat="district in districts" value="{{district.text}}">{{district.text}}</option>
                                            
                                        </select>
                                    </div>

                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-12 col-fix">
                                    <div class="col-search">
                                        <p>
                                            <asp:Literal runat="server" Text="<%$Resources:napas.resource,Bank%>"></asp:Literal>
                                        </p>
                                        <select id="bank">
                                            <option></option>
                                            <option ng-repeat="c in banks">{{c}}</option>
                                        </select>
                                    </div>


                                </div>
                            </div>
                        </div>
                        <button class="btn-search-atm" style="min-width: 2px !important; padding-top: 1px;" onclick="searchATM();return false;">
                            <i class="fa fa-search" style="align-content: space-between"></i>
                        </button>

                    </div>
                    <div class="map-atm">
                        <div id="map" style="height: 450px"></div>
                    </div>
                    <div class="table-atm table-responsive">
                        <table class="table " id="itemList">
                            <thead>
                                <tr>
                                    <th>STT</th>
                                    <th>Tỉnh/ Thành phố</th>
                                    <th>Ngân hàng</th>
                                    <th>Điểm đặt máy	</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                    <%--<div class="paging">
                        <a href="#">
                            <i class="fa fa-angle-left"></i>
                        </a>
                        <a href="#" class="current">1</a>
                        <a href="#">2</a>
                        <a href="#">...</a>
                        <a href="#">10</a>
                        <a href="#"><i class="fa fa-angle-right"></i></a>

                    </div>--%>

                </div>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
</section>
<SharePoint:ScriptLink runat="server" ID="ScriptLink2" Language="javascript" Name="~sitecollection/_catalogs/masterpage/napas_theme/js/jquery.SPServices-2014.02.min.js" />
<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAF_NNOb14yj9gRYmwnkvj52M8D0fdL148&sensor=false&signed_in=true&q=Space+Needle,Seattle+WA&libraries=places"></script>

<script language="javascript" type="text/javascript">
    var map;
    var infowindow;
    function initialize(lat, lng, queryStr) {
        var pyrmont = new google.maps.LatLng(lat, lng);

        map = new google.maps.Map(document.getElementById('map'), {
            center: pyrmont,
            zoom: 15
        });

        var request = {
            location: pyrmont,
            //radius: '500',
            query: queryStr
        };
        infowindow = new google.maps.InfoWindow();
        var service = new google.maps.places.PlacesService(map);
        //service.nearbySearch(request, callback);
        service.textSearch(request, callback);
    }

    function callback(results, status) {
        if (status == google.maps.places.PlacesServiceStatus.OK) {
            for (var i = 0; i < results.length; i++) {
                var e = document.getElementById("city");
                if(e != undefined || e!= null)
                    createMarker(results[i], i);
            }
        }
    }

    function createMarker(place, pos) {
        var placeLoc = place.geometry.location;
        var e = document.getElementById("city");
        var strCity = e.options[e.selectedIndex].value;
        var e = document.getElementById("bank");
        var strBank = e.options[e.selectedIndex].value

        var marker = new google.maps.Marker({
            map: map,
            position: place.geometry.location
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.setContent(place.name);
            infowindow.open(map, this);
        });
        var rows = "";
        rows += "<tr><td>" + pos + "</td><td>" + strCity + "</td><td>" + strBank + "</td><td>" + place.name + "</td></tr>";
        $(rows).appendTo("#itemList tbody");
    }

    google.maps.event.addDomListener(window, 'load', initialize(21.033333, 105.849998, " "));
    function searchATM() {
        $("#itemList tbody tr").remove();
        var e = document.getElementById("city");
        var strCity = e.options[e.selectedIndex].value;
        var e = document.getElementById("province");
        var strProvince = e.options[e.selectedIndex].value;
        var e = document.getElementById("bank");
        var strBank = "ATM " + e.options[e.selectedIndex].value + " " + strProvince + " " + strCity;
        var address = strProvince + " " + strCity;
        geocoder = new google.maps.Geocoder();
        geocoder.geocode({
            'address': address
        }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                initialize(results[0].geometry.location.lat(), results[0].geometry.location.lng(), strBank);
            }
        });
    }
    /*var map;
    var geocoder;
    function InitializeMap() {

        var latlng = new google.maps.LatLng(21.033333, 105.849998);
        var myOptions =
        {
            zoom: 17,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            disableDefaultUI: true
        };
        map = new google.maps.Map(document.getElementById("map"), myOptions);

        var geocoder = new google.maps.Geocoder();
        var address = "183 hoang van thai thanh xuan ha noi";

        geocoder.geocode({ 'address': address }, function (results, status) {
            alert(results.length);
            if (status == google.maps.GeocoderStatus.OK) {
                var latitude = results[0].geometry.location.lat();
                var longitude = results[0].geometry.location.lng();
                FindLocaiton(latitude, longitude);
            }
        });
    }
    function searchATM()
    {
        alert("Begin search ATM");
        var e = document.getElementById("city");
        var strCity = e.options[e.selectedIndex].value;
        var e = document.getElementById("province");
        var strProvince = e.options[e.selectedIndex].value;
        var e = document.getElementById("bank");
        var strBank = e.options[e.selectedIndex].value;

        var address = "ATM " + strBank + " " + strProvince + " " + strCity;

        alert(address);

        var geocoder = new google.maps.Geocoder();
        

        geocoder.geocode({ 'address': address }, function (results, status) {
            alert("google return status: " + status + " results " + results.c);
            if (status == google.maps.GeocoderStatus.OK) {
                var latitude = results[0].geometry.location.lat();
                var longitude = results[0].geometry.location.lng();
                FindLocaiton(latitude, longitude);
            }
        });
    }

    function FindLocaiton(lat, lng) {
        geocoder = new google.maps.Geocoder();
        InitializeMap();
        var latlng = new google.maps.LatLng(lat, lng);
        map.setCenter(latlng);
        var marker = new google.maps.Marker({
            map: map,
            position: latlng
        });

        var infowindow = new google.maps.InfoWindow({
            content: 'Message 1'
        });

        google.maps.event.addListener(marker, 'click', function () {
            // Calling the open method of the infoWindow 
            infowindow.open(map, marker);
        });
        return false;

    }


    window.onload = InitializeMap;*/
    //$(document).ready(function () {

    //});

    var app = angular.module('myApp', []);
    app.controller('myCtrl', function ($scope) {
        $scope.cities = [];
        $().SPServices({
            operation: "GetListItems",
            async: false,
            listName: "Tỉnh thành",
            CAMLViewFields: "<ViewFields><FieldRef Name='Title' /></ViewFields>",
            completefunc: function (xData, Status) {
                $(xData.responseXML).SPFilterNode("z:row").each(function() {
                    //alert($(this).attr("ows_Title"));
                    $scope.cities.push({ text: $(this).attr("ows_Title"), id: $(this).attr("ows_ID") });
                });
            }
        });

        $scope.Districts = function (city) {
            //alert(city);
            $scope.districts = [];
            $().SPServices({
                operation: "GetListItems",
                async: false,
                listName: "Quận huyện",
                CAMLQuery: "<Query><Where><Eq><FieldRef Name='City' /><Value Type='Lookup'>" + city + "</Value></Eq></Where></Query>",
                CAMLViewFields: "<ViewFields><FieldRef Name='Title' /></ViewFields>",
                completefunc: function (xData, Status) {
                    $(xData.responseXML).SPFilterNode("z:row").each(function() {
                        //alert($(this).attr("ows_Title"));
                        //$scope.xxx.push($(this).attr("ows_Title"));
                        $scope.districts.push({
                            text: $(this).attr("ows_Title"), id: $(this).attr("ows_ID")
                    });
                });
                }
            });
        };

        //$scope.districts = [];
        //    $().SPServices({
        //        operation: "GetListItems",
        //        async: false,
        //        listName: "Quận huyện",
        //    CAMLQuery: "<Query><Where><Eq><FieldRef Name='City' /><Value Type='Lookup'>" + "Hà Nội" + "</Value></Eq></Where></Query>",
        //        CAMLViewFields: "<ViewFields><FieldRef Name='Title' /></ViewFields>",
        //        completefunc: function (xData, Status) {
        //            $(xData.responseXML).SPFilterNode("z:row").each(function () {
        //                //alert($(this).attr("ows_Title"));
        //            //$scope.xxx.push($(this).attr("ows_Title"));
        //            $scope.districts.push({
        //                text: $(this).attr("ows_Title"), id: $(this).attr("ows_ID")
        //            });
        //            });
        //        }
        //    });
        

        $scope.banks = []; 
        $().SPServices({
            operation: "GetListItems",
            async: false,
            listName: "Khách hàng - Đối tác",
            
            completefunc: function (xData, Status) {
                $(xData.responseXML).SPFilterNode("z:row").each(function () {
                    //alert($(this).attr("ows_Title"));
                    $scope.banks.push($(this).attr("ows_Title"));
                });
            }
        });

       

    });

    
</script>

