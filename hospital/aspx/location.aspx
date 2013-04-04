<%@ Page Language="C#" AutoEventWireup="true" CodeFile="location.aspx.cs" Inherits="aspx_location" MasterPageFile="~/master/main.master"%>
<asp:Content ContentPlaceHolderID="head" runat="server">
<title>Google Maps JavaScript API Example</title>

<script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAAeyBvm8_denejVGDd7fj9WBQz-J5LV6rASCxLYU1xMqKNc_nHIxRZX9H0ccC5iDcGgiLR9Vu8ngmMoA&sensor=true_or_false" type="text/javascript"></script>

<script type="text/javascript">

function GoogleMapUtil() {
	this.southWest = null;
	this.northEast = null;
	this.lngSpan = 0;
	this.latSpan = 0;
	this.bounds = null;
	this.map = null;
	this.baseIcon = null;
	this.markers = new Array();
	this.shadowImg = "http://www.google.com/mapfiles/shadow50.png";
	this.letterImg = "http://www.google.com/mapfiles/marker<LETTER>.png"
	this.index = 0;
	this.images = new Array();
	this.initialize = function(mapId, lat, lng, zoom) {
		if (GBrowserIsCompatible()) {
			this.map = new GMap2(document.getElementById(mapId));
			this.map.setCenter(new GLatLng(lat, lng), zoom);
			this.map.setUIToDefault();
			this.bounds = this.map.getBounds();
			this.southWest = this.bounds.getSouthWest();
			this.northEast = this.bounds.getNorthEast();
			this.lngSpan = this.northEast.lng() - this.southWest.lng();
			this.latSpan = this.northEast.lat() - this.southWest.lat();

			// Create a base icon for all of our markers that specifies the
			// shadow, icon dimensions, etc.
			this.baseIcon = new GIcon(G_DEFAULT_ICON);
			this.baseIcon.shadow = this.shadowImg;
			this.baseIcon.iconSize = new GSize(20, 34);
			this.baseIcon.shadowSize = new GSize(37, 34);
			this.baseIcon.iconAnchor = new GPoint(9, 34);
			this.baseIcon.infoWindowAnchor = new GPoint(9, 2);
			this.markers = new Array();
			this.images = new Array();
		}
	};

	// Creates a marker whose info window displays the letter corresponding
	// to the given index.
	this.createMarker = function(index, point, imgIndex) {
		// Create a lettered icon for this point using our icon class
		var letter = String.fromCharCode("A".charCodeAt(0) + index);
		var letteredIcon;
		if( imgIndex == undefined || imgIndex == null ) {
			letteredIcon = new GIcon(this.baseIcon);
			letteredIcon.image = this.letterImg.replace("<LETTER>", letter); //http://www.google.com/mapfiles/marker" + letter + ".png";
		} else {
			letteredIcon = this.images[imgIndex];
		}

		// Set up our GMarkerOptions object
		markerOptions = { icon:letteredIcon };
		var marker = new GMarker(point, markerOptions);
		this.markers[index] = marker;
		return marker;
	};

	this.setClickMsg = function(index, msg) {
		GEvent.addListener(this.markers[index], "click", function() {
		this.openInfoWindowHtml(msg);
		});
	}

	/**
	* add a marker on the map
	* index, left, top, msg
	* top 0.11 ~ 0.99
	* left 0.11 ~ 0.99
	* index
	* msg
	*/
	this.addMarker = function(top, left, imgIndex) {
		var latlng = new GLatLng(this.southWest.lat() + this.latSpan * left, this.southWest.lng() + this.lngSpan * top);
			if( imgIndex == undefined || imgIndex == null ) {
				this.map.addOverlay(this.createMarker(this.index, latlng));
			} else {
				this.map.addOverlay(this.createMarker(this.index, latlng, imgIndex));
			}
		this.index++;
		return this.index -1;
	};

	/*
	* 이미지 크기 및 위치등 모든 정보가 다른 새로운 이미지를 추가할 때 사용
	* imagePath, 이미지 경로
	* width, 이미지 넓이
	* height, 이미지 높이
	* shadowPath, 그림자 경로
	* sWidth, 그림자 넓이
	* sHeight, 그림자 높이
	* AnchorX, 포인트 X
	* AnchorY, 포인트 Y
	* infoX, 윈도우 X
	* infoY 윈도우 Y
	*/

	this.setImageDetail = function(imagePath, width, height, shadowPath, sWidth, sHeight, AnchorX, AnchorY, infoX, infoY) {
		// Create a base icon for all of our markers that specifies the
		// shadow, icon dimensions, etc.
		var newIcon = new GIcon(G_DEFAULT_ICON);
		if( shadowPath == "") {
			newIcon.shadow = this.shadowImg;
		} else {
			newIcon.shadow = shadowPath;
		}

		newIcon.image = imagePath;
		newIcon.iconSize = new GSize(width, height);
		newIcon.shadowSize = new GSize(sWidth, sHeight);
		newIcon.iconAnchor = new GPoint(AnchorX, AnchorY);
		newIcon.infoWindowAnchor = new GPoint(infoX, infoY);
		var index = this.images.length;
		this.images[index] = newIcon;
		return index;
	};

	//이미지 경로만으로 아이콘 생성
	this.setImage = function(imagePath) {
		var newIcon = new GIcon(this.baseIcon);
		newIcon.image = imagePath;
		var index = this.images.length;
		this.images[index] = newIcon;
		return index;
	};
}

function initialize() {
	var gm1 = new GoogleMapUtil();
	gm1.initialize("map_canvas", -19.257613, 146.818972, 16);
	var index = gm1.addMarker(0.5, 0.5);
	gm1.setClickMsg(index, "Here is the <b>Townsville Children Hospital</b><br/> Phone : 07-1234-1234");
}
window.onload = function() {
	initialize();
}
window.onunload = function() {
	GUnload();
}
</script> 
</asp:Content>
<asp:Content ContentPlaceHolderID="cnt" runat="server">
	<h1>Location<div class="break"></div></h1>
	<div id="map_canvas" style="width: 680px; height: 400px"></div> 
</asp:Content>