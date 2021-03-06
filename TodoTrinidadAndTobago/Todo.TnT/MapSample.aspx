﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapSample.aspx.cs" Inherits="Todo.TnT.MapSample" %>

<!DOCTYPE html>
<html>
  <head>
    <title>Google Maps JavaScript API v3 Example: Map Simple</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <style>
      html, body, #map-canvas {
        margin: 0;
        padding: 0;
        height: 100%;
      }
    </style>
        <script src="http://code.jquery.com/jquery.js"></script>
     <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCaUK25OBJxjVADJr7p9wlKcpwu2D4_KVc&sensor=true"></script>
    <%--<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>--%>
    <script>
        var map;
        var layers = [];
        var infowindow = new google.maps.InfoWindow(
  {
      size: new google.maps.Size(150, 50)
  });
        function initMarkers() {


        }

        function addMarker(location, name, desc, cat) {
            var marker = new google.maps.Marker({
                position: location,
                title: name,
                map: map
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.setContent(desc);
                infowindow.open(map, marker);
            });
        }

        function hideLayer(layerIndex) {
            var layerToHide = layers[layerIndex];
            for (var i = 0; i < layerToHide.length; i++) {
                layerToHide[i].setMap(null);
            }
        }

        function showLayer(layerIndex) {
            var layerToShow = layers[layerIndex];
            for (var i = 0; i < layerToShow.length; i++) {
                layerToShow[i].setMap(map);
            }
        }

        function showAllLayers() {
            for (var i = 0; i < layers.length; i++) {
                for (var j = 0; j < layers[i].length; j++) {
                    layers[i][j].setMap(map);
                }
            }
        }


        function initialize() {
            var mapOptions = {
                zoom: 9,
                center: new google.maps.LatLng(10.70, -61.3152),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById('map-canvas'),
                mapOptions);

            $.get("data/tntpois.js", null, function (data) {
                data = JSON.parse(data);
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    addMarker(new google.maps.LatLng(item.lat, item.long), item.name, item.description, item.cat);
                }
            });

            //google.maps.event.addListener(map, 'click', function (event) {
            //    addMarker(event.latLng);
            //});

            google.maps.event.addListener(map, 'click', function () {
                infowindow.close();
            });
        }

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
  </head>
  <body>
    <div id="map-canvas"></div>
  </body>
</html>