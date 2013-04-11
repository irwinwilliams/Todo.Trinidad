<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapSample.aspx.cs" Inherits="Todo.TnT.MapSample" %>

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
     <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCaUK25OBJxjVADJr7p9wlKcpwu2D4_KVc&sensor=true"></script>
    <%--<script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>--%>
    <script>
        var map;
        function initialize() {
            var mapOptions = {
                zoom: 9,
                center: new google.maps.LatLng(10.70, -61.3152),

                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById('map-canvas'),
                mapOptions);
        }

        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
  </head>
  <body>
    <div id="map-canvas"></div>
  </body>
</html>