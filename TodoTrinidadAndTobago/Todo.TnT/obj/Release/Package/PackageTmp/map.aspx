<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="Todo.TnT.map" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Jumbotron -->
      <div class="jumbotron">
        <iframe src="MapSample.aspx" width="1000" height="500"></iframe>
      </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
     <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCaUK25OBJxjVADJr7p9wlKcpwu2D4_KVc&sensor=true"></script>
    <script type="text/javascript">
        function initialize() {
            var mapOptions = {
                center: new google.maps.LatLng(-34.397, -61.3152),
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("map-canvas"),
                mapOptions);
        }
        $(function () {
            initialize();
        });
    </script>
</asp:Content>