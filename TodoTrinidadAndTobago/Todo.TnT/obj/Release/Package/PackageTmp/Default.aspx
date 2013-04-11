<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Todo.TnT._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!-- Jumbotron -->
      <div class="jumbotron">
        <h1>Are you here for <%: Category %>?</h1>
         <a class="btn btn-large btn-success" href="map.aspx?reason=<%: Category %>">Continue</a>
         <hr />
           <p class="lead">
              Not here for <%: Category %>, then tell us your reason for visiting
               <asp:DropDownList runat="server" ID="categoriesDdl"></asp:DropDownList>
          </p>
      </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            $("#SelectedCategory").change(function () {
                location.href = "map?reason=" + $(this).val();
            });
        });
    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="NaveSection">

</asp:Content>